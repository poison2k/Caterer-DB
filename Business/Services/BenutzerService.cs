using AutoMapper;
using Business.Interfaces;
using Common.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using Common.Services;
using GoogleMaps.LocationServices;
using System.Data.Entity.Spatial;

namespace Business.Services
{
    public class BenutzerService : IBenutzerService
    {
        public IBenutzerRepository BenutzerRepository { get; set; }

        public IBenutzerGruppeService BenutzerGruppeService { get; set; }

        public IMailService MailService { get; set; }

        public IDocumentService DocumentService { get; set; }

        public IMd5Hash MD5Hash { get; set; }

        private IMapper Mapper { get; set; }

        public BenutzerService(IBenutzerRepository benutzerRepository, IMailService mailService, IBenutzerGruppeService benutzerGruppeService, IMd5Hash md5Hash, IDocumentService documentService)
        {
            BenutzerRepository = benutzerRepository;
            BenutzerGruppeService = benutzerGruppeService;
            MailService = mailService;
            DocumentService = documentService;
            MD5Hash = md5Hash;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<List<BenutzerGruppe>, List<BenutzerGruppe>>();
                cfg.CreateMap<Benutzer, Benutzer>()
                    .ForMember(x => x.BenutzerGruppen, opt => opt.MapFrom(s => Mapper.Map<List<BenutzerGruppe>, List<BenutzerGruppe>>(s.BenutzerGruppen)))
                    .ForAllMembers(opt => opt.Condition((source, destination, sourceMember, destMember) => (sourceMember != null)));
            });

            Mapper = config.CreateMapper();
        }

        public Benutzer SearchUserById(int id)
        {
            return BenutzerRepository.SearchUserById(id);
        }

        public List<Benutzer> FindeCatererNachUmkreis(string plz, int umkreis) {
            var Adresse = new AddressData()
            {
                Country = "Deutschland",
                Zip = plz,
            };

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(Adresse);
            var GeoDaten = DbGeography.FromText("Point(" + point.Longitude.ToString().Replace(',','.') + " " + point.Latitude.ToString().Replace(',', '.') + " )");
            return BenutzerRepository.FindeCatererNachUmkreis(GeoDaten, umkreis);
        }
        public Benutzer SearchUserByIdNoTracking(int id)
        {
            return BenutzerRepository.SearchUserByIdNoTracking(id);
        }

        public Benutzer SearchUserByEmail(string email)
        {
            return BenutzerRepository.SearchUserByEMail(email);
        }

        public List<Benutzer> FindAllBenutzers()
        {
            return BenutzerRepository.SearchUser();
        }

        public List<Benutzer> FindAllMitarbeiterWithPaging(int aktuelleSeite, int seitenGroesse, string sortierrung)
        {
            var benutzerGruppen = new List<string>() { "Administrator", "Mitarbeiter" };

            return BenutzerRepository.SearchAllUserByUserGroupWithPagingOrderByCategory(aktuelleSeite, seitenGroesse, benutzerGruppen, sortierrung);
        }

        public List<Benutzer> FindAllCatererWithPaging(int aktuelleSeite, int seitenGroesse, string sortierrung)
        {
            var benutzerGruppen = new List<string>() { "Caterer" };

            return BenutzerRepository.SearchAllUserByUserGroupWithPagingOrderByCategory(aktuelleSeite, seitenGroesse, benutzerGruppen, sortierrung);
        }

        public void AddBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
        }

        public void AddBenutzer(Benutzer benutzer, string gruppe)
        {
            benutzer.BenutzerGruppen = new List<BenutzerGruppe>() { BenutzerGruppeService.SearchGroupByBezeichnung(gruppe) };
            benutzer.IstEmailVerifiziert = true;
            benutzer.PasswortZeitstempel = DateTime.Now;

            BenutzerRepository.AddUser(benutzer);

            benutzer = BenutzerRepository.SearchUserByEMail(benutzer.Mail);
            benutzer.PasswordVerificationCode = MD5Hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname + benutzer.Passwort);
            benutzer.PasswortZeitstempel = DateTime.Now;

            BenutzerRepository.EditUser(benutzer);
        }

        public void AddMitarbeiter(Benutzer benutzer, string gruppe)
        {
            AddBenutzer(benutzer, gruppe);

            MailService.SendNewMitarbeiterMail(benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void AddCaterer(Benutzer benutzer, string gruppe)
        {
            AddBenutzer(benutzer, gruppe);

            MailService.SendNewCatererMail(benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void RegisterBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
            MailService.SendRegisterMail(benutzer.EMailVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void ForgottenPasswordEmailForBenutzer(string Mail)
        {
            var benutzer = BenutzerRepository.SearchUserByEMail(Mail);
            benutzer.PasswordVerificationCode = MD5Hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname + benutzer.Passwort);
            benutzer.PasswortZeitstempel = DateTime.Now;
            BenutzerRepository.EditUser(benutzer);
            MailService.SendForgottenPasswordMail(benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void EditBenutzer(Benutzer editedBenutzer, bool istAdmin)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);
            var rolleVorhanden = false;
            foreach (BenutzerGruppe benutzergruppe in dbBenutzer.BenutzerGruppen)
            {
                if (benutzergruppe.Bezeichnung == "Administrator")
                {
                    rolleVorhanden = true;
                }
            }
            if (istAdmin && !rolleVorhanden)
            {
                dbBenutzer.BenutzerGruppen = new List<BenutzerGruppe>() { BenutzerGruppeService.SearchGroupByBezeichnung("Administrator") };
            }
            else if (!istAdmin && rolleVorhanden)
            {
                dbBenutzer.BenutzerGruppen = new List<BenutzerGruppe>() { BenutzerGruppeService.SearchGroupByBezeichnung("Mitarbeiter") };
            }
            editedBenutzer.BenutzerGruppen = dbBenutzer.BenutzerGruppen;
            editedBenutzer.PasswortZeitstempel = dbBenutzer.PasswortZeitstempel;
            Mapper.Map(editedBenutzer, dbBenutzer);
            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void EditBenutzer(Benutzer editedBenutzer)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);
            editedBenutzer.BenutzerGruppen = dbBenutzer.BenutzerGruppen;
            editedBenutzer.PasswortZeitstempel = dbBenutzer.PasswortZeitstempel;
            editedBenutzer.IstEmailVerifiziert = dbBenutzer.IstEmailVerifiziert;
            Mapper.Map(editedBenutzer, dbBenutzer);
            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void EditCaterer(Benutzer editedBenutzer)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);
            MailService.SendEditCatererMail(dbBenutzer.Mail);
            Mapper.Map(editedBenutzer, dbBenutzer);
            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void RemoveCaterer(int id)
        {
            var benutzer = BenutzerRepository.SearchUserById(id);
            MailService.SendRemoveCatererMail(benutzer.Mail);
            BenutzerRepository.RemoveUser(BenutzerRepository.SearchUserById(id));
        }

        public void RemoveBenutzer(int id)
        {
            BenutzerRepository.RemoveUser(BenutzerRepository.SearchUserById(id));
        }

        public bool CheckEmailForRegistration(string mail)
        {
            if (BenutzerRepository.SearchUserByEMail(mail) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerifyRegistration(string id, string verify)
        {
            var benutzer = BenutzerRepository.SearchUserById(Convert.ToInt32(id));
            if (benutzer != null && verify != null)
            {
                if (benutzer?.EMailVerificationCode == verify)
                {
                    benutzer.IstEmailVerifiziert = true;
                    benutzer.EMailVerificationCode = "";
                    BenutzerRepository.EditUser(benutzer);
                    return true;
                }
            }
            return false;
        }

        public bool VerifyPasswordChange(string id, string verify)
        {
            var benutzer = BenutzerRepository.SearchUserById(Convert.ToInt32(id));
            if (benutzer != null && verify != null)
            {
                TimeSpan ts = DateTime.Now - benutzer.PasswortZeitstempel;
                if (benutzer?.PasswordVerificationCode == verify && ts.Minutes < 120)
                {
                    return true;
                }
            }
            return false;
        }

        public void EditBenutzerPassword(Benutzer tempBenutzer)
        {
            var benutzer = BenutzerRepository.SearchUserById(tempBenutzer.BenutzerId);
            benutzer.Passwort = tempBenutzer.Passwort;
            benutzer.PasswordVerificationCode = "";
            BenutzerRepository.EditUser(benutzer);
        }

        public int GetMitarbeiterCount()
        {
            return BenutzerRepository.GetMitarbeiterCount();
        }

        public int GetCatererCount()
        {
            return BenutzerRepository.GetCatererCount();
        }
    }
}
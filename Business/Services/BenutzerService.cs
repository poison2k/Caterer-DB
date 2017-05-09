using AutoMapper;
using Business.Interfaces;
using Common.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        private IConfigService ConfigService { get; set; }

        private IGoogleService GoogleService { get; set; }

        public BenutzerService(IBenutzerRepository benutzerRepository, IMailService mailService, IBenutzerGruppeService benutzerGruppeService, IMd5Hash md5Hash, IDocumentService documentService, IConfigService configService, IGoogleService googleService)
        {
            BenutzerRepository = benutzerRepository;
            BenutzerGruppeService = benutzerGruppeService;
            MailService = mailService;
            DocumentService = documentService;
            MD5Hash = md5Hash;
            ConfigService = configService;
            GoogleService = googleService;

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

        public List<Benutzer> FindeCatererNachIds(List<int> ids)
        {
            return BenutzerRepository.SearchUser(ids);
        }

        public List<Benutzer> FindeCatererNachUmkreis(string plz, int umkreis)
        {

            var GeoDaten = GoogleService.FindeLocationByPlz(plz);
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

        public List<Benutzer> FindAllCatererWithPaging(int aktuelleSeite, int seitenGroesse, string sortierrung, int umkreis, string plz, string name, List<int> antwortIds)
        {
            var benutzerGruppen = new List<string>() { "Caterer" };
            List<Benutzer> caterer;
            if (plz != "" && plz != null)
            {

                caterer = BenutzerRepository.SearchAllUserByUserGroupWithPagingOrderByCategory(aktuelleSeite, seitenGroesse, benutzerGruppen, sortierrung, umkreis, GoogleService.FindeLocationByPlz(plz), name);

            }
            else
            {

                caterer = BenutzerRepository.SearchAllUserByUserGroupWithPagingOrderByCategory(aktuelleSeite, seitenGroesse, benutzerGruppen, sortierrung, umkreis, null, name);
            }


            if (antwortIds.Count != 0)
            {
                List<Benutzer> listUser = new List<Benutzer>();
                foreach (Benutzer user in caterer)
                {
                    bool antwortEnthalten = false;

                    if (antwortIds.Intersect(user.AntwortIDs).Count() == antwortIds.Count())
                    {
                        antwortEnthalten = true;
                    }

                    if (!antwortEnthalten)
                    {
                        listUser.Add(user);
                    }
                }
                foreach (Benutzer user in listUser)
                {
                    caterer.Remove(user);
                }
            }


            return caterer;
        }

        public void AddBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
        }

        public void AddBenutzer(Benutzer benutzer, string gruppe)
        {
            benutzer.BenutzerGruppen = new List<BenutzerGruppe>() { BenutzerGruppeService.SearchGroupByBezeichnung(gruppe) };

            benutzer.PasswortZeitstempel = DateTime.Now;
            benutzer.LetzteÄnderung = new DateTime(1900,1,1);
            if (gruppe == "Caterer")
            {
                try
                {
                    benutzer.Koordinaten =
                        GoogleService.FindeLocationByAdress(benutzer.Postleitzahl, benutzer.Straße, benutzer.Ort);
                }
                catch 
                {
                    throw new ArgumentException("Ungültige Adresse");
                }
            }
            BenutzerRepository.AddUser(benutzer);

            benutzer = BenutzerRepository.SearchUserByEMail(benutzer.Mail);
            benutzer.PasswordVerificationCode = MD5Hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname + benutzer.Passwort);
            benutzer.PasswortZeitstempel = DateTime.Now;
            benutzer.LetzteÄnderung = new DateTime(1900, 1, 1);

            BenutzerRepository.EditUser(benutzer);
        }

        public void AddMitarbeiter(Benutzer benutzer, string gruppe)
        {
            AddBenutzer(benutzer, gruppe);

            MailService.SendNewMitarbeiterMail(ConfigService.GetConfig(), benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void AddCaterer(Benutzer benutzer, string gruppe)
        {
            AddBenutzer(benutzer, gruppe);

            MailService.SendNewCatererMail(ConfigService.GetConfig(), benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void RegisterBenutzer(Benutzer benutzer)
        {
            try
            {
                benutzer.Koordinaten = GoogleService.FindeLocationByAdress(benutzer.Postleitzahl, benutzer.Straße, benutzer.Ort);
            }
            catch
            {
                throw new ArgumentException("Ungültige Adresse");
            }
            
            AddBenutzer(benutzer, "Caterer");
            MailService.SendRegisterMail(ConfigService.GetConfig(), benutzer.EMailVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void ForgottenPasswordEmailForBenutzer(string Mail)
        {
            var benutzer = BenutzerRepository.SearchUserByEMail(Mail);
            benutzer.PasswordVerificationCode = MD5Hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname + benutzer.Passwort);
            benutzer.PasswortZeitstempel = DateTime.Now;
            BenutzerRepository.EditUser(benutzer);
            MailService.SendForgottenPasswordMail(ConfigService.GetConfig(), benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());
        }

        public void AdminEditMitarbeiterData(Benutzer editedBenutzer, bool istAdmin)
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
            dbBenutzer.LetzteÄnderung = DateTime.Now;
            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void EditBenutzer(Benutzer editedBenutzer)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);
            editedBenutzer.BenutzerGruppen = dbBenutzer.BenutzerGruppen;
            editedBenutzer.PasswortZeitstempel = dbBenutzer.PasswortZeitstempel;
            editedBenutzer.IstEmailVerifiziert = dbBenutzer.IstEmailVerifiziert;
            editedBenutzer.LetzteÄnderung = dbBenutzer.LetzteÄnderung;
            Mapper.Map(editedBenutzer, dbBenutzer);
            if (editedBenutzer.BenutzerGruppen.FindAll(x => x.Bezeichnung == "Caterer").Count > 0)
            {
                try
                {
                    dbBenutzer.Koordinaten = GoogleService.FindeLocationByAdress(dbBenutzer.Postleitzahl, dbBenutzer.Straße, dbBenutzer.Ort);
                }
                catch
                {
                    throw new ArgumentException("Ungültige Adresse");
                }

                var config = ConfigService.GetConfig();
                TimeSpan ts = DateTime.Now - dbBenutzer.LetzteÄnderung;
                if (ts.TotalHours >= config.ZeitInStundendÄnderungsverfolgung)
                {
                    if (config.AenderungsVerfolgungCatererAktiviert)
                    {
                        MailService.SendInfoMailEditCatererToEmployee(config, dbBenutzer, BenutzerRepository.SearchAllUserByUserGroupWithPagingOrderByCategory(1, 10000000, new List<string>() { "Mitarbeiter", "Administrator" }, "BenutzerId"));
                    }
                    dbBenutzer.LetzteÄnderung = DateTime.Now;
                }

            }
            else {
                dbBenutzer.LetzteÄnderung = DateTime.Now;
            }
          

            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void EditCaterer(Benutzer editedBenutzer)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);
            MailService.SendEditCatererMail(ConfigService.GetConfig(), dbBenutzer.Mail);
            Mapper.Map(editedBenutzer, dbBenutzer);
            try
            {
                dbBenutzer.Koordinaten = GoogleService.FindeLocationByAdress(dbBenutzer.Postleitzahl, dbBenutzer.Straße, dbBenutzer.Ort);
            }
            catch
            {
                throw new ArgumentException("Ungültige Adresse");
            }
          
            BenutzerRepository.EditUser(dbBenutzer);
        }

        public void RemoveCaterer(int id)
        {
            var benutzer = BenutzerRepository.SearchUserById(id);
            MailService.SendRemoveCatererMail(ConfigService.GetConfig(), benutzer.Mail);
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
            benutzer.IstEmailVerifiziert = true;
            BenutzerRepository.EditUser(benutzer);
        }

        public int GetMitarbeiterCount()
        {
            return BenutzerRepository.GetMitarbeiterCount();
        }

        public int GetAdminCount()
        {
            return BenutzerRepository.GetAdminCount();
        }

        public int GetCatererCount()
        {
            return BenutzerRepository.GetCatererCount();
        }

        public void DokumentDrucken(Benutzer benutzer, MemoryStream memoryStream)
        {

            DocumentService.DokumentDrucken(benutzer, memoryStream);



        }
    }
}
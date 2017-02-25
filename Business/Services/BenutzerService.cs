using Business.Interfaces;
using System;
using DataAccess.Model;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System.Collections.Generic;
using Common.Interfaces;
using AutoMapper;

namespace Business.Services
{
    public class BenutzerService : IBenutzerService
    {
        public IBenutzerRepository BenutzerRepository { get; set; }

        public IBenutzerGruppeService BenutzerGruppeService { get; set; }

        public IMailService MailService { get; set; }

        public IMd5Hash MD5Hash { get; set; }

        private IMapper Mapper { get; set; }


        public BenutzerService(IBenutzerRepository benutzerRepository, IMailService mailService,IBenutzerGruppeService benutzerGruppeService, IMd5Hash md5Hash)
        {
            BenutzerRepository = benutzerRepository;
            BenutzerGruppeService = benutzerGruppeService;
            MailService = mailService;
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

        public List<Benutzer> FindAllMitarbeiterWithPaging(int aktuelleSeite, int seitenGroesse)
        {
            return BenutzerRepository.SearchAllMitarbeiterWithPaging(aktuelleSeite, seitenGroesse);
        }


        public void AddBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
        }


        public void AddMitarbeiter(Benutzer benutzer, string mitarbeiterGruppe)
        {
            benutzer.BenutzerGruppen = new List<BenutzerGruppe>() {BenutzerGruppeService.SearchGroupByBezeichnung(mitarbeiterGruppe)};
            benutzer.IstEmailVerifiziert = true;
            benutzer.PasswortZeitstempel = DateTime.Now;

            BenutzerRepository.AddUser(benutzer);

            benutzer = BenutzerRepository.SearchUserByEMail(benutzer.Mail);
            benutzer.PasswordVerificationCode = MD5Hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname + benutzer.Passwort);
            benutzer.PasswortZeitstempel = DateTime.Now;
           
            BenutzerRepository.EditUser(benutzer);

            MailService.SendNewMitarbeiterMail(benutzer.PasswordVerificationCode, benutzer.Mail, benutzer.BenutzerId.ToString());

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

        public void EditBenutzer(Benutzer editedBenutzer)
        {
            var dbBenutzer = BenutzerRepository.SearchUserById(editedBenutzer.BenutzerId);

            Mapper.Map(editedBenutzer,dbBenutzer);
            BenutzerRepository.EditUser(dbBenutzer);
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
                if (benutzer?.PasswordVerificationCode == verify && ts.Minutes < 120 )
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
            BenutzerRepository.EditUser(benutzer);
        }

        public int GetMitarbeiterCount()
        {
            return BenutzerRepository.GetMitarbeiterCount();
        }
    }
}

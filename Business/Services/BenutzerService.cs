using Business.Interfaces;
using System;
using DataAccess.Model;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System.Collections.Generic;
using Common.Interfaces;

namespace Business.Services
{
    public class BenutzerService : IBenutzerService
    {
        public IBenutzerRepository BenutzerRepository { get; set; }

        public IMailService MailService { get; set; }

        public BenutzerService(IBenutzerRepository benutzerRepository, IMailService mailService)
        {
            BenutzerRepository = benutzerRepository;
            MailService = mailService;

        }


        public Benutzer SearchUserById(int id)
        {
            return BenutzerRepository.SearchUserById(id);
        }

        public Benutzer SearchUserByEmail(string email)
        {
            return BenutzerRepository.SearchUserByEMail(email);
        }

        public List<Benutzer> FindAllBenutzers()
        {
            return BenutzerRepository.SearchUser();
        }

        public void AddBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
        }

        public void RegisterBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
            MailService.SendRegisterMail(benutzer.EMailVerificationCode,benutzer.Mail,benutzer.BenutzerId.ToString());
        }

        public void EditBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.EditUser(benutzer);
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
            if (benutzer.EMailVerificationCode == verify){
                benutzer.IstEmailVerifiziert = true;
                BenutzerRepository.EditUser(benutzer);
                return true;
            }
            return false;
        }

      
    }
}

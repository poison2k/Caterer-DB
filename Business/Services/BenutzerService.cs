using Business.Interfaces;
using System;
using DataAccess.Model;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace Business.Services
{
    public class BenutzerService : IBenutzerService
    {
        public IBenutzerRepository BenutzerRepository { get; set; }

        public BenutzerService(IBenutzerRepository benutzerRepository)
        {
            BenutzerRepository = benutzerRepository;

        }


        public Benutzer SearchUserById(int id)
        {
            return BenutzerRepository.SearchUserById(id);
        }

        public List<Benutzer> FindAllBenutzers()
        {
            return BenutzerRepository.SearchUser();
        }

        public void AddBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.AddUser(benutzer);
        }

        public void EditBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.EditUser(benutzer);
        }

        public void RemoveBenutzer(Benutzer benutzer)
        {
            BenutzerRepository.RemoveUser(benutzer);
        }
    }
}

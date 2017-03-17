using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SparteService : ISparteService
    {

        public ISparteRepository SparteRepository { get; set; }

        public SparteService(ISparteRepository sparteRepository)
        {
            SparteRepository = sparteRepository;

        }

        public void AddSparte(Sparte sparte)
        {
            SparteRepository.AddSparte(sparte);
        }

        public void EditSparte(Sparte sparte)
        {
            SparteRepository.EditSparte(sparte);
        }

        public List<Sparte> FindAlleSparten()
        {
            return SparteRepository.SearchSparte();
        }

        public void RemoveSparte(int id)
        {
            SparteRepository.RemoveSparte(SparteRepository.SearchSparteById(id));
        }

        public Sparte SearchSparteById(int id)
        {
            return SparteRepository.SearchSparteById(id);
        }

        public Sparte SearchSparteByName(string name)
        {
            return SparteRepository.SearchSparteByName(name);
        }
    }
}

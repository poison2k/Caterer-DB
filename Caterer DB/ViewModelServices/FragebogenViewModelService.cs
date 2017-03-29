using AutoMapper;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;

namespace Caterer_DB.Models.ViewModelServices
{
    public class FragebogenViewModelService : IFragebogenViewModelService
    {
        private IMapper Mapper { get; set; }

        public FragebogenViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                    cfg.CreateMap<FragebogenViewModelService, FragebogenViewModelService>().ReverseMap();
                });

            Mapper = config.CreateMapper();
        }

        public FragebogenViewModelService Map_FragebogenViewModelService_FragebogenViewModelService(FragebogenViewModelService fragebogenViewModelService)
        {
            return Mapper.Map<FragebogenViewModelService>(fragebogenViewModelService);
        }

        public BearbeiteFragebogenViewModel Map_Fragen_BearbeiteFragebogenViewModel(List<List<Frage>> fragenListen, List<int> nutzerAntworten)
        {
            var bearbeiteFragebogenViewModel = new BearbeiteFragebogenViewModel()
            {
                Id = 1,
                Fragen = new List<FragenNachThemengebiet>()
            };

            foreach (List<Frage> fragen in fragenListen)
            {
                List<FragenViewModel> fragenViewModel = new List<FragenViewModel>();
                foreach (Frage frage in fragen)
                {
                    int antwortResultId = -1;
                    foreach (int antwortId in nutzerAntworten)
                    {
                        if (frage.IstMultiSelect != true)
                        {
                            foreach (Antwort antwort in frage.Antworten)
                            {
                                if (antwort.AntwortId == antwortId)
                                {
                                    antwortResultId = antwort.AntwortId;
                                }
                            }
                        }
                        else
                        {
                            foreach (Antwort antwort in frage.Antworten)
                            {
                                if (antwort.AntwortId == antwortId)
                                {
                                    antwort.IsChecked = true;
                                }
                            }
                        }
                    }

                    fragenViewModel.Add(new FragenViewModel()
                    {
                        Antworten = frage.Antworten,
                        ID = frage.FrageId,
                        Text = frage.Bezeichnung,
                        GegebeneAntwort = antwortResultId,
                        IstMultiSelect = frage.IstMultiSelect
                    });
                }

                FragenNachThemengebiet fragenNachThemengebiet = new FragenNachThemengebiet()
                {
                    Questions = fragenViewModel,
                    Name = fragen[0].Kategorie.Bezeichnung,
                    ID = 1
                };
                bearbeiteFragebogenViewModel.Fragen.Add(fragenNachThemengebiet);
            }

            return bearbeiteFragebogenViewModel;
        }

        public List<int> Map_BearbeiteFragebogenViewModel_BenutzerResultSet(BearbeiteFragebogenViewModel bearbeitefragebogenviewmodel)
        {
            var antwortIDs = new List<int>();
            foreach (FragenNachThemengebiet fragenNachThemengebiet in bearbeitefragebogenviewmodel.Fragen)
            {
                foreach (FragenViewModel frage in fragenNachThemengebiet.Questions)
                {
                    foreach (Antwort antwort in frage.Antworten)
                    {
                        if (antwort.AntwortId == frage.GegebeneAntwort || antwort.IsChecked)
                        {
                            antwortIDs.Add(antwort.AntwortId);
                        }
                    }
                }
            }

            return antwortIDs;
        }
    }
}
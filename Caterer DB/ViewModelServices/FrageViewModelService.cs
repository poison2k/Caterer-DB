using AutoMapper;
using Caterer_DB.Interfaces;
using Common.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Caterer_DB.Models.ViewModelServices
{
    public class FrageViewModelService : IFrageViewModelService
    {
        private IMapper Mapper { get; set; }

        public FrageViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Frage, CreateFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, EditFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, DeleteFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, DetailsFrageViewModel>().ReverseMap();
                cfg.CreateMap<Frage, IndexFrageViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public ListViewModel<IndexFrageViewModel> GeneriereListViewModel(List<Frage> fragenListe, int gesamtAnzahlDatensätze, int aktuelleSeite = 1, int seitenGröße = 10)
        {
            var listViewModel = new ListViewModel<IndexFrageViewModel>(gesamtAnzahlDatensätze, aktuelleSeite, seitenGröße);
            foreach (var frage in fragenListe)
                listViewModel.Entitäten.Add(GeneriereIndexFrageViewModel(frage));

            return listViewModel;
        }

        public IndexFrageViewModel GeneriereIndexFrageViewModel(Frage frage)
        {
            var indexFrageViewModel = Mapper.Map<IndexFrageViewModel>(frage);

            return indexFrageViewModel;
        }

        public Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel)
        {
            return Mapper.Map<Frage>(createFrageViewModel);
        }

        public Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel)
        {
            return Mapper.Map<Frage>(editFrageViewModel);
        }

        public CreateFrageViewModel CreateCreateFrageViewModel(List<Kategorie> kategorien)
        {
            var createFrageViewModel = new CreateFrageViewModel()
            {
                Antworten = new List<Antwort>()
            };
            return AddListsToCreateFrageViewModel(createFrageViewModel, kategorien);
        }

        public EditFrageViewModel Map_Frage_EditFrageViewModel(Frage frage, List<Kategorie> kategorien)
        {
            var editFrageViewModel = Mapper.Map<EditFrageViewModel>(frage);
            editFrageViewModel.KategorieName = frage.Kategorie.Bezeichnung;
            editFrageViewModel.KategorieId = frage.Kategorie.KategorieId;
            return AddListsToEditFrageViewModel(editFrageViewModel, kategorien);
        }

        public DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage frage)
        {
            return Mapper.Map<DetailsFrageViewModel>(frage);
        }

        public Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel)
        {
            return Mapper.Map<Frage>(deleteFrageViewModel);
        }

        public DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage frage)
        {
            return Mapper.Map<DeleteFrageViewModel>(frage);
        }

        public CreateFrageViewModel AddListsToCreateFrageViewModel(CreateFrageViewModel createFrageViewModel, List<Kategorie> kategorien)
        {
            createFrageViewModel.JaNein = CreateJaNeinSelectList();

            createFrageViewModel.Kategorien = CreateKategorienSelectList(kategorien);

            return createFrageViewModel;
        }

        public EditFrageViewModel AddListsToEditFrageViewModel(EditFrageViewModel editFrageViewModel, List<Kategorie> kategorien)
        {
            editFrageViewModel.JaNein = CreateJaNeinSelectList();

            editFrageViewModel.Kategorien = CreateKategorienSelectList(kategorien);

            return editFrageViewModel;
        }

        private SelectList CreateJaNeinSelectList()
        {
            return new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Nein", Value = "false" },
                                new SelectListItem { Text = "Ja", Value = "true" }
                            }, "Value", "Text");
        }

        private SelectList CreateKategorienSelectList(List<Kategorie> kategorien)
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Text = "Bitte wählen...", Value = "0" });

            foreach (Kategorie kategorie in kategorien)
            {
                selectListItems.Add(new SelectListItem { Text = kategorie.Bezeichnung, Value = kategorie.KategorieId.ToString() });
            }

            return new SelectList(selectListItems, "Value", "Text");
        }

        public List<AjaxAntwort> WandleAntworteninAjaxAntworten(List<Antwort> antworten)
        {
            return antworten.Select(antwort => new AjaxAntwort
            {
                AntwortId = antwort.AntwortId,
                Antworttext = antwort.Bezeichnung
            }).ToList();
        }
    }
}
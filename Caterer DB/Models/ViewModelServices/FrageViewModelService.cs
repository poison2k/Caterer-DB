using AutoMapper;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
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
               

            });

            Mapper = config.CreateMapper();

        }

        public Frage Map_CreateFrageViewModel_Frage(CreateFrageViewModel createFrageViewModel)
        {
            return Mapper.Map<Frage>(createFrageViewModel);
        }

        public Frage Map_EditFrageViewModel_Frage(EditFrageViewModel editFrageViewModel)
        {
            return Mapper.Map<Frage>(editFrageViewModel);
        }

        public CreateFrageViewModel CreateCreateFrageViewModel(List<Sparte> sparten)
        {
            var createFrageViewModel = new CreateFrageViewModel() {
                Antworten = new List<Antwort>()
            };
            return AddListsToCreateFrageViewModel( createFrageViewModel ,sparten);
        }

        public EditFrageViewModel Map_Frage_EditFrageViewModel(Frage Frage, List<Sparte> sparten)
        {
            var editFrageViewModel = Mapper.Map<EditFrageViewModel>(Frage);
            editFrageViewModel.SpartenName = Frage.Sparte.Bezeichnung;
            return AddListsToEditFrageViewModel(editFrageViewModel, sparten);
        }

        public DetailsFrageViewModel Map_Frage_DetailsFrageViewModel(Frage Frage)
        {
            return Mapper.Map<DetailsFrageViewModel>(Frage);
        }

        public Frage Map_DeleteFrageViewModel_Frage(DeleteFrageViewModel deleteFrageViewModel)
        {
            return Mapper.Map<Frage>(deleteFrageViewModel);
        }

        public DeleteFrageViewModel Map_Frage_DeleteFrageViewModel(Frage Frage)
        {
            return Mapper.Map<DeleteFrageViewModel>(Frage);
        }


        public CreateFrageViewModel AddListsToCreateFrageViewModel(CreateFrageViewModel createFrageViewModel, List<Sparte> sparten)
        {
            createFrageViewModel.JaNein = CreateJaNeinSelectList();

            createFrageViewModel.Sparten = CreateSpartenSelectList(sparten);

            return createFrageViewModel;
        }

        public EditFrageViewModel AddListsToEditFrageViewModel(EditFrageViewModel editFrageViewModel, List<Sparte> sparten)
        {
            editFrageViewModel.JaNein = CreateJaNeinSelectList();

            editFrageViewModel.Sparten = CreateSpartenSelectList(sparten);

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

        private SelectList CreateSpartenSelectList(List<Sparte> sparten)
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Text = "Bitte wählen...", Value = String.Empty });

            foreach (Sparte sparte in sparten) {
                selectListItems.Add(new SelectListItem { Text = sparte.Bezeichnung, Value = sparte.Bezeichnung });
            }
           
            return new SelectList(selectListItems, "Value", "Text"); 
        }
    }
}
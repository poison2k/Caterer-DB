using AutoMapper;
using Caterer_DB.Interfaces;
using Common.Model;
using System.Collections.Generic;

namespace Caterer_DB.Models.ViewModelServices
{
    public class KategorieViewModelService : IKategorieViewModelService
    {
        private IMapper Mapper { get; set; }

        public KategorieViewModelService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Kategorie, CreateKategorieViewModel>().ReverseMap();
                cfg.CreateMap<Kategorie, EditKategorieViewModel>().ReverseMap();
                cfg.CreateMap<Kategorie, DeleteKategorieViewModel>().ReverseMap();
                cfg.CreateMap<Kategorie, DetailsKategorieViewModel>().ReverseMap();
                cfg.CreateMap<Kategorie, IndexKategorieViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public Kategorie Map_CreateKategorieViewModel_Kategorie(CreateKategorieViewModel createKategorieViewModel)
        {
            return Mapper.Map<Kategorie>(createKategorieViewModel);
        }

        public Kategorie Map_EditKategorieViewModel_Kategorie(EditKategorieViewModel editKategorieViewModel)
        {
            return Mapper.Map<Kategorie>(editKategorieViewModel);
        }

        public EditKategorieViewModel Map_Kategorie_EditKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie)
        {
            var editKategorieViewModel = Mapper.Map<EditKategorieViewModel>(kategorie);
            editKategorieViewModel.Fragen = fragenZuKategorie;
            return editKategorieViewModel;
        }

        public Kategorie Map_IndexKategorieViewModel_Kategorie(IndexKategorieViewModel indexKategorieViewModel)
        {
            return Mapper.Map<Kategorie>(indexKategorieViewModel);
        }

        public IndexKategorieViewModel Map_Kategorie_IndexKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie)
        {
            var indexKategorieViewModel = Mapper.Map<IndexKategorieViewModel>(kategorie);
            indexKategorieViewModel.Fragen = fragenZuKategorie;
            return indexKategorieViewModel;
        }

        public DetailsKategorieViewModel Map_Kategorie_DetailsKategorieViewModel(Kategorie kategorie, List<Frage> fragenZuKategorie)
        {
            var detailsKategorieViewModel = Mapper.Map<DetailsKategorieViewModel>(kategorie);
            detailsKategorieViewModel.Fragen = fragenZuKategorie;
            return detailsKategorieViewModel;
        }

        public Kategorie Map_DeleteKategorieViewModel_Kategorie(DeleteKategorieViewModel deleteKategorieViewModel)
        {
            return Mapper.Map<Kategorie>(deleteKategorieViewModel);
        }

        public DeleteKategorieViewModel Map_Kategorie_DeleteKategorieViewModel(Kategorie kategorie)
        {
            return Mapper.Map<DeleteKategorieViewModel>(kategorie);
        }
    }
}
using AutoMapper;
using Business.Interfaces;
using Caterer_DB.Interfaces;
using DataAccess.Model;
using System.Web.Helpers;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerViewModelService : IBenutzerViewModelService
    {
        private IMapper Mapper { get; set; }
        private IBenutzerService BenutzerService { get; set; }

        public BenutzerViewModelService(IBenutzerService benutzerService)
        {
            BenutzerService = benutzerService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsVirtual;
                cfg.CreateMap<Benutzer, CreateBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, EditBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DeleteBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DetailsBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, AnmeldenBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, RegisterBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, MyDataBenutzerViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(Benutzer benutzer)
        {
            var anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();

            if (benutzer != null)
            {
                anmeldenBenutzerViewModel = Mapper.Map<AnmeldenBenutzerViewModel>(benutzer);
            }

            return anmeldenBenutzerViewModel;
        }

        public AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(int benutzerId = -1, string infobox = "")
        {
            var anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();

            if (infobox == "schliessen")
                anmeldenBenutzerViewModel.Infobox = "verbergen";
            else
                anmeldenBenutzerViewModel.Infobox = "anzeigen";

            Benutzer benutzer = BenutzerService.SearchUserById(benutzerId);
            if (benutzer != null)
            {
                anmeldenBenutzerViewModel = Mapper.Map(benutzer, anmeldenBenutzerViewModel);
            }

            return anmeldenBenutzerViewModel;
        }

        public Benutzer Map_CreateBenutzerViewModel_Benutzer(CreateBenutzerViewModel createBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(createBenutzerViewModel);
        }

        public Benutzer Map_EditBenutzerViewModel_Benutzer(EditBenutzerViewModel editBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(editBenutzerViewModel);
        }

        public Benutzer Map_MyDataBenutzerViewModel_Benutzer(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(myDataBenutzerViewModel);
        }

        public MyDataBenutzerViewModel Map_Benutzer_MyDataBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<MyDataBenutzerViewModel>(benutzer);
        }

        public EditBenutzerViewModel Map_Benutzer_EditBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<EditBenutzerViewModel>(benutzer);
        }

        public DetailsBenutzerViewModel Map_Benutzer_DetailsBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<DetailsBenutzerViewModel>(benutzer);
        }

        public Benutzer Map_DeleteBenutzerViewModel_Benutzer(DeleteBenutzerViewModel deleteBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(deleteBenutzerViewModel);
        }

        public DeleteBenutzerViewModel Map_Benutzer_DeleteBenutzerViewModel(Benutzer benutzer)
        {
            return Mapper.Map<DeleteBenutzerViewModel>(benutzer);
        }

        public Benutzer Map_RegisterBenutzerViewModel_Benutzer(RegisterBenutzerViewModel registerBenutzerViewModel)
        {
            var benutzer = Mapper.Map<Benutzer>(registerBenutzerViewModel);
            benutzer.Passwort = Crypto.HashPassword(registerBenutzerViewModel.Passwort);
            return benutzer;
        }
    }
}
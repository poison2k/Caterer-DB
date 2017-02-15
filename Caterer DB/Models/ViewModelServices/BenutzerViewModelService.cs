using AutoMapper;
using Business.Interfaces;
using Caterer_DB.Interfaces;
using Common.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerViewModelService : IBenutzerViewModelService
    {
        private IMapper Mapper { get; set; }
        private IMd5Hash MD5hash { get; set; }
        private IBenutzerService BenutzerService { get; set; }

        public BenutzerViewModelService(IBenutzerService benutzerService, IMd5Hash md5Hash)
        {
            MD5hash = md5Hash;
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
                cfg.CreateMap<Benutzer, ForgottenPasswordRequestViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, ForgottenPasswordCreateNewPasswordViewModel>().ReverseMap();
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

        public Benutzer Map_ForgottenPasswordRequestViewModel_Benutzer(ForgottenPasswordRequestViewModel forgottenPasswordRequestViewModel)
        {

            return Mapper.Map<Benutzer>(forgottenPasswordRequestViewModel);
        }

        public Benutzer Map_ForgottenPasswordCreateNewPasswordViewModel_Benutzer(ForgottenPasswordCreateNewPasswordViewModel forgottenPasswordCreateNewPasswordViewModel)
        {
            var benutzer = Mapper.Map<Benutzer>(forgottenPasswordCreateNewPasswordViewModel);
            benutzer.Passwort = Crypto.HashPassword(forgottenPasswordCreateNewPasswordViewModel.Passwort);
            return benutzer;
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
            var myDataBenutzerViewModel = Mapper.Map<MyDataBenutzerViewModel>(benutzer);

            myDataBenutzerViewModel = AddListsToMyDataViewModel(myDataBenutzerViewModel);
            return myDataBenutzerViewModel;
        }

        public ForgottenPasswordRequestViewModel Map_Benutzer_ForgottenPasswordRequestViewModel(Benutzer benutzer)
        {
            return Mapper.Map<ForgottenPasswordRequestViewModel>(benutzer);
        }

        public ForgottenPasswordCreateNewPasswordViewModel Map_Benutzer_ForgottenPasswordCreateNewPasswordViewModel(Benutzer benutzer)
        {
            return Mapper.Map<ForgottenPasswordCreateNewPasswordViewModel>(benutzer);
        }

        public ForgottenPasswordCreateNewPasswordViewModel Get_ForgottenPasswordCreateNewPasswordViewModel_ByBenutzerId(int id)
        {

            var benutzer = BenutzerService.SearchUserById(id);
            benutzer.Passwort = "";
            return Mapper.Map<ForgottenPasswordCreateNewPasswordViewModel>(benutzer);
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
            benutzer.EMailVerificationCode = MD5hash.CalculateMD5Hash(benutzer.BenutzerId + benutzer.Mail + benutzer.Nachname + benutzer.Vorname);
            return benutzer;
        }

        public RegisterBenutzerViewModel CreateNewRegisterBenutzerViewModel()
        {
            var registerBenutzerViewModel = new RegisterBenutzerViewModel();

            registerBenutzerViewModel = AddListsToRegisterViewModel(registerBenutzerViewModel);
            return registerBenutzerViewModel;
        }

        public RegisterBenutzerViewModel AddListsToRegisterViewModel(RegisterBenutzerViewModel registerBenutzerViewModel)
        {
            registerBenutzerViewModel.Anreden = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Herr", Value = "Herr" },
                                new SelectListItem { Text = "Frau", Value = "Frau" }
                            }, "Value", "Text");

            registerBenutzerViewModel.Lieferumkreise = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Nur im eigenen Stadtgebiet", Value = "Nur im eigenen Stadtgebiet" },
                                new SelectListItem { Text = "Bis 30 km", Value = "Bis 30 km" },
                                new SelectListItem { Text = "Bis 50 km", Value = "Bis 50 km" },
                                new SelectListItem { Text = "Bis 50 - 100 km", Value = "Bis 50 - 100 km" },
                                new SelectListItem { Text = "Deutschlandweit", Value = "Deutschlandweit" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" },
                            }, "Value", "Text");

            registerBenutzerViewModel.Organisationsformen = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Mensaverein", Value = "Mensaverein" },
                                new SelectListItem { Text = "Caterer", Value = "Caterer" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" }
                            }, "Value", "Text");
            return registerBenutzerViewModel;
        }


        public MyDataBenutzerViewModel AddListsToMyDataViewModel(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            myDataBenutzerViewModel.Anreden = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Herr", Value = "Herr" },
                                new SelectListItem { Text = "Frau", Value = "Frau" }
                            }, "Value", "Text");

            myDataBenutzerViewModel.Lieferumkreise = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Nur im eigenen Stadtgebiet", Value = "Nur im eigenen Stadtgebiet" },
                                new SelectListItem { Text = "Bis 30 km", Value = "Bis 30 km" },
                                new SelectListItem { Text = "Bis 50 km", Value = "Bis 50 km" },
                                new SelectListItem { Text = "Bis 50 - 100 km", Value = "Bis 50 - 100 km" },
                                new SelectListItem { Text = "Deutschlandweit", Value = "Deutschlandweit" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" },
                            }, "Value", "Text");

            myDataBenutzerViewModel.Organisationsformen = new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Mensaverein", Value = "Mensaverein" },
                                new SelectListItem { Text = "Caterer", Value = "Caterer" },
                                new SelectListItem { Text = "Sonstiges", Value = "Sonstiges" }
                            }, "Value", "Text");
            return myDataBenutzerViewModel;
        }

       


    }
}
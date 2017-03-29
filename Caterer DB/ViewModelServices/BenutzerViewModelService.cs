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
                cfg.CreateMap<Benutzer, CreateMitarbeiterViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, EditBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DeleteBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DetailsBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, AnmeldenBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, RegisterBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, MyDataBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, ForgottenPasswordRequestViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, ForgottenPasswordCreateNewPasswordViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, IndexBenutzerViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, IndexCatererViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, CreateCatererViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, DetailsCatererViewModel>().ReverseMap();
                cfg.CreateMap<Benutzer, MeineDatenBenutzerViewModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }

        public AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(Benutzer benutzer, List<List<Frage>> fragenListen)
        {
            var anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();

            if (benutzer != null)
            {
                anmeldenBenutzerViewModel = Mapper.Map<AnmeldenBenutzerViewModel>(benutzer);
            }

            foreach (List<Frage> fragen in fragenListen)
            {
                int beantwortetCounter = 0;
                int fragencounter = 0;
                foreach (Frage frage in fragen)
                {
                    bool beantwortet = false;
                    foreach (int antwortId in benutzer.AntwortIDs)
                    {
                        if (frage.IstMultiSelect != true)
                        {

                            foreach (Antwort antwort in frage.Antworten)
                            {
                                if (antwort.AntwortId == antwortId)
                                {
                                    beantwortet = true;
                                }
                            }
                        }
                        else
                        {
                            foreach (Antwort antwort in frage.Antworten)
                            {
                                if (antwort.AntwortId == antwortId)
                                {
                                    beantwortet = true;
                                }
                            }
                        }
                    }
                    if (beantwortet)
                    {
                        beantwortetCounter++;
                    }
                    fragencounter++;
                }
                anmeldenBenutzerViewModel.OffeneFragen = fragencounter - beantwortetCounter;
            }
            return anmeldenBenutzerViewModel;
        }

        public AnmeldenBenutzerViewModel GeneriereAnmeldenBenutzerViewModel(int benutzerId = -1, List<List<Frage>> fragenListen = null)
        {
            var anmeldenBenutzerViewModel = new AnmeldenBenutzerViewModel();
            anmeldenBenutzerViewModel.AnmeldenModel = new LoginModel();

            Benutzer benutzer = BenutzerService.SearchUserById(benutzerId);
            if (benutzer != null)
            {
                anmeldenBenutzerViewModel = Mapper.Map(benutzer, anmeldenBenutzerViewModel);
            }
            if (fragenListen != null)
            {
                int fragencounter = 0;
                int beantworteteCounter = 0;
                foreach (List<Frage> fragen in fragenListen)
                {
                    foreach (Frage frage in fragen)
                    {
                        bool beantwortet = false;
                        foreach (int antwortId in benutzer.AntwortIDs)
                        {
                            if (frage.IstMultiSelect != true)
                            {

                                foreach (Antwort antwort in frage.Antworten)
                                {
                                    if (antwort.AntwortId == antwortId)
                                    {
                                        beantwortet = true;
                                    }
                                }
                            }
                            else
                            {
                                foreach (Antwort antwort in frage.Antworten)
                                {
                                    if (antwort.AntwortId == antwortId)
                                    {
                                        beantwortet = true;
                                    }
                                }
                            }
                        }
                        if (beantwortet)
                        {
                            beantworteteCounter++;
                        }
                        fragencounter++;
                    }
                  
                }
                anmeldenBenutzerViewModel.OffeneFragen = fragencounter - beantworteteCounter;
            }
            return anmeldenBenutzerViewModel;
        }

        public Benutzer Map_CreateMitarbeiterViewModel_Benutzer(CreateMitarbeiterViewModel createMitarbeiterViewModel)
        {
            return Mapper.Map<Benutzer>(createMitarbeiterViewModel);
        }

        public Benutzer Map_CreateCatererViewModel_Benutzer(CreateCatererViewModel createCatererViewModel)
        {
            return Mapper.Map<Benutzer>(createCatererViewModel);
        }

        public Benutzer Map_ForgottenPasswordRequestViewModel_Benutzer(ForgottenPasswordRequestViewModel forgottenPasswordRequestViewModel)
        {
            return Mapper.Map<Benutzer>(forgottenPasswordRequestViewModel);
        }

        public Benutzer Map_ForgottenPasswordCreateNewPasswordViewModel_Benutzer(ForgottenPasswordCreateNewPasswordViewModel forgottenPasswordCreateNewPasswordViewModel)
        {
            var benutzer = Mapper.Map<Benutzer>(forgottenPasswordCreateNewPasswordViewModel);
            //ToDo in Hash in Business Layer verschieben
            benutzer.Passwort = Crypto.HashPassword(forgottenPasswordCreateNewPasswordViewModel.Passwort);
            benutzer.PasswordVerificationCode = "";
            return benutzer;
        }

        public Benutzer Map_EditBenutzerViewModel_Benutzer(EditBenutzerViewModel editBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(editBenutzerViewModel);
        }

        public Benutzer Map_MeineDatenBenutzerViewModel_Benutzer(MeineDatenBenutzerViewModel meineDatenBenutzerViewModel)
        {
            return Mapper.Map<Benutzer>(meineDatenBenutzerViewModel);
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
            var editBenutzerViewModel = Mapper.Map<EditBenutzerViewModel>(benutzer);
            editBenutzerViewModel.IstAdmin = "false";
            foreach (BenutzerGruppe benutzergruppe in benutzer.BenutzerGruppen)
            {
                if (benutzergruppe.Bezeichnung == "Administrator")
                {
                    editBenutzerViewModel.IstAdmin = "true";
                }
            }
            return AddListsToEditViewModel(editBenutzerViewModel);
        }

        public MeineDatenBenutzerViewModel Map_Benutzer_MeineDatenBenutzerViewModel(Benutzer benutzer)
        {
            var meineDatenBenutzerViewModel = Mapper.Map<MeineDatenBenutzerViewModel>(benutzer);

            return AddListsToMeineDatenViewModel(meineDatenBenutzerViewModel);
        }

        public DetailsBenutzerViewModel Map_Benutzer_DetailsBenutzerViewModel(Benutzer benutzer)
        {
            var detailsBenutzerViewModel = Mapper.Map<DetailsBenutzerViewModel>(benutzer);
            detailsBenutzerViewModel.IstAdmin = false;
            foreach (BenutzerGruppe benutzergruppe in benutzer.BenutzerGruppen)
            {
                if (benutzergruppe.Bezeichnung == "Administrator")
                {
                    detailsBenutzerViewModel.IstAdmin = true;
                }
            }
            return detailsBenutzerViewModel;
        }

        public DetailsCatererViewModel Map_Benutzer_DetailsCatererViewModel(Benutzer benutzer)
        {
            return Mapper.Map<DetailsCatererViewModel>(benutzer);
        }

        public CreateMitarbeiterViewModel CreateNewCreateMitarbeiterViewModel()
        {
            return AddListsToCreateViewModel(new CreateMitarbeiterViewModel());
        }

        public CreateCatererViewModel CreateNewCreateCatererViewModel()
        {
            return AddListsToCreateCatererViewModel(new CreateCatererViewModel());
        }

        public CreateMitarbeiterViewModel UpdateCreateMitarbeiterViewModel(CreateMitarbeiterViewModel createMitarbeiterViewModel)
        {
            return AddListsToCreateViewModel(createMitarbeiterViewModel);
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
            //ToDo in Hash in Business Layer verschieben
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

        public ListViewModel<IndexBenutzerViewModel> GeneriereListViewModel(List<Benutzer> benutzerListe, int gesamtAnzahlDatensätze, int aktuelleSeite = 1, int seitenGröße = 10)
        {
            var listViewModel = new ListViewModel<IndexBenutzerViewModel>(gesamtAnzahlDatensätze, aktuelleSeite, seitenGröße);
            foreach (var benutzer in benutzerListe)
                listViewModel.Entitäten.Add(GeneriereIndexBenutzerViewModel(benutzer));

            return listViewModel;
        }

        public ListViewModel<IndexCatererViewModel> GeneriereListViewModelCaterer(List<Benutzer> benutzerListe, int gesamtAnzahlDatensätze, int aktuelleSeite = 1, int seitenGröße = 10)
        {
            var listViewModel = new ListViewModel<IndexCatererViewModel>(gesamtAnzahlDatensätze, aktuelleSeite, seitenGröße);
            foreach (var benutzer in benutzerListe)
                listViewModel.Entitäten.Add(GeneriereIndexCatererViewModel(benutzer));

            return listViewModel;
        }

        public IndexBenutzerViewModel GeneriereIndexBenutzerViewModel(Benutzer benutzer)
        {
            var indexBenutzerViewModel = Mapper.Map<IndexBenutzerViewModel>(benutzer);
            var istAdmin = false;
            foreach (BenutzerGruppe benutzerGruppe in benutzer.BenutzerGruppen)
            {
                if (benutzerGruppe.Bezeichnung == "Administrator")
                {
                    istAdmin = true;
                }
            }
            indexBenutzerViewModel.IstAdmin = istAdmin;
            return indexBenutzerViewModel;
        }

        public IndexCatererViewModel GeneriereIndexCatererViewModel(Benutzer benutzer)
        {
            var indexCatererViewModel = Mapper.Map<IndexCatererViewModel>(benutzer);

            return indexCatererViewModel;
        }

        public CreateMitarbeiterViewModel AddListsToCreateViewModel(CreateMitarbeiterViewModel createBenutzerViewModel)
        {
            createBenutzerViewModel.Anreden = CreateAnredenSelectList();
            createBenutzerViewModel.JaNein = CreateJaNeinSelectList();
            return createBenutzerViewModel;
        }

        public MeineDatenBenutzerViewModel AddListsToMeineDatenViewModel(MeineDatenBenutzerViewModel meineDatenBenutzerViewModel)
        {
            meineDatenBenutzerViewModel.Anreden = CreateAnredenSelectList();

            return meineDatenBenutzerViewModel;
        }

        public EditBenutzerViewModel AddListsToEditViewModel(EditBenutzerViewModel editBenutzerViewModel)
        {
            editBenutzerViewModel.Anreden = CreateAnredenSelectList();
            editBenutzerViewModel.JaNein = CreateJaNeinSelectList();
            return editBenutzerViewModel;
        }

        public CreateCatererViewModel AddListsToCreateCatererViewModel(CreateCatererViewModel createCatererViewModel)
        {
            createCatererViewModel.Anreden = CreateAnredenSelectList();

            createCatererViewModel.Lieferumkreise = CreateLieferumkreisSelectList();

            createCatererViewModel.Organisationsformen = CreateOrganisationsformenSelectList();

            return createCatererViewModel;
        }

        public RegisterBenutzerViewModel AddListsToRegisterViewModel(RegisterBenutzerViewModel registerBenutzerViewModel)
        {
            registerBenutzerViewModel.Anreden = CreateAnredenSelectList();

            registerBenutzerViewModel.Lieferumkreise = CreateLieferumkreisSelectList();

            registerBenutzerViewModel.Organisationsformen = CreateOrganisationsformenSelectList();

            return registerBenutzerViewModel;
        }

        public MyDataBenutzerViewModel AddListsToMyDataViewModel(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            myDataBenutzerViewModel.Anreden = CreateAnredenSelectList();

            myDataBenutzerViewModel.Lieferumkreise = CreateLieferumkreisSelectList();

            myDataBenutzerViewModel.Organisationsformen = CreateOrganisationsformenSelectList();

            return myDataBenutzerViewModel;
        }

        private SelectList CreateAnredenSelectList()
        {
            return new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Herr", Value = "Herr" },
                                new SelectListItem { Text = "Frau", Value = "Frau" }
                            }, "Value", "Text");
        }

        private SelectList CreateJaNeinSelectList()
        {
            return new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Nein", Value = "false" },
                                new SelectListItem { Text = "Ja", Value = "true" }
                            }, "Value", "Text");
        }

        private SelectList CreateLieferumkreisSelectList()
        {
            return new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Bis 10 km", Value = "Bis 10 km" },
                                new SelectListItem { Text = "Bis 20 km", Value = "Bis 20 km" },
                                new SelectListItem { Text = "Bis 30 km", Value = "Bis 30 km" },
                                new SelectListItem { Text = "Bis 40 km", Value = "Bis 40 km" },
                                new SelectListItem { Text = "Bis 50 km", Value = "Bis 50 km" },
                                new SelectListItem { Text = "100 km +", Value = "100 km +" },
                            }, "Value", "Text");
        }

        private SelectList CreateOrganisationsformenSelectList()
        {
            return new SelectList(new List<SelectListItem>
                            {
                                new SelectListItem { Text = "Bitte wählen...", Value = String.Empty},
                                new SelectListItem { Text = "Mensaverein", Value = "Mensaverein" },
                                new SelectListItem { Text = "Caterer", Value = "Caterer" },
                            }, "Value", "Text");
        }
    }
}
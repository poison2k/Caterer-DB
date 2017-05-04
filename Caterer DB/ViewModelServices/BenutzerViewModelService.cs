using AutoMapper;
using Business.Interfaces;
using Caterer_DB.Interfaces;
using Common.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Caterer_DB.Models.ViewModelServices
{
    public class BenutzerViewModelService : IBenutzerViewModelService
    {
        private IMapper Mapper { get; set; }
        private IMd5Hash MD5hash { get; set; }
        private IBenutzerService BenutzerService { get; set; }

        private IFrageService FrageService { get; set; }

        public BenutzerViewModelService(IBenutzerService benutzerService, IMd5Hash md5Hash, IFrageService frageService)
        {
            MD5hash = md5Hash;
            BenutzerService = benutzerService;
            FrageService = frageService;
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

         public List<int> Map_MyDataBenutzerViewModel_BenutzerResultSet(MyDataBenutzerViewModel myDataBenutzerViewModel)
        {
            var antwortIDs = new List<int>();
            foreach (FragenNachThemengebiet fragenNachThemengebiet in myDataBenutzerViewModel.Fragen)
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
        public MyDataBenutzerViewModel Map_Benutzer_MyDataBenutzerViewModel(Benutzer benutzer, List<List<Frage>> fragenListen)
        {
            var myDataBenutzerViewModel = Mapper.Map<MyDataBenutzerViewModel>(benutzer);

            myDataBenutzerViewModel = AddListsToMyDataViewModel(myDataBenutzerViewModel);

            var nutzerAntworten = benutzer.AntwortIDs;

            myDataBenutzerViewModel.Fragen = new List<FragenNachThemengebiet>();

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
                                    antwortResultId--;
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
                myDataBenutzerViewModel.Fragen.Add(fragenNachThemengebiet);
            }
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
            meineDatenBenutzerViewModel.AdminCount = BenutzerService.GetAdminCount();

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

        public DetailsCatererViewModel Map_Benutzer_DetailsCatererViewModel(Benutzer benutzer, List<List<Frage>> fragenListen)
        {
            var detailsCatererViewModel = Mapper.Map<DetailsCatererViewModel>(benutzer);

            var nutzerAntworten = benutzer.AntwortIDs;

            detailsCatererViewModel.Fragen = new List<FragenNachThemengebiet>();

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
                                    antwortResultId--;
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
                detailsCatererViewModel.Fragen.Add(fragenNachThemengebiet);
            }
            return detailsCatererViewModel;
        }

        public Benutzer Map_DetailsCatererViewModel_Benutzer(DetailsCatererViewModel detailsCatererViewModel)
        {
            return Mapper.Map<Benutzer>(detailsCatererViewModel);
        }

        public VergleichCatererViewModel Map_ListBenutzer_VergleichCatererViewModel(List<Benutzer> caterer, List<List<Frage>> fragenListen) {

            var vergleichCatererViewModel = new VergleichCatererViewModel();
            vergleichCatererViewModel.caterer = new List<DetailsCatererViewModel>();
            vergleichCatererViewModel.Fragen = FrageService.FindAlleFragenNachKategorieninEigenenListen();
            foreach (Benutzer benutzer in caterer)
            {
                vergleichCatererViewModel.caterer.Add(Map_Benutzer_DetailsCatererViewModel(benutzer, FrageService.FindAlleFragenNachKategorieninEigenenListen()));
            }

            return vergleichCatererViewModel;
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
            benutzer.IstEmailVerifiziert = false;
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

        public FullFilterCatererViewModel GeneriereFullFilterCatererViewModel(List<Benutzer> benutzerListe, int gesamtAnzahlDatensätze, int aktuelleSeite = 1, int seitenGröße = 10)
        {
            var fullFilterCatererViewModel = new FullFilterCatererViewModel();
            fullFilterCatererViewModel.ResultListCaterer = new ListViewModel<IndexCatererViewModel>(gesamtAnzahlDatensätze, aktuelleSeite, seitenGröße);
            fullFilterCatererViewModel = AddListsToFullFilterCatererViewModel(fullFilterCatererViewModel);

            foreach (var benutzer in benutzerListe)
                fullFilterCatererViewModel.ResultListCaterer.Entitäten.Add(GeneriereIndexCatererViewModel(benutzer));
            return fullFilterCatererViewModel;
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

        public FullFilterCatererViewModel AddListsToFullFilterCatererViewModel(FullFilterCatererViewModel fullFilterCatererViewModel)
        {

            fullFilterCatererViewModel.Lieferumkreise = CreateLieferumkreisSelectList();

            return fullFilterCatererViewModel;
        }

        public FullFilterCatererViewModel AddFragenListsToFullFilterCatererViewModel(FullFilterCatererViewModel fullFilterCatererViewModel, List<Frage> fragen)
        {
          
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Bitte wählen...", Value = "0" });
            items.AddRange(fragen.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Bezeichnung,
                    Value = Convert.ToString(a.FrageId)
                };
            }));

            fullFilterCatererViewModel.Fragen = items;


            return fullFilterCatererViewModel;
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
                                new SelectListItem { Text = "Bis  5 km", Value = "5" },
                                new SelectListItem { Text = "Bis 10 km", Value = "10" },
                                new SelectListItem { Text = "Bis 15 km", Value = "15" },
                                new SelectListItem { Text = "Bis 20 km", Value = "20" },
                                new SelectListItem { Text = "Bis 25 km", Value = "25" },
                                new SelectListItem { Text = "Bis 30 km", Value = "30" },
                                new SelectListItem { Text = "Bis 40 km", Value = "40" },
                                new SelectListItem { Text = "Bis 50 km", Value = "50" },
                                new SelectListItem { Text = "Bis 60 km", Value = "60" },
                                new SelectListItem { Text = "Bis 70 km", Value = "70" },
                                new SelectListItem { Text = "Bis 80 km", Value = "80" },
                                new SelectListItem { Text = "Bis 90 km", Value = "90" },
                                new SelectListItem { Text = "100 km +", Value = "100" },
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
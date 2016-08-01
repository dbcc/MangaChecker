using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MangaChecker.Database;
using MangaChecker.GUI.dependencies;
using MangaChecker.Utility;
using MaterialDesignThemes.Wpf;
using PropertyChanged;

namespace MangaChecker.GUI.Viewmodels
{   [ImplementPropertyChanged]
    public class MainWindowViewModel : ViewModelBase {
        public static readonly ObservableCollection<MangaModel.MangaModel> MangasInternal =
            new ObservableCollection<MangaModel.MangaModel>();

        public static string _currentSite;

        private readonly List<string> _sites = GlobalVariables.DataGridFillSites;
        
        private ListBoxItem _selectedSite;
        private ThreadStart Childref;
        private Thread ChildThread;
    private int _menuIndex = -1;
    //private HistoryWindow History;

        public MainWindowViewModel() {
            Mangas = new ReadOnlyObservableCollection<MangaModel.MangaModel>(MangasInternal);
            NewMangas = new ReadOnlyObservableCollection<MangaModel.MangaModel>(GlobalVariables.NewMangasInternal);
            ListboxItemNames = new ReadOnlyObservableCollection<ListBoxItem>(GlobalVariables.ListboxItemNames);
            RefreshCommand = new ActionCommand(RunRefresh);
            StartStopCommand = new ActionCommand(Startstop);
            DebugCommand = new ActionCommand(DebugClick);
            SettingsCommand = new ActionCommand(SettingClick);
            AddMangaCommand = new ActionCommand(AddMangaClick);
            HistoryCommand = new ActionCommand(ShowHistory);
            FillListCommand = new ActionCommand(Fill_list);
            NewCommand = new ActionCommand(ShowNew);

            DebugVisibility = Visibility.Collapsed;
            SettingsVisibility = Visibility.Collapsed;
            AddVisibility = Visibility.Collapsed;
            DataGridVisibility = Visibility.Visible;

            ThreadStatus = "[Running]";
            Fill_list();

            //Childref = MainThread.CheckNow;
            //ChildThread = new Thread(Childref) { IsBackground = true };
            //ChildThread.SetApartmentState(ApartmentState.STA);
            //ChildThread.Start();
        }

        public ReadOnlyObservableCollection<ListBoxItem> ListboxItemNames { get; }

    public PackIconKind PausePlayButtonIcon { get; set; } = PackIconKind.Pause;


        public ListBoxItem SelectedSite {
            get { return _selectedSite; }
            set {
                getItems(value.Content.ToString());
                _selectedSite = value;
            }
        }

        public MangaModel.MangaModel SelectedItem { get; set; }

        public bool MenuToggleButton { get; set; }

        public ReadOnlyObservableCollection<MangaModel.MangaModel> Mangas { get; }
        public ReadOnlyObservableCollection<MangaModel.MangaModel> NewMangas { get; }

        public ICommand RefreshCommand { get; }
        public ICommand FillListCommand { get; }
        public ICommand StartStopCommand { get; }
        public ICommand DebugCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand AddMangaCommand { get; }
        public ICommand HistoryCommand { get; }
        public ICommand NewCommand { get; }

        public string CurrentSite { get; set; }
        public string ThreadStatus { get; set; }
        public Visibility DataGridVisibility { get; set; }
        public Visibility DebugVisibility { get; set; }
        public Visibility SettingsVisibility { get; set; }
        public Visibility AddVisibility { get; set; }
        public bool FillingList { get; set; }
        public int SelectedIndex { get; set; }
        public int SelectedIndexTransitioner { get; set; } = 0;

    public int MenuIndex {
        get { return _menuIndex; }
        set {
            switch (value) {
                    case 0:
                    SelectedIndexTransitioner = 2;
                        break;
                    case 2:
                    SelectedIndexTransitioner = 3;
                        break;

            }
            _menuIndex = value;
        }
    }

    private async void getItems(string site) {
            if(site == "DEBUG") {
                DebugClick();
                return;
            }
            if(site.ToLower().Equals("all")) {
                MangasInternal.Clear();
                Fill_list();
                return;
            }
            MangasInternal.Clear();
            await GetMangas(site);
        }

        private void ShowHistory() {
            //if(History != null) {
            //    History.Show();
            //} else {
            //    History = new HistoryWindow {
            //        DataContext = new HistoryViewModel(),
            //        ShowActivated = false,
            //        Owner = MediaTypeNames.Application.Current.MainWindow,
            //        WindowStartupLocation = WindowStartupLocation.CenterOwner
            //    };
            //    History.Show();
            //}
        }

        private void ShowNew() {
            SelectedIndexTransitioner = 4;
        }

        private void RunRefresh() {
            //Settings.Default.ForceCheck = "force";
        }

        private void Startstop() {
            switch(ThreadStatus) {
                case "[Running]": {
                        ChildThread.Abort();
                        ThreadStatus = "[Stopped]";
                        PausePlayButtonIcon = PackIconKind.Play;
                        break;
                    }
                case "[Stopped]": {
                        //Childref = MainThread.CheckNow;
                        //ChildThread = new Thread(Childref) { IsBackground = true };
                        //ChildThread.Start();
                        ThreadStatus = "[Running]";
                        PausePlayButtonIcon = PackIconKind.Pause;
                        break;
                    }
            }
        }

        private async Task GetMangas(string site) {
            if(FillingList)
                return;
            FillingList = true;
            CurrentSite = site;
            SettingsVisibility = Visibility.Collapsed;
            AddVisibility = Visibility.Collapsed;
            DebugVisibility = Visibility.Collapsed;
            DataGridVisibility = Visibility.Visible;
            foreach(var manga in await Sqlite.GetMangasAsync(site.ToLower())) {
                if(manga.Link.Equals("placeholder")) {
                    manga.Link = "";
                }
                MangasInternal.Add(manga);
            }
            FillingList = false;
        }

        private async void Fill_list() {
            SelectedIndexTransitioner = 0;
            MenuToggleButton = false;
            MangasInternal.Clear();
            foreach(var site in _sites) {
                await GetMangas(site);
            }
            CurrentSite = "All";
            SelectedIndex = 0;
        }

        private void DebugClick() {
            SelectedIndexTransitioner = 1;
            CurrentSite = "Debug";
            DebugVisibility = Visibility.Visible;
            DataGridVisibility = Visibility.Collapsed;
            SettingsVisibility = Visibility.Collapsed;
            AddVisibility = Visibility.Collapsed;
        }

        private void SettingClick() {
            SelectedIndexTransitioner = 3;
            MenuToggleButton = false;
            CurrentSite = "Settings";
            DebugVisibility = Visibility.Collapsed;
            DataGridVisibility = Visibility.Collapsed;
            SettingsVisibility = Visibility.Visible;
            AddVisibility = Visibility.Collapsed;
        }

        private void AddMangaClick() {
            SelectedIndexTransitioner = 2;
            MenuToggleButton = false;
            CurrentSite = "Add Manga";
            DebugVisibility = Visibility.Collapsed;
            DataGridVisibility = Visibility.Collapsed;
            SettingsVisibility = Visibility.Collapsed;
            AddVisibility = Visibility.Visible;
        }
    }

}

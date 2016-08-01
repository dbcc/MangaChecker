using System.Collections.ObjectModel;
using System.Windows.Input;
using MangaChecker.GUI.dependencies;

namespace MangaChecker.GUI.Viewmodels {
    public class HistoryViewModel : ViewModelBase {
        private readonly ObservableCollection<MangaModel.MangaModel> _linksCollection =
            new ObservableCollection<MangaModel.MangaModel>();

        public HistoryViewModel() {
            LinkCollection = new ReadOnlyObservableCollection<MangaModel.MangaModel>(_linksCollection);
            RefreshCommand = new ActionCommand(FillCollection);
            FillCollection();
        }

        public MangaModel.MangaModel SelectedItem { get; set; }

        public ICommand RefreshCommand { get; }
        public ReadOnlyObservableCollection<MangaModel.MangaModel> LinkCollection { get; }

        public void FillCollection() {
            _linksCollection.Clear();
            //foreach (var m in Sqlite.GetHistory()) {
            //    _linksCollection.Add(m);
            //    OnPropertyChanged();
            //}
        }
    }
}
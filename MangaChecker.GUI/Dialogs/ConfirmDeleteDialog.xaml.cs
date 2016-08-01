using System.Windows;
using System.Windows.Controls;
using MangaChecker.Database;

namespace MangaChecker.GUI.Dialogs {
    /// <summary>
    ///     Interaktionslogik für ConfirmDialog.xaml
    /// </summary>
    public partial class ConfirmDeleteDialog : UserControl {
        public MangaModel.MangaModel item;

        public ConfirmDeleteDialog() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            //ParseFile.RemoveManga(item.Site.ToLower(), item.Name);
            Sqlite.DeleteManga(item);
        }
    }
}
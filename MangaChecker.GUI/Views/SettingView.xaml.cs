using System.Windows.Controls;
using MangaChecker.GUI.Viewmodels;

namespace MangaChecker.GUI.Views {
    /// <summary>
    ///     Interaktionslogik für SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl {
        public SettingView() {
            InitializeComponent();
            DataContext = new SettingViewModel();
        }
    }
}
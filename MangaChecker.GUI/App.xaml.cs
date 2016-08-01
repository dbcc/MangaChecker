using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MangaChecker.GUI.Viewmodels;

namespace MangaChecker.GUI {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        private void AppStartup(object sender, StartupEventArgs args) {
            //if(!Debugger.IsAttached)
            //    ExceptionHandler.AddGlobalHandlers();

            //if(File.Exists("MangaDB.sqlite"))
            //    Sqlite.UpdateDatabase();
            //else {
            //    Sqlite.SetupDatabase();
            //}
            var mainWindow = new MainWindow {
                DataContext = new MainWindowViewModel()
            };
            mainWindow.Show();
        }
    }
}

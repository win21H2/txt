using System;
using System.IO;
using System.Threading.Tasks;
using txt.ViewModels;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace txt.Views {
    public sealed partial class HomePage : Page {

        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public IStorageFile sampleFile { get; private set; }

        public HomePage() {
            InitializeComponent();
        }
        private void Settings_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(SettingsPage));
        }
        private void Home_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HomePage));
        }


        
        private async void Save_Click(object sender, RoutedEventArgs e) {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync("sample.txt");
        }
        private async void Create_Click(object sender, RoutedEventArgs e) {
            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.txt",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
        }
        private async void Write_Click(object sender, RoutedEventArgs e) {
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, "Swift as a shadow");
        }
    }
}

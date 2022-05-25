using System;
using System.IO;
using System.Threading.Tasks;
using txt.ViewModels;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core.Preview;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;

namespace txt.Views {
    public sealed partial class HomePage : Page {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage() {
            InitializeComponent();
        }
        private void Settings_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(SettingsPage));
        }
        private void Version_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(VersionPage));
        }

        private async void Home_Click(object sender, RoutedEventArgs e) {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "You are already on the home page!";
            dialog.PrimaryButtonText = "Ok";
            dialog.DefaultButton = ContentDialogButton.Primary;
            var result = await dialog.ShowAsync();
        }

        private async void Save_Click(object sender, RoutedEventArgs e) {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Feature coming soon!";
            dialog.PrimaryButtonText = "Ok";
            dialog.DefaultButton = ContentDialogButton.Primary;
            var result = await dialog.ShowAsync();
        }
    }
}

using System;
using txt.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace txt.Views {
    public sealed partial class HomePage : Page {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public HomePage() {
            InitializeComponent();
        }
        private void Settings_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(SettingsPage));
        }
        private void Home_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}

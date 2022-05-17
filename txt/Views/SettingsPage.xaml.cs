using System;
using txt.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace txt.Views {
    public sealed partial class SettingsPage : Page {
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();
        public SettingsPage() {
            InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            await ViewModel.InitializeAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            App.TryGoBack();
        }

        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e) {
            // Cast the sender as a PasswordBox
            PasswordBox passwordBox = sender as PasswordBox;
            // Get the PasswordBox inputted string length
            int length = passwordBox.Password.Length;
            if (length > 0) {
                Psswrd.Text = length + " Character(s).";
            }
            else {
                Psswrd.Text = "The password entry box is empty.";
            }
        }
    }
}

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
            PasswordBox passwordBox = sender as PasswordBox;
            int length = passwordBox.Password.Length;
            if (length > 0) {
                Psswrd.Text = "Your password is " + length + " character(s) long.";
            }
            else {
                Psswrd.Text = "The password entry box is empty.";
            }
        }
    }
}

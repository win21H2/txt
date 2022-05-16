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

namespace txt.Views {
    public sealed partial class HomePage : Page {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage(Windows.ApplicationModel.Activation.IActivatedEventArgs args) {
            InitializeComponent();
        }
        private void Settings_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(SettingsPage));
        }
        private void Home_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HomePage));
        }
        private void About_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(AboutPage));
        }
        private void Version_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(VersionPage));
        }

        private async void buttonfilepick_Click(object sender, RoutedEventArgs e) {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null) {
                TextBlockoutput.Text = "User Selected File:" + file.Name;
            }
            else {
                TextBlockoutput.Text = "Error. Try again!";
            }
        }

        private async void App_CloseRequested(object sender, SystemNavigationCloseRequestedPreviewEventArgs e) {
            var deferral = e.GetDeferral();
            var dialog = new MessageDialog("Are you sure you want to exit?", "Exit");
            var confirmCommand = new UICommand("Yes");
            var cancelCommand = new UICommand("No");
            dialog.Commands.Add(confirmCommand);

            dialog.Commands.Add(cancelCommand);

            if (await dialog.ShowAsync() == cancelCommand) {
                //cancel close by handling the event
                e.Handled = true;
            }

            deferral.Complete();
        }
    }
}

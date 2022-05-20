using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace txt.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VersionPage : Page {
        public VersionPage() {
            this.InitializeComponent();
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
        private async void V01010_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v0.1.0.10\n\nNotes\n-Added the settings page, home page, about page, and version page\n-Started working on the text editor format and layout",
                        "e67b1ab1-9ddf-428f-ba77-434c2b34134e");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
        private async void V01011_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v0.1.0.11\n\nNotes\n-Cleaned up the code for the text editor and the main frame of the application\n-Worked on the wrapping of the words for all of the pages",
                        "d15a5f61-9a3d-4896-858b-ea52ae382867");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
        private async void V01012_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v0.1.0.12\n\nNotes\n-Changed the overall background theme for the application\n-Changed the button layout on the top menu so that Home is on the top left",
                        "6388ff56-8fff-4a3e-8eed-3eb3746004bc");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
        private async void V01013_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v0.1.0.13\n\nNotes\n-Updated all of the buttons with the new button border style\n-Removed all of the Grid.Row lines from every element due to styling issues",
                        "eaf5a266-f7b3-43fa-839f-7eee9c965908");
        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
}
        //FORMAT VERSION BELOW
        //private async void V0###_Click(object sender, RoutedEventArgs e) {
        //    var dialog = new Windows.UI.Popups.MessageDialog(
        //                "v0.#.#.#\n\nNotes\n\nEXAMPLE NOTES HERE",
        //                "d15a5f61-9a3d-4896-858b-ea52ae382867");
        //    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
        //    dialog.CancelCommandIndex = 1;
        //    var result = await dialog.ShowAsync();
        //}
    }
}

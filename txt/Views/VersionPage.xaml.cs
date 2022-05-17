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
        private async void V0111_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v1.1.1.1 \n \n \n \n Notes \n \n Added the settings page, home page, about page, and version page\nStarted working on the text editor format and layout",
                        "e67b1ab1-9ddf-428f-ba77-434c2b34134e");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
        private async void V0112_Click(object sender, RoutedEventArgs e) {
            var dialog = new Windows.UI.Popups.MessageDialog(
                        "v1.1.1.2 \n \n \n \n Notes \n \n Cleaned up the code for the text editor and the main frame of the application\nWorked on the wrapping of the words for all of the pages",
                        "d15a5f61-9a3d-4896-858b-ea52ae382867");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
        //FORMAT VERSION BELOW
        //private async void V####_Click(object sender, RoutedEventArgs e) {
        //    var dialog = new Windows.UI.Popups.MessageDialog(
        //                "v#.#.#.# \n \n \n \n Notes \n \n EXAMPLE NOTES HERE",
        //                "d15a5f61-9a3d-4896-858b-ea52ae382867");
        //    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Close") { Id = 1 });
        //    dialog.CancelCommandIndex = 1;
        //    var result = await dialog.ShowAsync();
        //}
    }
}

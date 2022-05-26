﻿using System;
using System.Threading.Tasks;
using txt.ViewModels;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace txt.Views {
    public sealed partial class HomePage : Page {
        const string TEXT_FILE_NAME = "SampleTextFile.txt";
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

        private async void readFile_Click(object sender, RoutedEventArgs e) {
            string str = await FileHelper.ReadTextFile(TEXT_FILE_NAME);
            textBlock.Text = "You entered \n\n" + str;
            // Work on reading the file from a different folder
        }

        private async void writeFile_Click(object sender, RoutedEventArgs e) {
            string textFilePath = await FileHelper.WriteTextFile(TEXT_FILE_NAME, textbox.Text);
            // Work on trying to write to an external folder other than the apps' local folder
        }
    }

    public static class FileHelper {
        public static async Task<string>
           WriteTextFile(string filename, string contents) {

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.CreateFileAsync(filename,
               CreationCollisionOption.ReplaceExisting);

            using (IRandomAccessStream textStream = await
               textFile.OpenAsync(FileAccessMode.ReadWrite)) {
                using (DataWriter textWriter = new DataWriter(textStream)) {
                    textWriter.WriteString(contents);
                    await textWriter.StoreAsync();
                }
            }
            return textFile.Path;
        }

        public static async Task<string> ReadTextFile(string filename) {
            string contents;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile textFile = await localFolder.GetFileAsync(filename);

            using (IRandomAccessStream textStream = await textFile.OpenReadAsync()) {
                using (DataReader textReader = new DataReader(textStream)) {
                    uint textLength = (uint)textStream.Size;
                    await textReader.LoadAsync(textLength);
                    contents = textReader.ReadString(textLength);
                }
            }
            return contents;
        }
    }
}

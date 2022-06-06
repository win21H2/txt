using System;
using System.Threading.Tasks;
using txt.ViewModels;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace txt.Views {
    public sealed partial class HomePage : Page {
        const string TEXT_FILE_NAME = "SampleTextFile.txt";
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage() {
            InitializeComponent();
        }
        private void Settings_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(SettingsPage));
        }
        private void Version_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(VersionPage));
        }

        private async void readFile_Click(object sender, RoutedEventArgs e) {
            string str = await FileHelper.ReadTextFile(TEXT_FILE_NAME);          
            textBlock.Text = str;
            // Work on reading the file from a different folder

            // Check here: https://docs.microsoft.com/en-us/windows/communitytoolkit/helpers/storagefiles

            // NOTE This must be used from an async function
            // string myText = "Great information that the users wants to keep";
            // StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // Save some text to a file named appFilename.txt (in the local cache folder)
            // var storageFile = await StorageFileHelper.WriteTextToLocalCacheFileAsync(myText, "appFilename.txt");

            // Load some text from a file named appFilename.txt in the local cache folder 
            // string loadedText = await StorageFileHelper.ReadTextFromLocalCacheFileAsync("appFilename.txt");

            // Save some text to a file named appFilename.txt (in the local folder)
            // storageFile = await StorageFileHelper.WriteTextToLocalFileAsync(myText, "appFilename.txt");

            // Load some text from a file named appFilename.txt in the local folder 
            // loadedText = await StorageFileHelper.ReadTextFromLocalFileAsync("appFilename.txt");

            // Check if a file exists in a specific folder
            // bool exists = await localFolder.FileExistsAsync("appFilename.txt");

            // Check if a file exists in a specific folder or in one of its subfolders
            // bool exists = await localFolder.FileExistsAsync("appFilename.txt", true);

            // Check if a file name is valid or not
            // bool isFileNameValid = StorageFileHelper.IsFileNameValid("appFilename.txt");

            // Check if a file path is valid or not
            // bool isFilePathValid = StorageFileHelper.IsFilePathValid("folder/appFilename.txt");
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

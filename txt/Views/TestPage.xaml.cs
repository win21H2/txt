using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace txt.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page {
        const string TEXT_FILE_NAME = "SampleTextFile.txt";
        public TestPage() {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(HomePage));
        }


        

        private async void readFile_Click(object sender, RoutedEventArgs e) {
            string str = await FileHelper.ReadTextFile(TEXT_FILE_NAME);
            textBlock.Text = str;
        }

        private async void writeFile_Click(object sender, RoutedEventArgs e) {
            string textFilePath = await FileHelper.WriteTextFile(TEXT_FILE_NAME, textBox.Text);
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

        public static async Task <string> ReadTextFile(string filename) {
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

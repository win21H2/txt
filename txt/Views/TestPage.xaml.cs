using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace txt.Views {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page {
        public TestPage() {
            this.InitializeComponent();
        }

        private async void OpenButton_Click(object sender, RoutedEventArgs e) {
            Windows.Storage.Pickers.FileOpenPicker open =
                new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".txt");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (file != null) {
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read)) {
                    editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e) {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Text", new List<string>() { ".rft" });
            savePicker.SuggestedFileName = "New Document";
            // figure out how to make it save to a txt file 

            StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null) {
                // Prevent updates to the remote version of the file until we
                // finish making changes and call CompleteUpdatesAsync.
                CachedFileManager.DeferUpdates(file);
                
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite)) {
                    editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);
                }

                // Let Windows know that we're finished changing the file so the
                // other app can update the remote version of the file.
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);
                if (status != FileUpdateStatus.Complete) {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e) {
            editor.Document.Selection.CharacterFormat.Bold = FormatEffect.Toggle;
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e) {
            editor.Document.Selection.CharacterFormat.Italic = FormatEffect.Toggle;
        }

        private void FindBoxRemoveHighlights() {
            ITextRange documentRange = editor.Document.GetRange(0, TextConstants.MaxUnitCount);
            SolidColorBrush defaultBackground = editor.Background as SolidColorBrush;
            SolidColorBrush defaultForeground = editor.Foreground as SolidColorBrush;

            documentRange.CharacterFormat.BackgroundColor = defaultBackground.Color;
            documentRange.CharacterFormat.ForegroundColor = defaultForeground.Color;
        }

        private void Editor_GotFocus(object sender, RoutedEventArgs e) {
            editor.Document.GetText(TextGetOptions.UseCrlf, out string currentRawText);

            // reset colors to correct defaults for Focused state
            ITextRange documentRange = editor.Document.GetRange(0, TextConstants.MaxUnitCount);
            SolidColorBrush background = (SolidColorBrush)App.Current.Resources["TextControlBackgroundFocused"];

            if (background != null) {
                documentRange.CharacterFormat.BackgroundColor = background.Color;
            }
        }

        private void Editor_TextChanged(object sender, RoutedEventArgs e) {
           
        }
    }
}

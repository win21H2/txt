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
        public TestPage() {
            InitializeComponent();
        }
        private void Home_Click(object sender, RoutedEventArgs e) {
            Frame.Navigate(typeof(HomePage));
        }
    }
}

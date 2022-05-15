using System;

using txt.ViewModels;

using Windows.UI.Xaml.Controls;

namespace txt.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public HomePage()
        {
            InitializeComponent();
        }
    }
}

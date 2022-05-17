using System;
using txt.Services;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace txt {
    public sealed partial class App : Application {
        private readonly Lazy<ActivationService> _activationService;

        private ActivationService ActivationService {
            get { return _activationService.Value; }
        }
        public App() {
            InitializeComponent();
            UnhandledException += OnAppUnhandledException;
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }
        protected override async void OnLaunched(LaunchActivatedEventArgs args) {
            if (!args.PrelaunchActivated) {
                await ActivationService.ActivateAsync(args);
            }
        }
        protected override async void OnActivated(IActivatedEventArgs args) {
            await ActivationService.ActivateAsync(args);
        }
        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e) {

        }
        private ActivationService CreateActivationService() {
            return new ActivationService(this, typeof(Views.HomePage));
        }
        public static bool TryGoBack() {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack) {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }
    }
}

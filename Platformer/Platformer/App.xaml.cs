using Platformer.Views;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Platformer.Configuration;
using Prism;
using Platformer.ViewModels;
using Prism.Ioc;
using Platformer.Shared;

namespace Platformer
{
    public partial class App
    {
        private IConfigurationRoot _configuration;

        public App(IPlatformInitializer initializer = null)
            : base(initializer)
        {
        }

        public App() : this(null)
        {   
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
#if PRODUCTION
            Debug.WriteLine("Loading Configuration for Production");
            var file = $"{nameof(Platformer)}.appsettings.Production.json";
#elif STAGING
            Debug.WriteLine("Loading Configuration for Staging");
            var file = $"{nameof(Platformer)}.appsettings.Staging.json";
#else
            Debug.WriteLine("Loading Configuration for Development");
            var file = $"{nameof(Platformer)}.appsettings.Development.json";
#endif

            _configuration = new ConfigurationBuilder().AddJsonFile(new ResourceFileProvider(), file, false, false).Build();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<PinViewPage, PinViewPageViewModel>();
            containerRegistry.RegisterForNavigation<NewItemPage, NewItemViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<ForgotPasswordPage, ForgotPasswordPageViewModel>();
            containerRegistry.RegisterSingleton<IDataStore<Item>, DataStore>();

            containerRegistry.RegisterInstance<IConfiguration>(_configuration);
        }

        public static bool IsUserLoggedIn { get; set; }

        protected override void OnStart()
        {
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }

            AppCenter.Start("android=f6bc5a20-8654-41c4-b424-3dc689594aa8",
                typeof(Analytics), typeof(Crashes), typeof(Push));
            AppCenter.LogLevel = LogLevel.Verbose;
            base.OnStart(); 
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
        
            if (!IsUserLoggedIn)
            {
                await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            }
            else
            {
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
        }
    }
}
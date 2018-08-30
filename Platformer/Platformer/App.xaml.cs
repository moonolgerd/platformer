using Platformer.Views;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Platformer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();

#if PRODUCTION
            Debug.WriteLine("Loading Configuration for Production");
            Stream stream = assembly.GetManifestResourceStream($"{nameof(Platformer)}.appsettings.Production.json");
#elif STAGING
            Debug.WriteLine("Loading Configuration for Staging");
            Stream stream = assembly.GetManifestResourceStream($"{nameof(Platformer)}.appsettings.Staging.json");
#else
            Debug.WriteLine("Loading Configuration for Development");
            Stream stream = assembly.GetManifestResourceStream($"{nameof(Platformer)}.appsettings.Development.json");
#endif
            var text = string.Empty;

            using (var reader = new StreamReader(stream))
                text = reader.ReadToEnd();
                        
            Debug.WriteLine(text);


            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
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
    }
}
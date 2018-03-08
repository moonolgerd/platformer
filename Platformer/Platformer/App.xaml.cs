using Platformer.Views;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Platformer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
            AppCenter.Start("android=f6bc5a20-8654-41c4-b424-3dc689594aa8;" + "uwp={Your UWP App secret here};" +
                   "ios=55099f39-256e-4196-b8eb-5873ee91e95e;",
                   typeof(Analytics), typeof(Crashes));
            base.OnStart(); 
        }
    }
}
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Threading.Tasks;

namespace Platformer.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashLayout);
            var textView = FindViewById<TextView>(Resource.Id.textView1);

            var info = ApplicationContext.PackageManager.GetPackageInfo(ApplicationContext.PackageName, PackageInfoFlags.Activities);

            textView.Text = $"Platformer v{info.VersionName}.{info.VersionCode}";

            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        private async void SimulateStartup()
        {
            await Task.Delay(1000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnBackPressed() { }
    }
}
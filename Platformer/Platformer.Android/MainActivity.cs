using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using FormsPinView.Droid;
using Microsoft.AppCenter;
using System.Net;

namespace Platformer.Droid
{
    [Activity(Label = "Platformer.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string TAG = "MainActivity";

        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            PinItemViewRenderer.Init();

            LoadApplication(new App());

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }

            ServicePointManager.ServerCertificateValidationCallback += (o, cert, chain, errors) => true;

            var id = await AppCenter.GetInstallIdAsync();
            Log.Debug(id.ToString(), id.ToString());

            //var data = JsonConvert.SerializeObject(new
            //{
            //    Token = id.ToString()
            //});
            //var client = new HttpClient();
            //await client.PostAsync("http://10.0.2.2:3000/register",
            //    new StringContent(data, Encoding.UTF8, "application/json"));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
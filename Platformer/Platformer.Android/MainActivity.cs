using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using System;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Platformer.Droid
{
    [Activity(Label = "Platformer.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string TAG = "MainActivity";

        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Push.SetSenderId("1011362886006");

            LoadApplication(new App());

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }

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
    }
}
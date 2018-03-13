﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Gms.Common;
using Android.Util;
using Firebase.Messaging;
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

        protected async override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Push.SetSenderId("1011362886006");

            LoadApplication(new App());

            try
            {
                FirebaseMessaging.Instance.SubscribeToTopic("news");
            }
            catch (Exception ex)
            {
                Log.Debug(TAG, ex.Message);
            }

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }

            IsPlayServicesAvailable();

            var isEnabled = await Push.IsEnabledAsync();
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

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    System.Diagnostics.Debug.WriteLine(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                else
                {
                    System.Diagnostics.Debug.WriteLine("This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Google Play Services is available.");
                return true;
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) 
            => base.OnActivityResult(requestCode, resultCode, data);
    }
}
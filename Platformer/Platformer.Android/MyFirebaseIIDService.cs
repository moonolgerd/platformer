using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Iid;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Platformer.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }
        void SendRegistrationToServer(string token)
        {
            var data = JsonConvert.SerializeObject(new
            {
                Token = token
            });
            var client = new HttpClient();
            client.PostAsync("http://10.0.2.2:3000/register",
                new StringContent(data, Encoding.UTF8, "application/json"));
        }
    }
}
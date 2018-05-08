//using Android.App;
//using Android.Content;
//using Android.Util;
//using Firebase.Messaging;

//namespace Platformer.Droid
//{
//    [Service]
//    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
//    public class MyFirebaseMessagingService : FirebaseMessagingService
//    {
//        const string TAG = "MyFirebaseMsgService";
//        public override void OnMessageReceived(RemoteMessage message)
//        {
//            Log.Debug(TAG, "From: " + message.From);
//            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
//            SendNotification(message);
//        }

//        void SendNotification(RemoteMessage message)
//        {
//            var notification = message.GetNotification();
//            var intent = new Intent(this, typeof(MainActivity));
//            intent.AddFlags(ActivityFlags.ClearTop);
//            foreach (string key in message.Data.Keys)
//            {
//                intent.PutExtra(key, message.Data[key]);
//            }
//            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

//            var notificationBuilder = new Notification.Builder(this)
//                //.SetSmallIcon(Resource.Drawable.ic_vol_type_speaker_light)
//                .SetContentTitle(notification.Title)
//                .SetContentText(notification.Body)
//                .SetAutoCancel(true)
//                .SetContentIntent(pendingIntent);

//            var notificationManager = NotificationManager.FromContext(this);
//            notificationManager.Notify(0, notificationBuilder.Build());
//        }
//    }
//}
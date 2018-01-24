using Firebase.CloudMessaging;
using Foundation;
using System;
using UIKit;
using UserNotifications;

namespace Platformer.iOS
{
	[Register(nameof(AppDelegate))]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IMessagingDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new App());

            Firebase.Core.App.Configure();

            // iOS 10 or later
            var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
            UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) => {
                Console.WriteLine(granted);
            });

            // For iOS 10 data message (sent via FCM)
            Messaging.SharedInstance.Delegate = this;

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            return base.FinishedLaunching(app, options);
		}

		public void DidRefreshRegistrationToken(Messaging messaging, string fcmToken) => Console.WriteLine(fcmToken);
	}
}

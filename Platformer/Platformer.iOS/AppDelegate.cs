﻿using FormsPinView.iOS;
using Foundation;
using System;
using UIKit;
using UserNotifications;

namespace Platformer.iOS
{
	[Register(nameof(AppDelegate))]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
            PinItemViewRenderer.Init();
            LoadApplication(new App());

            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.Green
            };

            // iOS 10 or later
            var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
            UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) => {
                Console.WriteLine(granted);
            });

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            return base.FinishedLaunching(app, options);
		}
	}
}

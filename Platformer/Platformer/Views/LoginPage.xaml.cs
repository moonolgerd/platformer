using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Platformer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CrossFingerprint.Current.AuthenticateAsync("Login using your fingerprint").ContinueWith(result =>
            {
                if (result.Result.Authenticated)
                {
                    Navigation.PushAsync(new MainPage()).ContinueWith(res =>
                    {
                        Debug.WriteLine("success");
                    });
                }
                else
                {
                    Debug.WriteLine("forbidden");
                }
            });
        }
    }
}
using Platformer.ViewModels;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Platformer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<LoginViewModel>(this, "Success", async (obj) => await Login());
            MessagingCenter.Subscribe<LoginViewModel>(this, "SignUp", async (obj) => await SignUp());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration(
                    "Authentication Required", "Use your fingerprint to verify your identity"));
                if (result.Authenticated)
                    await Login();
            }
        }

        private async Task Login()
        {
            App.IsUserLoggedIn = true;
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        private async Task SignUp()
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
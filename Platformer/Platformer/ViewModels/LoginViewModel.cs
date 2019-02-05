using Microsoft.AppCenter.Analytics;
using Prism.Navigation;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private string _email;
        private string _password;

        public LoginViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            LoginCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "Success");
                Analytics.TrackEvent("Logged in successfully");
            }, CanExecute);
            SignUpCommand = new Command(async () =>
            {
                await this.navigationService.NavigateAsync("platformer://SignUpPage");
                //MessagingCenter.Send(this, "SignUp");
            });
        }
        public Command LoginCommand { get; set; }

        public Command SignUpCommand { get; set; }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                LoginCommand.ChangeCanExecute();
            }
        }
        public string Password
        {
            get => _password; set
            {
                SetProperty(ref _password, value);
                LoginCommand.ChangeCanExecute();
            }
        }

        bool CanExecute() => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
    }
}

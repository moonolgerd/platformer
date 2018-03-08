using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

        public LoginViewModel()
        {
            LoginCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "Success");
            }, CanExecute);
            SignUpCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "SignUp");
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

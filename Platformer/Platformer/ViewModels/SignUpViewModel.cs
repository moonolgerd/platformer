using System;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    internal class SignUpViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _confirmPassword;
        private DateTime _dateOfBirth = DateTime.Today;

        public SignUpViewModel()
        {
            RegisterCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "Success");
            }, CanExecute);
        }

        public Command RegisterCommand { get; }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                RegisterCommand.ChangeCanExecute();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                SetProperty(ref _confirmPassword, value);
                RegisterCommand.ChangeCanExecute();
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        bool CanExecute() => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && Password == ConfirmPassword;
    }
}

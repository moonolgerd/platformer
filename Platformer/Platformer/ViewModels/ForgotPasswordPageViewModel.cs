using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace Platformer.ViewModels
{
    public class ForgotPasswordPageViewModel : BindableBase
    {
        private string email;

        public ForgotPasswordPageViewModel(INavigationService navigationService)
        {
            ResetPasswordCommand = new DelegateCommand(
                async () => await navigationService.GoBackAsync()).ObservesCanExecute(() => !string.IsNullOrWhiteSpace(Email));
        }

        public ICommand ResetPasswordCommand { get; }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
    }
}

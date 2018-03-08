using Platformer.ViewModels;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Platformer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SignUpViewModel>(this, "Success", async (obj) => await Login());
        }

        private async Task Login() => await Navigation.PopAsync();
    }
}
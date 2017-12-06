using Platformer.Views;
using Xamarin.Forms;

namespace Platformer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
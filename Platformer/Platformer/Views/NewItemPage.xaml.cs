using Platformer.ViewModels;
using Xamarin.Forms;

namespace Platformer
{
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (vm, Item) =>
            {
                await Navigation.PopToRootAsync();
            });
        }
    }
}

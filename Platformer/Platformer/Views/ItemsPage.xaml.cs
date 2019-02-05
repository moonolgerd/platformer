using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using Platformer.Shared;
using Platformer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Platformer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            
            MessagingCenter.Subscribe<ItemsPageViewModel>(this, "NewItem", async p =>
                await Navigation.PushAsync(new NewItemPage()));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;
            Analytics.TrackEvent($"Item selected", new Dictionary<string, string>
            {
                ["Item"] = item.ToString()
            });

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as ItemsPageViewModel;

            if (viewModel == null)
                return;

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
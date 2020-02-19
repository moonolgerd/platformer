using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.Configuration;
using Platformer.Shared;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    public class ItemsPageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        public IDataStore<Item> DataStore { get; }

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public Command AddCommand { get; set; }

        public ItemsPageViewModel(INavigationService navigationService, IDataStore<Item> dataStore)
        {
            this.navigationService = navigationService;
            DataStore = dataStore;
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddCommand = new Command(() => 
            {
                MessagingCenter.Send(this, "NewItem");
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) =>
            {
                var myItem = item as Item;
                Items.Add(myItem);
                await DataStore.AddItemAsync(myItem);
                Analytics.TrackEvent($"New item added", new Dictionary<string, string>
                {
                    ["Item"] = myItem.ToString()
                });
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }

        public Command AddCommand { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddCommand = new Command(() => 
            {
                MessagingCenter.Send(this, "NewItem");
            });

            MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) =>
            {
                Items.Add(item);
                await DataStore.AddItemAsync(item);
                Analytics.TrackEvent($"New item added {item}");
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

﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Platformer.Shared;
using Platformer.ViewModels;
using Xamarin.Forms;

namespace Platformer
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

            MessagingCenter.Subscribe<ItemsViewModel>(this, "NewItem", async p =>
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

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
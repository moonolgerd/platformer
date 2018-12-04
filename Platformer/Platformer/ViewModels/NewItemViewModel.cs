using System;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    internal class NewItemViewModel : BaseViewModel
    {
        public NewItemViewModel()
        {
            Item = new Item
            {
                Date = DateTime.Today
            };

            SaveCommand = new Command<VisualElement>(page =>
            {
                MessagingCenter.Send(this, "AddItem", Item);
            }, a => string.IsNullOrWhiteSpace(Item.Text) && string.IsNullOrWhiteSpace(Item.Description));

            MinimumDate = DateTime.Today;
        }

        public Item Item { get; set; }
        public Command<VisualElement> SaveCommand { get; set; }
        public DateTime MinimumDate { get; }
    }
}

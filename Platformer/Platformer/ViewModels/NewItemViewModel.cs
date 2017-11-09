using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class NewItemViewModel : BaseViewModel
    {
        public NewItemViewModel()
        {
            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description.",
                Date = DateTime.Today
            };

            SaveCommand = new Command<VisualElement>(page =>
            {
                MessagingCenter.Send(this, "AddItem", Item);
            });

            MinimumDate = DateTime.Today;
        }

        public Item Item { get; set; }
        public Command<VisualElement> SaveCommand { get; set; }
        public DateTime MinimumDate { get; }
    }
}

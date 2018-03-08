using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            LogOutCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "LogOut");
            });
        }

        public Command LogOutCommand { get; }
    }
}

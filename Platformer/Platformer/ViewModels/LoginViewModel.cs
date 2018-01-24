using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(() => { });
        }
        public Command LoginCommand { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}

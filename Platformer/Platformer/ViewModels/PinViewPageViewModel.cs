using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Platformer.ViewModels
{
    class PinViewPageViewModel
    {
        public Command SuccessCommand { get; set; }
        public Func<IList<char>, bool> Validator { get; set; }
    }
}

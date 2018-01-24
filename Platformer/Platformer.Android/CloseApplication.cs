using Android.App;
using Platformer.Interfaces;
using Xamarin.Forms;

namespace Platformer.Droid
{
    class CloseApplication : ICloseApplication
    {
        public void Close()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}
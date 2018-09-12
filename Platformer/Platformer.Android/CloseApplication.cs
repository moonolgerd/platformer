using Platformer.Interfaces;
using Plugin.CurrentActivity;

namespace Platformer.Droid
{
    class CloseApplication : ICloseApplication
    {
        public void Close()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            activity.FinishAffinity();
        }
    }
}
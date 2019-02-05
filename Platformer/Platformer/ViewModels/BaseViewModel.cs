using Prism.Mvvm;

namespace Platformer.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string title = string.Empty;
        private bool isBusy;
       
                
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
       
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}

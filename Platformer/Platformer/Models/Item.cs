using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Platformer
{
    public class Item : INotifyPropertyChanged
    {
        private string _id;
        private string _text;
        private string _description;
        private DateTime? _date;

        public string Id { get => _id; set => SetProperty(ref _id, value); }
        public string Text { get => _text; set => SetProperty(ref _text, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public DateTime? Date { get => _date; set => SetProperty(ref _date, value); }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() => JsonConvert.SerializeObject(this);

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName]string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

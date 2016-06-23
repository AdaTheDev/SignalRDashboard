using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SignalRDashboard.Data.Core.Hubs.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public virtual bool HasChanged { get; protected set; }
        private readonly List<string> _changedProperties = new List<string>(); 

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;            
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (!_changedProperties.Contains(propertyName))
            {
                _changedProperties.Add(propertyName);
            }
            HasChanged = true;
        }

        public IEnumerable<string> ChangedProperties => _changedProperties.ToArray();

        public virtual void ResetChangedState()
        {
            HasChanged = false;
            _changedProperties.Clear();
        }
    }
}
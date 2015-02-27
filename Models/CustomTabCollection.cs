using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CustomTabTest.Models
{
    public class CustomTabCollection : ObservableCollection<CustomTab>, INotifyPropertyChanged
    {
        // Expose a new PropertyChanged event
        public new event PropertyChangedEventHandler PropertyChanged;

        // Override insert and remove to subscribe to item prop changes

        protected override void InsertItem(int index, CustomTab item)
        {
            // Subscribe to PropertyChanged
            item.PropertyChanged += ItemOnPropertyChanged;
            ItemOnPropertyChanged(this, null);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            // Unsubscribe to PropertyChanged
            Items[index].PropertyChanged -= ItemOnPropertyChanged;
            ItemOnPropertyChanged(this, null);

            base.RemoveItem(index);
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        // Aggregate item hash codes
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var item in Items)
            {
                if (item != null)
                {
                    hashCode = hashCode ^ item.GetHashCode();
                }
            }
            return hashCode;
        }
    }
}
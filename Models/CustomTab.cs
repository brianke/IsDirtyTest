using SimpleMvvmToolkit;
using System;
using System.Linq;

namespace CustomTabTest.Models
{
    public class CustomTab : ModelBase<CustomTab>
    {
        public override int GetHashCode()
        {
            return GetHashCode(this, "TaskCollection");
        }

        private int GetHashCode(object item, params string[] excludeProps)
        {
            int hashCode = 0;
            foreach (var prop in item.GetType().GetProperties())
            {
                if (!excludeProps.Contains(prop.Name))
                {
                    object propVal = prop.GetValue(item, null);
                    if (propVal != null)
                    {
                        hashCode = hashCode ^ propVal.GetHashCode();
                    }
                }
            }
            return hashCode;
        }

        public string Header
        {
            get { return _Header; }
            set
            {
                _Header = value;
                NotifyPropertyChanged(m => m.Header);
            }
        }
        private string _Header;

        public Boolean TabIsVisible
        {
            get { return _TabIsVisible; }
            set
            {
                _TabIsVisible = value;
                NotifyPropertyChanged(m => m.TabIsVisible);
            }
        }
        private Boolean _TabIsVisible = true;
    }
}

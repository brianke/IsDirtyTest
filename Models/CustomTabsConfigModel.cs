using System.ComponentModel;
using System.Linq;
using SimpleMvvmToolkit;

namespace CustomTabTest.Models
{
    public class CustomTabsConfigModel : ModelBase<CustomTabsConfigModel>
    {       
        /// <summary>
        /// Create a configuration object bound to "CustomTabs.xml" 
        /// contained in [CommonApplicationData]\[Manufacturer]\[ProductName]
        /// </summary>
        public CustomTabsConfigModel()
        {
            CustomTabCollection = new CustomTabCollection();
            CustomTabCollection.PropertyChanged += CustomTabCollectionOnPropertyChanged;
        }

        private void CustomTabCollectionOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            NotifyPropertyChanged(m => m.CustomTabCollection);
        }

        public string ConfigModelName
        {
            get { return _ConfigModelName; }
            set
            {
                _ConfigModelName = value;
                NotifyPropertyChanged(m => m.ConfigModelName);
            }
        }
        private string _ConfigModelName;


        /// <summary>
        /// Collection of custom tabs
        /// </summary>
        public CustomTabCollection CustomTabCollection
        {
            get { return _CustomTabCollection; }
            set
            {
                _CustomTabCollection = value;
                NotifyPropertyChanged(m => m.CustomTabCollection);
            }
        }
        private CustomTabCollection _CustomTabCollection;
    }
}
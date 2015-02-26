using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace CustomTabTest.Models
{
    public class CustomTabsConfigModel : ModelBase<CustomTabsConfigModel>
    {
        #region Initialization & Cleanup

        public override int GetHashCode()
        {
            return GetHashCode(this);
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
        
        /// <summary>
        /// Create a configuration object bound to "CustomTabs.xml" 
        /// contained in [CommonApplicationData]\[Manufacturer]\[ProductName]
        /// </summary>
        public CustomTabsConfigModel()
        {
            CustomTabCollection = new CustomTabCollection();
        }

        #endregion Initialization & Cleanup


        #region Properties

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


        #endregion Properties
    }


    // ####################################################
    // CustomTabCollection Model
    // ####################################################
    public class CustomTabCollection : ObservableCollection<CustomTab>
    {
        #region Initialization & Cleanup
        // Overriding the GetHashCode prevents the Clone operation from marking an 
        // object Dirty when it is first cloned
        // Calculates object hash code based on property hash codes
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var item in Items)
            {
                if (item != null)
                {
                    // Aggregate item hash codes
                    hashCode = hashCode ^ item.GetHashCode();
                }
            }
            return hashCode;
        }

        public CustomTabCollection()
        {
            //TaskList = new List<UtilitiesTask>();
        }

        #endregion Initialization & Cleanup

        //    //[XmlArray("Tasks")]
        //    [XmlElement("Task", typeof(UtilitiesTask))]
        //    public List<UtilitiesTask> TaskList { get; set; }
    }


    // ####################################################
    // CustomTab Model
    // ####################################################
    public class CustomTab : ModelBase<CustomTab>
    {
        #region Initialization & Cleanup

        // Overriding the GetHashCode prevents the Clone operation from marking an 
        // object Dirty when it is first cloned
        // Calculates object hash code based on property hash codes
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


        public CustomTab()
        {    
        }


        #endregion Initialization & Cleanup


        #region Properties

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


        //public List<UtilitiesTask> TaskCollection { get; set; }
        //public TaskCollection TaskCollection { get; set; }


        #endregion Properties

    }


    // ####################################################
    // TaskCollection Model
    // ####################################################
    public class TaskCollection : ObservableCollection<UtilitiesTask>
    {
    #region Initialization & Cleanup
        // Overriding the GetHashCode prevents the Clone operation from marking an 
        // object Dirty when it is first cloned
        // Calculates object hash code based on property hash codes
        public override int GetHashCode()
        {
            return GetHashCode(this, "TaskList");
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


        public TaskCollection()
        {
            TaskList = new List<UtilitiesTask>();
        }

        #endregion Initialization & Cleanup
        
        public List<UtilitiesTask> TaskList { get; set; }
    }



    // ####################################################
    // UtilitiesTask Model
    // ####################################################
    public class UtilitiesTask : ModelBase<UtilitiesTask>   // : ModelBaseExtended, IIsDirty
    {
        #region Initialization & Cleanup

        // Overriding the GetHashCode prevents the Clone operation from marking an 
        // object Dirty when it is first cloned
        // Calculates object hash code based on property hash codes
        public override int GetHashCode()
        {
            return GetHashCode(this, "TaskTitle", "ButtonLabel", "ButtonType");
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

        public UtilitiesTask()
        {

        }

        #endregion Initialization & Cleanup


        #region Properties

        public String TaskTitle  { get; set; }
        public String ButtonLabel { get; set; }
        public String ButtonType { get; set; }

        #endregion Properties

    }
}

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

        //public String Header { get; set; }

        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                NotifyPropertyChanged(m => m.Header);
            }
        }

        public Boolean TabIsVisible { get; set; }
        //public List<UtilitiesTask> TaskCollection { get; set; }
        public TaskCollection TaskCollection { get; set; }


        #endregion Properties

    }


    // ####################################################
    // TaskCollection Model
    // ####################################################
    public class TaskCollection : ModelBase<TaskCollection>   // : ModelBaseExtended, IIsDirty
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

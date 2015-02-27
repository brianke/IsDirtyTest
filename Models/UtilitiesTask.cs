using System;
using System.Linq;
using SimpleMvvmToolkit;

namespace CustomTabTest.Models
{
    public class UtilitiesTask : ModelBase<UtilitiesTask>   // : ModelBaseExtended, IIsDirty
    {
        public String TaskTitle  { get; set; }
        public String ButtonLabel { get; set; }
        public String ButtonType { get; set; }
    }
}
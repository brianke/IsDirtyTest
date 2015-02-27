using System;
using CustomTabTest.Models;
using SimpleMvvmToolkit;

namespace CustomTabTest
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelDetailBase<MainPageViewModel, CustomTabsConfigModel>
    {
        #region Initialization and Cleanup

        // Default ctor
        public MainPageViewModel() 
        {
            CustomTabsInfo = new CustomTabsConfigModel();
            CustomTabsInfo.ConfigModelName = "New Test Model";

            CustomTab _customTab = new CustomTab();
            _customTab.Header = "Test 1 Tab";
            _customTab.TabIsVisible = true;
            //_customTab.TaskCollection = new TaskCollection();

            //UtilitiesTask _task = new UtilitiesTask();
            //_task.TaskTitle = "Task 1";
            //_task.ButtonLabel = "Task 1 Button";
            //_task.ButtonType = "SQL";

            //_customTab.TaskCollection.TaskList.Add(_task);

            //_task = new UtilitiesTask();
            //_task.TaskTitle = "Task 2";
            //_task.ButtonLabel = "Task 2 Button";
            //_task.ButtonType = "Crystal";

            //_customTab.TaskCollection.TaskList.Add(_task);
            CustomTabsInfo.CustomTabCollection.Add(_customTab);

            _customTab = new CustomTab();
            _customTab.Header = "Test 2 Tab";
            _customTab.TabIsVisible = true;
            //_task = new UtilitiesTask();
            //_customTab.TaskCollection = new TaskCollection(); 
            //_customTab.TaskCollection.TaskList.Add(_task);
            CustomTabsInfo.CustomTabCollection.Add(_customTab);


            _customTab = new CustomTab();
            _customTab.Header = "Test 3 Tab";
            _customTab.TabIsVisible = true;
            //_task = new UtilitiesTask();
            //_customTab.TaskCollection = new TaskCollection(); 
            //_customTab.TaskCollection.TaskList.Add(_task);
            CustomTabsInfo.CustomTabCollection.Add(_customTab);


            this.Model = CustomTabsInfo;
            BeginEdit();

            // DEBUG: Associate with IsDirtyInfo
            AssociateProperties(m => m.ConfigModelName, vm => vm.IsDirtyInfo);
            AssociateProperties(m => m.CustomTabCollection, vm => vm.IsDirtyInfo);
            
            // Handle PropertyChanged event (debugging)
            //Model.PropertyChanged += OnModelPropertyChanged;
        }

        //void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "Header")
        //    {
        //        NotifyPropertyChanged(m => m.IsDirtyInfo);
        //    }
        //}

        #endregion

        #region Notifications

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #endregion

        #region Properties

        public CustomTabsConfigModel CustomTabsInfo 
        {
            get { return _CustomTabsInfo; }
             set
             {
                 _CustomTabsInfo = value;
                 NotifyPropertyChanged(m => m.CustomTabsInfo);
             }
         }
        private CustomTabsConfigModel _CustomTabsInfo;


        // DEBUG: Wrap IsDirty
        public bool IsDirtyInfo
        {
            get
            {
                // Set breakpoint here
                return IsDirty;
            }
        }

        #endregion

        #region Methods

        // Manually fire property changed (debugging)
        //public void FirePropertyChanged()
        //{
        //    NotifyPropertyChanged(m => m.IsDirtyInfo);
        //}

        #endregion

        #region Completion Callbacks

        // TODO: Optionally add callback methods for async calls to the service agent

        #endregion

        #region Helpers

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        #endregion
    }



}
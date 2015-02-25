using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;

// Toolkit extension methods
using SimpleMvvmToolkit.ModelExtensions;
using CustomTabTest.Models;
using System.Collections.Generic;

namespace CustomTabTest
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelDetailBase<MainPageViewModel, CustomTab>
    {
        #region Initialization and Cleanup

        // Default ctor
        public MainPageViewModel() 
        {
            CustomTab _customTab = new CustomTab();
            _customTab.Header = "Test Tab";
            _customTab.TabIsVisible = true;
            _customTab.TaskCollection = new TaskCollection();

            UtilitiesTask _task = new UtilitiesTask();
            _task.TaskTitle = "Task 1";
            _task.ButtonLabel = "Task 1 Button";
            _task.ButtonType = "SQL";

            _customTab.TaskCollection.TaskList.Add(_task);

            _task = new UtilitiesTask();
            _task.TaskTitle = "Task 2";
            _task.ButtonLabel = "Task 2 Button";
            _task.ButtonType = "Crystal";

            _customTab.TaskCollection.TaskList.Add(_task);

            CustomTabCollection = _customTab;

            this.Model = CustomTabCollection;
            base.BeginEdit();
        }

        #endregion

        #region Notifications

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        #endregion

        #region Properties

        // Add properties using the mvvmprop code snippet
        public CustomTab CustomTabCollection { get; set; }

        private string bannerText = "Hello Simple MVVM Toolkit";
        public string BannerText
        {
            get
            {
                return "Banner";
            }
            set
            {
                bannerText = value;
                NotifyPropertyChanged(m => m.BannerText);
            }
        }

        #endregion

        #region Methods

        // TODO: Add methods that will be called by the view

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
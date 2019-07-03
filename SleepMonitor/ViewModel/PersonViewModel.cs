using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SleepMonitor.Services.Interfaces;

namespace SleepMonitor.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        #region Fields

        private IRepositoryService _repositoryService;

        #endregion

        public PersonViewModel(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;

        }
    }
}
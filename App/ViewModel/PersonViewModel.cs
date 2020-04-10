using App.Services.Interfaces;

namespace App.ViewModel
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
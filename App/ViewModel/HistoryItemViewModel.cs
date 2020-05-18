using System;
namespace App.ViewModel
{
    public class HistoryItemViewModel
    {

        public HistoryItemViewModel(HistoryViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

        }
    }
}

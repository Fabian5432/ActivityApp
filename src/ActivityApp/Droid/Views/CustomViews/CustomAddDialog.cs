using System;
using ActivityApp.Models;
using ActivityApp.ViewModel;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.Fragments;

namespace ActivityApp.Views.CustomViews
{
    public class CustomAddDialog: Dialog
    {
        #region Components

        private Button cancelButton;
        private Button addButton;
        private EditText activityNameEditText;
        private ActivityItemsViewModel ViewModel;

        #endregion

        public CustomAddDialog(Activity context):base (context)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel = MainPageViewFragment.ViewModel;

            //RequestWindowFeature((int)WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.custom_entry_dialog_layout);

            Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            SetCancelable(false);
            cancelButton = (Button)FindViewById(Resource.Id.cancel_button);
            addButton = (Button)FindViewById(Resource.Id.add_button);
            activityNameEditText = (EditText)FindViewById(Resource.Id.add_entry_item);
            activityNameEditText.ClearComposingText();
            activityNameEditText.TextChanged += OnTextChanged;

        }

        protected override void OnStart()
        {
            base.OnStart();
            addButton.Click += AddButtonClick;
            cancelButton.Click += CancelButtonClick;

        }
        protected override void OnStop()
        {
            base.OnStop();
            addButton.Click -= AddButtonClick;
            cancelButton.Click -= CancelButtonClick;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ActivityName = activityNameEditText.Text;
        }

        public void AddButtonClick(object sender, EventArgs e)
        {
            if (!ViewModel.CanAddItem)
                return;
            try
            {
                ViewModel.ActivityName = activityNameEditText.Text;
                var activity = new ActivityModel(ViewModel.ActivityName);
                ViewModel.AddItemCommand.Execute(activity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding item", ex);
            }
            Dismiss();

        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Dismiss();
        }
    }
}

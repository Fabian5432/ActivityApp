using ActivityApp.ViewModel;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.Activities;
using ActivityApp.Views.Fragments.Base;
using System;
using System.Threading.Tasks;

namespace ActivityApp.Views.Fragments
{
    public class RegisterFragment : LoginBaseFragment<LoginViewModel>
    {

        #region Components

        private View _view;
        private TextInputEditText _email;
        private TextInputEditText _password;
        private TextInputEditText _confirmedpassword;
        private Button _register;

        #endregion

        #region LifCycle

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public static RegisterFragment NewInstance()
        {
            var register_fragment = new RegisterFragment { Arguments = new Bundle() };
            return register_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            _view = inflater.Inflate(Resource.Layout.register_fragment_layout, null);
            _register = (Button)_view.FindViewById(Resource.Id.register_button);
            _email = (TextInputEditText)_view.FindViewById(Resource.Id.register_email_editText);
            _password = (TextInputEditText)_view.FindViewById(Resource.Id.register_password_editText);
            _confirmedpassword = (TextInputEditText)_view.FindViewById(Resource.Id.register_confirm_password_editText);

            _email.TextChanged += EmailOnTextChanged;
            _password.TextChanged += PasswordOnTextChanged;
            _confirmedpassword.TextChanged += ConfirmedPasswordOnTextChanged;

            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _register.Click += RegisterButtonClickAsync;
        }

        public override void OnPause()
        {
            base.OnPause();
            _register.Click -= RegisterButtonClickAsync;
        }

        #endregion

        #region Methods 

        private void EmailOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.Email = _email.Text;
        }

        private void PasswordOnTextChanged(object sender, EventArgs e)
        {
            ViewModel.Password = _password.Text;
        }

        private void ConfirmedPasswordOnTextChanged(object sender, EventArgs e)
        {
            ViewModel.ConfirmedPassword = _confirmedpassword.Text;
        }

        public async void RegisterButtonClickAsync(object sender, EventArgs e)
        {


            ViewModel.Email = _email.Text.ToLower();
            ViewModel.Password = _password.Text;
            ViewModel.ConfirmedPassword = _confirmedpassword.Text;

            if (!ViewModel.CanLogin)
                return;

            try
            {
                await ViewModel.RegisterAync();
                await Task.Delay(500);
                var intent = new Intent(Activity, typeof(OnboardingActivity));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                await Task.Delay(500);
                var builder = new AlertDialog.Builder(Context, Resource.Style.AlertDialogStyle);
                builder.SetTitle("Login failed");
                builder.SetMessage(ex.Message);
                builder.SetPositiveButton("Ok", (sender, e) => { });

                AlertDialog alertDialog = builder.Create();
                alertDialog.Show();
            }

        }

        #endregion
    }
}
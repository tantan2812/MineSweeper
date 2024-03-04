using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// Activity for user sign-up and sign-in operations using Firebase Authentication.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class SignUpActivity : AppCompatActivity,View.IOnClickListener, IOnCompleteListener
    {
        Button btnRegister, btnSignIn;
        EditText etName, etEmail, etPassword;
        TextView tvDisplay;
        private User user;
        private Task tskCreateFbUser, tskUpdateFbUserName, tskSendFbVerifyEmail, tskSignIn;

        /// <summary>
        /// Called when the activity is starting.
        /// </summary>
        /// <param name="savedInstanceState">If the activity is being re-initialized after previously being shut down
        /// then this Bundle contains the data it most recently supplied in onSaveInstanceState(Bundle).
        /// Note: Otherwise it is null.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_sign_up);
            InitObjects();
            InitViews();
        }

        /// <summary>
        /// creates a new user
        /// </summary>
        private void InitObjects()
        {
            user = new User();

        }

        /// <summary>
        /// creates the activity, and sets the XML. also checks if the user isnt new and handles the screen accordingly
        /// </summary>
        /// <param name="savedInstanceState">used in base</param>
        private void InitViews()
        {
            etName = FindViewById<EditText>(Resource.Id.etName);
            etEmail = FindViewById<EditText>(Resource.Id.etEmail);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            tvDisplay = FindViewById<TextView>(Resource.Id.tvDisplay);
            btnRegister.SetOnClickListener(this);
            btnSignIn.SetOnClickListener(this);
            if (!user.IsNew)
            {
                HandleButtons(true);
                etName.Text = user.Name;
                etEmail.Text = user.Email;
                etPassword.Text = user.Password;
            }
        }

        /// <summary>
        /// Called when a permission request has been completed.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Called when a view has been clicked.
        /// </summary>
        public void OnClick(View v)
        {
            if (v == btnRegister)
                CreateUserAndSendVerifyEmail();
            else if (v == btnSignIn)
                SignIn();
        }

        /// <summary>
        /// Attempts to sign in the user with the provided credentials.
        /// </summary>
        private void SignIn()
        {
            tskSignIn = user.SignIn().AddOnCompleteListener(this);
        }

        /// <summary>
        /// Attempts to create a new user account and send a verification email.
        /// </summary>
        private void CreateUserAndSendVerifyEmail()
        {
            user.Name = etName.Text;
            user.Email = etEmail.Text;
            user.Password = etPassword.Text;
            etName.Text = user.Name; //fields after trim
            etEmail.Text = user.Email;
            etPassword.Text = user.Password;
            if (user.IsValidFields)
                tskCreateFbUser = user.CreateFbUser().AddOnCompleteListener(this);
            else
                tvDisplay.Text = GetString(Resource.String.fields_not_valid);
        }

        /// <summary>
        /// Handles the completion of a Firebase Authentication task.
        /// </summary>
        /// <param name="task">The task that has been completed.</param>
        public void OnComplete(Task task)
        {
            string msg = string.Empty;
            if (task.IsSuccessful)
            {
                if (task == tskCreateFbUser)
                {
                    user.Save();
                    msg = GetString(Resource.String.created);
                    tskUpdateFbUserName = user.UpdateFbUserName().AddOnCompleteListener(this);
                }
                else if (task == tskUpdateFbUserName)
                {
                    msg = GetString(Resource.String.sending);
                    tskSendFbVerifyEmail = user.SendFbVerifyEmail().AddOnCompleteListener(this);
                }
                else if (task == tskSendFbVerifyEmail)
                {
                    HandleButtons(true);
                    msg = GetString(Resource.String.verify);
                }
                else if (task == tskSignIn)
                {
                    msg = GetString(Resource.String.signedin) + "\n";
                    if (!user.IsEmailVerifid)
                        msg += GetString(Resource.String.not) + "\n";
                    msg += GetString(Resource.String.verifide);
                    OpenMainActivity();
                }
            }
            else
                msg = task.Exception.Message;
            tvDisplay.Text = msg;
        }

        /// <summary>
        /// Opens the main activity.
        /// </summary>
        private void OpenMainActivity()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra(General.KEY_NAME, user.Name);
            StartActivity(intent);
            Finish();
        }

        /// <summary>
        /// Enables or disables the register and sign-in buttons based on the current state.
        /// </summary>
        private void HandleButtons(bool isSignInState)
        {
            btnRegister.Enabled = !isSignInState;
            btnSignIn.Enabled = isSignInState;
        }
    }
}
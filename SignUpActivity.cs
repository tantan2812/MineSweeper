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
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class SignUpActivity : AppCompatActivity,View.IOnClickListener, IOnCompleteListener
    {
        Button btnRegister, btnSignIn;
        EditText etName, etEmail, etPassword;
        TextView tvDisplay;
        private User user;
        private Task tskCreateFbUser, tskUpdateFbUserName, tskSendFbVerifyEmail, tskSignIn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_sign_up);
            InitObjects();
            InitViews();
        }

        private void InitObjects()
        {
            user = new User();

        }

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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v == btnRegister)
                CreateUserAndSendVerifyEmail();
            else if (v == btnSignIn)
                SignIn();
        }

        private void SignIn()
        {
            tskSignIn = user.SignIn().AddOnCompleteListener(this);
        }

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
                    OpenGamesActivity();
                }
            }
            else
                msg = task.Exception.Message;
            tvDisplay.Text = msg;
        }

        private void OpenGamesActivity()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra(General.KEY_NAME, user.Name);
            StartActivity(intent);
            Finish();
        }

        private void HandleButtons(bool isSignInState)
        {
            btnRegister.Enabled = !isSignInState;
            btnSignIn.Enabled = isSignInState;
        }
    }
}
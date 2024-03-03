using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// hansled the parameters of the user and sends it to firebase and shared prefrence
    /// </summary>
    internal class User
    {
        private string name, email, password;
        private readonly FbData fbd;
        private readonly SpData spd;
        //private PlayerStats playerStats;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.Trim();
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value.Trim();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value.Trim();
            }
        }

        /// <summary>
        /// sends the user parameters to shared prefrence
        /// </summary>
        public User()
        {
            fbd = new FbData();
            spd = new SpData(General.SP_FILE_NAME);
            email = spd.GetString(General.KEY_EMAIL, string.Empty);
            if (!IsNew)
            {
                name = spd.GetString(General.KEY_NAME, string.Empty);
                password = spd.GetString(General.KEY_PWD, string.Empty);
            }
        }

        /// <summary>
        /// checks if the parameters are valid
        /// </summary>
        public bool IsValidFields =>
                Name.Length >= General.MIN_LENGTH &&
                Email.Length >= General.MIN_LENGTH &&
                Password.Length >= General.MIN_PWD_LENGTH;
        public bool IsNew => email == string.Empty;
        public bool Connected => fbd.UserConnected;
        public bool IsEmailVerifid => fbd.IsEmailVerifid;

        /// <summary>
        /// creates a user with email and password throught firebase
        /// </summary>
        /// <returns></returns>
        public Task CreateFbUser()
        {
            return fbd.CreateUser(email, password);
        }
        public Task DeleteFbUser()
        {

            return fbd.DeleteUser();
        }

        public Task UpdateFbUserName()
        {
            return fbd.UpdateUserName(name);
        }
        public Task SignIn()
        {
            return fbd.SignIn(email, password);
        }

        /// <summary>
        /// sends a verify email to the user
        /// </summary>
        /// <returns></returns>
        internal Task SendFbVerifyEmail()
        {
            return fbd.SendVerifyEmail();
        }

        /// <summary>
        /// saves the user in shared prefrence
        /// </summary>
        internal void Save()
        {
            spd.PutString(General.KEY_NAME, name);
            spd.PutString(General.KEY_EMAIL, email);
            spd.PutString(General.KEY_PWD, password);
        }
        internal bool UnSave()
        {
            email = string.Empty;
            name = string.Empty;
            password = string.Empty;
            return spd.Delete();
        }
    }
}
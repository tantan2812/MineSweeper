﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal static class General
    {
        public const int REQUEST_OPEN_ACTIVITY = 1;
        public static int MIN_LENGTH = 3;
        public static int MIN_PWD_LENGTH = 6;
        public const string SP_FILE_NAME = "sp.dat";
        public const string KEY_EMAIL = "email";
        public const string KEY_PWD = "pwd";
        public const string KEY_ID = "id";
        public const string KEY_NAME = "name";
        public const string KEY_HOST_NAME = "hname";
        public const string KEY_GAME_JSON = "game_json";
        public const string USERS_COLLECTION = "Users";
        public const string GAMES_COLLECTION = "Games";
        public const string FIELD_NAME = "Name";
        public const string FIELD_HOST_NAME = "HostName";
        public const string FIELD_CREATE_TIME = "CreateTime";
        public const string FIELD_PLAYERS = "Players";
        public const string FIELD_CURRENT_PLAYER = "CurrentPlayer";

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
            return ms.ToArray();
        }
    }
}
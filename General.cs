using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net.Wifi.Aware;
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
    /// <summary>
    /// consts of keys and fields and frequently used parameters
    /// </summary>
    internal static class General
    {
        public const int REQUEST_OPEN_ACTIVITY = 1;
        public static int MIN_LENGTH = 3;
        public static int MIN_PWD_LENGTH = 6;
        public static string DIFFICULTY = "difficulty";
        public const string ACTION_ANIMATE = "com.meitar.action.ANIMATE";
        public const string KEY_FRAME = "frame";
        public const string SP_FILE_NAME = "sp.dat";
        public const string KEY_EMAIL = "email";
        public const string KEY_PWD = "pwd";
        public const string KEY_ID = "id";
        public const string KEY_NAME = "name";
        public const string KEY_HOST_NAME = "hname";
        public const string KEY_GAME_JSON = "game_json";
        public const string USERS_COLLECTION = "Users";
        public const string GAMES_COLLECTION = "Games";
        public const string TIMES_COLLECTION = "Times";
        public const string FIELD_NAME = "Name";
        public const string FIELD_HOST_NAME = "HostName";
        public const string FIELD_CREATE_TIME = "CreateTime";
        public const string FIELD_DIFFICULTY_BOARD = "difficulty";
        public const string FIELD_WIN_TIME = "WinTime";
        public const string FIELD_PLAYERS = "Players";
        public const string FIELD_CURRENT_PLAYER = "CurrentPlayer";
        public const string FIELD_BOARD_SQUARES = "BoardAndSquares";

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
            return ms.ToArray();
        }
    }
}
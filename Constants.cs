using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// consts for readability
    /// </summary>
    internal class Constants
    {
        public const int NUMBER_OF_MINES= 10;
        public const int SIZE_OF_BOARD_WIDTH= 8;
        public const int SIZE_OF_BOARD_HEIGHT= 8;
        public const string GAME_WOM = "Game won";
        public const string MINE_CLICKED = "Mine Clicked, try again";
        public const string FIRST_FLAG = "start playing to flag";
        public const string TEXT_TO_SPEECH_GAME_START = "Game Start!";
    }
}
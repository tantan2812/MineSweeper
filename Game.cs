using Android.Content;
using Java.Util;
using System;
using Newtonsoft.Json;
using Android.Gms.Tasks;
using GoogleGson;
using Android.Runtime;
using System.Collections.Generic;
using Android.App;
using Android.Views;

namespace MineSweeper
{
    internal class Game
    {
        private readonly FbData fbd;
        public string Id { get; set; }
        public string HostName { get; set; }
        public string GuestName { get; set; }
        [JsonIgnore]
        public DateTime CreateTime { get; set; }
        public int Players { get; set; }
        public Player.PlayerType CurrentPlayer { get; set; }
        public Player Player { get; set; }
        [JsonIgnore]
        public Context Context;
        [JsonIgnore]
        public Board Board { get; set; }
        [JsonIgnore]
        public Task TskInitGameTask { get; }
        private HashMap HashMap
        {
            get
            {
                HashMap hashMap = new HashMap();
                hashMap.Put(General.FIELD_HOST_NAME, HostName);
                return hashMap;
            }
        }
        [JsonIgnore]
        public string Json
        {
            get
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        public Game(string hostName)
        {
            InitGame(hostName, Player.PlayerType.Host);
        }

        public Game(string hostName, string id)
        {
            Id = id;
            InitGame(hostName, Player.PlayerType.Guest);
        }

        public Game(Context context, string hostName)
        {
            InitGame(hostName, Player.PlayerType.Host);
            Context = context;
            HashMap hm = HashMap;
            fbd = new FbData();
            hm.Put(General.FIELD_CREATE_TIME, fbd.DateTimeToFirestoreTimestamp(DateTime.Now));
            hm.Put(General.FIELD_PLAYERS, 1);
            hm.Put(General.FIELD_CURRENT_PLAYER, (int)Player.PlayerType.Guest);
            Board = new Board(Context);
            Board.GenerateFullBoard();
            JavaList<string> list = new JavaList<string>();
            string square, type;
            for (int i = 0; i < Board.Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Board.Squares.GetLength(1); j++)
                {
                    square = string.Empty;
                    square += i.ToString() + j.ToString();
                    if (Board.Squares[i, j] is Mine)
                        type = (-1).ToString();
                    else if (Board.Squares[i, j] is NumberTile)
                        type = ((NumberTile)Board.Squares[i, j]).Hint.ToString();
                    else
                        type = 0.ToString();
                    square += " " + type;
                    list.Add(square);
                }
            }
            hm.Put(General.FIELD_BOARD_SQUARES, list);
            TskInitGameTask = fbd.SetDocument(General.GAMES_COLLECTION, string.Empty, out string id, hm);
            Id = id;
            fbd.AddSnapshotListener((Activity)Context, General.GAMES_COLLECTION,id);
        }

        public Game(Context context, string hostName, string id)
        {
            Id = id;
            InitGame(hostName, Player.PlayerType.Host);
            Context = context;
            fbd = new FbData();
            TskInitGameTask = fbd.IncrementField(General.GAMES_COLLECTION, id, General.FIELD_PLAYERS, 1);
            fbd.AddSnapshotListener((Activity)Context, General.GAMES_COLLECTION, id);
        }

        private void InitGame(string hostName, Player.PlayerType type)
        {
            HostName = hostName;
            CurrentPlayer = Player.PlayerType.Guest;
            Player = new Player(type);
        }

        public JavaList<Square> SquaresToList(Board b)
        {
            JavaList<Square> lst = new JavaList<Square>();
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
            {
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                {
                    lst.Add(b.Squares[i, j]);
                }
            }
            return lst;
        }

        public void Exit()
        {
             fbd.DeleteDocument(General.GAMES_COLLECTION, Id);
        }

        public static Game GetGameJson(string json, Activity activity)
        {
            Game game = JsonConvert.DeserializeObject<Game>(json);
            new FbData().AddSnapshotListener(activity, General.GAMES_COLLECTION, game.Id);
            game.Context = activity;
            game.Board = new Board(activity);
            game.Board.Squares = new Square[8,8];
            return game;
        }

        public Task GetGame(string id)
        {
            return fbd.GetDocument(General.GAMES_COLLECTION, id);
        }

        public void ReceiveBoard(JavaList lstBoard)
        {
            Square sqr;
            string[] arr; 
            int row, col, type;
            foreach (object square in lstBoard)
            {
                arr = square.ToString().Split(" ");
                row = int.Parse(arr[0][0].ToString());
                col = int.Parse(arr[0][1].ToString());
                type = int.Parse(arr[1]);
                if (type == -1)
                    sqr = new Mine(Context);
                else if (type == 0)
                    sqr = new Square(Context);
                else
                    sqr = new NumberTile(Context)
                    {
                        Hint = type
                    };
                sqr.y = row;
                sqr.x = col;
                Board.Squares[row, col] = sqr;
            }
            RegisterSquares();
        }

        private void RegisterSquares()
        {
        }

        public Game()
        { 
            fbd = new FbData();
        }
    }
}
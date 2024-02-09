using Android.Content;
using Java.Util;
using System;
using Newtonsoft.Json;
using Android.Gms.Tasks;
using GoogleGson;

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
            TskInitGameTask = fbd.SetDocument(General.GAMES_COLLECTION, string.Empty, out string id, hm);
            Id = id;
            Board = new Board(Context);
            Board.GenerateFullBoard();
           /* string jBoard = JsonConvert.SerializeObject(Board.Squares, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });*/
            //hm.Put(General.FIELD_BOARD_SQUARES, jBoard);
        }

        public Game(Context context, string hostName, string id)
        {
            Id = id;
            InitGame(hostName, Player.PlayerType.Host);
            Context = context;
            fbd = new FbData();
            TskInitGameTask = fbd.IncrementField(General.GAMES_COLLECTION, id, General.FIELD_PLAYERS, 1);
        }

        private void InitGame(string hostName, Player.PlayerType type)
        {
            HostName = hostName;
            CurrentPlayer = Player.PlayerType.Guest;
            Player = new Player(type);
        }

        public void Exit()
        {
             fbd.DeleteDocument(General.GAMES_COLLECTION, Id);
        }

        public static Game GetGameJson(string json)
        {
            return JsonConvert.DeserializeObject<Game>(json);
        }

        public Task GetGame(string id)
        {
            return fbd.GetDocument(General.GAMES_COLLECTION, id);
        }

        public Game()
        { 
            fbd = new FbData();
        }
    }
}
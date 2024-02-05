using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal class SqlDataStats
    {
        readonly SQLiteConnection conn;
        const String DB_NAME = "stats.data";
        public bool IsNewDb { get; private set; }
        public SqlDataStats()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, DB_NAME);
            IsNewDb = !File.Exists(path);
            conn = new SQLiteConnection(path);
            if (IsNewDb)
            {
                conn.CreateTable<PlayerStats>();
            }
        }

        public bool Insert(object obj)
        {
            int row = conn.Insert(obj);
            return row > 0;
        }

        public List<PlayerStats> GetStatList()
        {
            return conn.Table<PlayerStats>().ToList();
        }

        public int SumOfFoundMines()
        {
            List<PlayerStats> stats = new List<PlayerStats>();
            int sum = 0;
            stats = GetStatList();
            foreach (PlayerStats stat in stats)
            {
                sum = sum + stat.MinesFound;
            }
            return sum;
        }
        
        public int SumOfGamesWon()
        {
            List<PlayerStats> stats= new List<PlayerStats>();
            int sum = 0;
            stats = GetStatList();
            foreach (PlayerStats stat in stats)
            {
                sum = sum + stat.GamesWon;
            }
            return sum;
        }
        
        public int SumOfGamesPlayed()
        {
            List<PlayerStats> stats= new List<PlayerStats>();
            int sum = 0;
            stats = GetStatList();
            foreach (PlayerStats stat in stats)
            {
                sum = sum + stat.GamesPlayed;
            }
            return sum;
        }

        public PlayerStats UpdatedPlayerStats()
        {
            PlayerStats stats = new PlayerStats();
            stats.MinesFound = SumOfFoundMines();
            stats.GamesPlayed= SumOfGamesPlayed();
            stats.GamesWon = SumOfGamesWon();
            return stats;
            
        }

        public void Update(object obj)
        {
            conn.Update(obj);
        }
    }
}
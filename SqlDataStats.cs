using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace MineSweeper
{
    /// <summary>
    /// creates the table for saving GamesWon, GamesPlayed, MinesFound and handles it
    /// </summary>
    public class SqlDataStats
    {
        readonly SQLiteConnection conn;
        const String DB_NAME = "stats.data";
        public bool IsNewDb { get; private set; }

        /// <summary>
        /// creates a new SqlDataStats and connects it to a place for storing
        /// </summary>
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

        /// <summary>
        /// inserts the PlayerStats into the table
        /// </summary>
        /// <param name="obj">the PlayerStats</param>
        /// <returns></returns>
        public bool Insert(object obj)
        {
            int row = conn.Insert(obj);
            return row > 0;
        }

        /// <summary>
        /// lists the table
        /// </summary>
        /// <returns></returns>
        public List<PlayerStats> GetStatList()
        {
            return conn.Table<PlayerStats>().ToList();
        }

        /// <summary>
        /// return the sum of the mines found that is saved in the table
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// return the sum of games won that is saved in the table
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// return the sum of the games played that is saved in the table
        /// </summary>
        /// <returns></returns>
        public int SumOfGamesPlayed()
        {
            List<PlayerStats> stats= new List<PlayerStats>();
            int sum = 0;
            stats = GetStatList();
            foreach (PlayerStats stat in stats)
            {
                sum += stat.GamesPlayed;
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

        /// <summary>
        /// updates the table with a new PlayerStats
        /// </summary>
        /// <param name="obj"></param>
        public void Update(object obj)
        {
            conn.Update(obj);
        }
    }
}
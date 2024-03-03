using SQLite;

namespace MineSweeper
{
    /// <summary>
    /// a table for saving GamesWon, GamesPlayed, MinesFound and taking the data out
    /// </summary>
    [Table("Stats")]
    public class PlayerStats
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int GamesWon { get; set; }
        public int GamesPlayed { get; set; }
        public int MinesFound { get; set;}
        [Ignore]
        public SqlDataStats SqlDataStats { get; set; }

        /// <summary>
        /// creates a new PlayerStats
        /// </summary>
        /// <param name="gamesWon">the games won</param>
        /// <param name="minesFound">the mines found</param>
        /// <param name="gamesPlayed">the games played</param>
        public PlayerStats(int gamesWon, int minesFound, int gamesPlayed)
        {
            GamesWon = gamesWon;
            MinesFound = minesFound;
            GamesPlayed = gamesPlayed;
        }

        /// <summary>
        /// a constractor that sets all the parameters to 0
        /// </summary>
        public PlayerStats()
        {
            GamesWon = 0;
            MinesFound = 0;
            GamesPlayed = 0;
        }

        /// <summary>
        /// the consractor that can be used for taking the data out of the table
        /// </summary>
        /// <param name="num"></param>
        public PlayerStats(int num)
        {
            SqlDataStats= new SqlDataStats();
            GamesWon = SqlDataStats.SumOfGamesWon();
            MinesFound = SqlDataStats.SumOfFoundMines();
            GamesPlayed = SqlDataStats.SumOfGamesPlayed();
        }

        /// <summary>
        /// returns a string that is the WinRate %
        /// </summary>
        /// <returns></returns>
        public string WinRate()
        {
            double NumaAvg=0;
            NumaAvg = (double)(GamesWon / (double)GamesPlayed);
            NumaAvg = NumaAvg * 100;
            int IntAvg = (int)NumaAvg;
            string StringAvg = IntAvg + "%";
            return StringAvg;

        }
    }
}
using SQLite;

namespace MineSweeper
{
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

        public PlayerStats(int gamesWon, int minesFound, int gamesPlayed)
        {
            GamesWon = gamesWon;
            MinesFound = minesFound;
            GamesPlayed = gamesPlayed;
        }

        public PlayerStats()
        {
            GamesWon = 0;
            MinesFound = 0;
            GamesPlayed = 0;
        }


        public PlayerStats(int num)
        {
            SqlDataStats= new SqlDataStats();
            GamesWon = SqlDataStats.SumOfGamesWon();
            MinesFound = SqlDataStats.SumOfFoundMines();
            GamesPlayed = SqlDataStats.SumOfGamesPlayed();
        }

        public string WinRate()
        {
            double NumaAvg=0;
            NumaAvg = (double)((double)GamesWon / (double)GamesPlayed);
            NumaAvg = NumaAvg * 100;
            int IntAvg = (int)NumaAvg;
            string StringAvg = IntAvg + "%";
            return StringAvg;

        }
    }
}
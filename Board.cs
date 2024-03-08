using Android.Content;
using Newtonsoft.Json;

namespace MineSweeper
{
    /// <summary>
    /// handles all the squares in the board and it handles generating squares
    /// </summary>
    public class Board
    {
        public Square[,] Squares { get; set; }

        public Generator Generator { get; set; }
        public bool IsRevealed { get; private set; }
        public Context Context { get; set; }

        /// <summary>
        /// sets the size of the bord and generate the squares
        /// </summary>
        /// <param name="Context">sets board context</param>
        public Board(Context Context)
        {
            this.Context = Context;
            Squares = new Square[GameEngine.WIDTH, GameEngine.HEIGHT];
            GenerateSquares();
            IsRevealed = false;
            Generator = new Generator(this);
        }

        /// <summary>
        /// get func for context
        /// </summary>
        /// <returns></returns>
        public Context GetContext()
        {
            return Context;
        }

        /// <summary>
        /// generates all squares
        /// </summary>
        public void GenerateSquares()
        {
            for (int i = 0; i < GameEngine.WIDTH; i++)
                for (int j = 0; j < GameEngine.HEIGHT; j++)
                    Squares[i, j] = new Square(Context, i, j);
        }

        /// <summary>
        /// Invalidate all Squares, draws them again
        /// </summary>
        public void InvalidateSquares()
        {
            for (int i = 0; i < GameEngine.WIDTH; i++)
                for (int j = 0; j < GameEngine.HEIGHT; j++)
                    Squares[i, j].Invalidate();
        }

        /// <summary>
        /// generate ine and hints for the board
        /// </summary>
        public void GenerateFullBoard()
        {
            Squares = Generator.InsertMinesAndHints();
            InvalidateSquares();
        }

        /// <summary>
        /// unreveal the board, returns it to its starting state
        /// </summary>
        public void UnRevealBoard()
        {
            for (int i = 0; i < GameEngine.WIDTH; i++)
                for (int j = 0; j < GameEngine.HEIGHT; j++)
                {
                    Squares[i, j].IsRevealed = false;
                    Squares[i, j].IsFlagged = false;
                    Squares[i, j].IsClicked = false;
                    if(Squares[i, j] is Mine)
                        ((Mine)Squares[i, j]).IsExploded= false;
                }
            IsRevealed = false;
            InvalidateSquares();
        }

        /// <summary>
        /// reveals the entire board
        /// </summary>
        public void RevealBoard()
        {
            for (int i = 0; i < GameEngine.WIDTH; i++)
                for (int j = 0; j < GameEngine.HEIGHT; j++)
                {
                    Squares[i, j].IsRevealed = true;
                    if(Squares[i, j] is NumberTile)
                        Squares[i, j].IsClicked= true;
                }
            IsRevealed = true;
            InvalidateSquares();
        }
    }
}
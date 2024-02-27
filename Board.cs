using Android.Content;
using Newtonsoft.Json;

namespace MineSweeper
{
    public class Board
    {
        public Square[,] Squares { get; set; }

        public Generator Generator { get; set; }
        public bool IsRevealed { get; private set; }
        public Context Context { get; set; }

        public Board(Context Context)
        {
            this.Context = Context;
            Squares = new Square[Constants.SIZE_OF_BOARD_WIDTH, Constants.SIZE_OF_BOARD_HEIGHT];
            GenerateSquares();
            IsRevealed = false;
            Generator = new Generator(this);
        }

        public Context GetContext()
        {
            return Context;
        }

        public void GenerateSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Squares[i, j] = new Square(Context, i, j);
        }

        public void InvalidateSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Squares[i, j].Invalidate();
        }

        public void GenerateFullBoard()
        {
            Squares = Generator.InsertMinesAndHints();
            InvalidateSquares();
        }

        public void UnRevealBoard()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
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

        public void RevealBoard()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                {
                    Squares[i, j].IsRevealed = true;
                    if(Squares[i, j] is NumberTile)
                        Squares[i, j].IsClicked= true;
                }
            IsRevealed = true;
            InvalidateSquares();
        }

        public Board CreateCopyBoard(Board board)
        {
            Board Board = new Board(Context);
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Board.Squares[i, j] = board.Squares[i,j];
            Board.InvalidateSquares();
            return Board;
        }

       /* public void UpdateContext( Context context)
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Squares[i, j].Context = context;
        }*/

       
    }
}
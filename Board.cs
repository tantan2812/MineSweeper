using Android.Content;

namespace MineSweeper
{
    internal class Board
    {
        public Square[,] Squares {  get; set; }
        public Generator Generator { get; set; }
        public bool IsRevealed { get; private set; }
        public Context Context { get; set; }

        public Board(Context Context)
        {
            this.Context = Context;
            Squares= new Square[Constants.SIZE_OF_BOARD_WIDTH, Constants.SIZE_OF_BOARD_HEIGHT];
            GenerateSquares();
            IsRevealed = false;
            Generator =new Generator(this);            
        }
        
        public Context GetContext()
        {
            return this.Context;
        }

        public void GenerateSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Squares[i, j] = new Square(Context, i,j);
        }

        private void InvalidateSquares()
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

        public void RevealAllSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Squares[i, j].Revealed();
            IsRevealed = true;
        }

        public void RevealOneSquare(int x,int y)
        {
            Square square = GetSquare(x,y);
            square.Revealed();
        }

        public Square GetSquare(int x, int y)
        {
            Square sq=new Square(Context);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    sq=Squares[i, j];
            return sq;
        }
    }
}
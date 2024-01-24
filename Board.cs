using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Java.Util.Jar.Attributes;

namespace MineSweeper
{
    internal class Board
    {
        public Square[,] squares {  get; set; }
        public Generator Generator { get; set; }
        public BoardAdapter Adapter { get; }
        public bool IsRevealed { get; private set; }
        public Context Context { get; set; }

        public Board(Context Context)
        {
            this.Context = Context;
            squares= new Square[Constants.SIZE_OF_BOARD_WIDTH, Constants.SIZE_OF_BOARD_HEIGHT];
            GenerateSquares();
            IsRevealed = false;
            Generator =new Generator(this);
            Adapter=new BoardAdapter(Context);
            
        }
        
        public Context GetContext()
        {
            return this.Context;
        }

        public void GenerateSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    squares[i, j] = new Square(Context, i,j);
        }

        public void GenerateFullBoard()
        {
            squares = Generator.InsertMinesAndHints();
        }

        public void AddCellsToAdapter()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    Adapter.Add(squares[i, j]);
        }

        public void RevealAllSquares()
        {
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                    squares[i, j].Revealed();
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
                    sq=squares[i, j];
            return sq;
        }

        public bool HasLocation(int X,int Y)
        {
            return X < Constants.SIZE_OF_BOARD_WIDTH && X >= 0 && Y < Constants.SIZE_OF_BOARD_HEIGHT && Y >= 0;
        }
    }
}
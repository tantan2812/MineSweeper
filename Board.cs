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

namespace MineSweeper
{
    internal class Board:Shape
    {
        public Square[,] squares {  get; set; }
        public Generator Generator { get; set; }
        public bool IsRevealed { get; private set; }
        public Context Context { get; set; }

        public Board(Context Context, float x, float y, Color color) : base(x,y,color)
        {
            this.Context = Context;
            ScreenWidth = x;
            ScreenHight = y;
            this.ShapeColor = color;
            squares= new Square[Constants.NUMBER_OF_WIDTH, Constants.NUMBER_OF_HEIGHT];
            GenerateSquares();
            IsRevealed = false;
            Generator =new Generator(this);
        }
        
        public Board(float x, float y, Color color) : base(x,y,color)
        {
            ScreenWidth = x;
            ScreenHight = y;
            this.ShapeColor = color;
            squares= new Square[Constants.NUMBER_OF_WIDTH, Constants.NUMBER_OF_HEIGHT];
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
            for (int i = 0; i < Constants.NUMBER_OF_WIDTH; i++)
                for (int j = 0; j < Constants.NUMBER_OF_HEIGHT; j++)
                    squares[i, j] = new Square(Context, i,j);
        }

        public void GenerateFullBoard()
        {
            squares = Generator.InsertMinesAndHints();
        }

        public void RevealAllSquares()
        {
            for (int i = 0; i < Constants.NUMBER_OF_WIDTH; i++)
                for (int j = 0; j < Constants.NUMBER_OF_HEIGHT; j++)
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
            return X < Constants.NUMBER_OF_WIDTH && X >= 0 && Y < Constants.NUMBER_OF_HEIGHT && Y >= 0;
        }

        public override void Draw(Canvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}
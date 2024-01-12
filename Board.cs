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
        MineGenerator mineGenerator { get; set; }
        public Board(float x, float y, Color color) : base(x,y,color)
        {
            ScreenWidth = x;
            ScreenHight = y;
            this.ShapeColor = color;
            squares= new Square[Constants.NUMBER_OF_WIDTH, Constants.NUMBER_OF_HEIGHT];
            GenerateEmptyBoard();
        }

        public void GenerateEmptyBoard()
        {
            for (int i = 0; i < Constants.NUMBER_OF_WIDTH; i++)
            {
                for (int j = 0; j < Constants.NUMBER_OF_HEIGHT; j++)
                {
                    squares[i, j] = new Square();
                }
            }
        }

        public void InsertMines()
        {
            squares = mineGenerator.PlaceMines(squares);
        }

        public void Insertvalues()
        {

        }


        public override void Draw(Canvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}
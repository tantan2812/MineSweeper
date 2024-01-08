
using System;
namespace MineSweeper.diffrent_approch
{
    internal class Generator
    {
        public static int[,] generate(int bombnumber, int width, int height)
        {
            // Random for generating numbers
            Random r = new Random();

            int[,] grid = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                //grid[x] = new int[height];
            }

            while (bombnumber > 0)
            {
                int x = r.Next(width);
                int y = r.Next(height);

                // -1 is the bomb
                if (grid[x,y] != -1)
                {
                    grid[x, y] = -1;
                    bombnumber--;
                }
            }
            grid = calculateNeigbours(grid, width, height);

            return grid;
        }

        private static int[,] calculateNeigbours(int[,] grid, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //grid[x,y] = getNeighbourNumber(grid, x, y, width, height);
                }
            }

            return grid;
        }
    }
}
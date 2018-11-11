using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Board
    {
        private int[,] matrix;

        public Board(int rows, int cols)
        {
            matrix = new int[rows, cols];
            this.FillMatrix();
        }

        public int[,] Matrix
        {
            get => matrix;
            set => matrix = value;
        }

        private void FillMatrix()
        {
            int value = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        public bool IsInside(int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}

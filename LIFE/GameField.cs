using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
{
    public class GameField // matrix
    {
        private Cell[,] _map;
        private int _rows;
        private int _columns;

        public GameField (int rows = 0, int columns = 0)
        {
            _rows = rows;   
            _columns = columns;

            _map = new Cell[rows, columns];
        }
        // cameback size of map
        public int Rows => _rows;
        public int Columns => _columns; 

        //cameback map for read
        public Cell[,] Map => _map;
        
        public int CountOfLivingCellsAround(Point2D point) // подсчитывает количество живых ячейк вокруг точки
        {
            // Карта для наглядности
            /*
                   [1] [2] [2] [2] [3] X (row) - row
                   [4] [5] [5] [5] [6]
                   [4] [5] [5] [5] [6]
                   [4] [5] [5] [5] [6] Y (column)
                   [7] [8] [8] [8] [9] |
             */

            int count_living = 0;

            // Проверка позиции  по середе (5)
            if (point.X - 1 >= 0 && point.X + 1 <= _rows - 1 &&
                point.Y - 1 >= 0 && point.Y + 1 <= _columns - 1)
            {
                count_living = CountOfLivingCellsRange(
                    point.X - 1, point.X + 1,
                    point.Y - 1, point.Y + 1,
                    point
                    );
            }
            else if (point.X == 0)                  // проверка первой строки (1-3)
            {
                if (point.Y == 0)                   // проверка левого верхнего угла (1)
                {
                    count_living = CountOfLivingCellsRange(
                        point.X, point.X + 1,
                        point.Y, point.Y + 1,
                        point);
                }
                else if (point.Y == _columns - 1)   // проверка правого верхнего угла (3)
                {
                    count_living = CountOfLivingCellsRange(
                        point.X, point.X + 1,
                        point.Y - 1, point.Y,
                        point);
                }
                else                                // проверка остальных значений первой строки (2)
                {
                    count_living = CountOfLivingCellsRange(
                        point.X, point.X + 1,
                        point.Y - 1, point.Y + 1,
                        point);
                }
            }
            else if (point.X == _rows - 1)      // проверка последней строки (7 - 9)
            {
                if (point.Y == 0)                // проверка левого нижнего угла (7)
                {
                    count_living = CountOfLivingCellsRange(
                        point.X - 1, point.X,
                        point.Y, point.Y + 1,
                        point);
                }
                else if (point.Y == _columns - 1) // проверка правого нижнего угла (9)
                {
                    count_living = CountOfLivingCellsRange(
                       point.X - 1, point.X,
                       point.Y - 1, point.Y,
                       point);
                }
                else                            // проверка остальной строки (8)
                {
                    count_living = CountOfLivingCellsRange(
                       point.X - 1, point.X,
                       point.Y - 1, point.Y + 1,
                       point);
                }
            }
            else if (point.Y == 0) // проверка первого столбца (1 - 7)
            {
                // (1) - уже проверена 
                // (7) - уже проверена 
                // Проверка остальной части столбца (4)
                count_living = CountOfLivingCellsRange(
                    point.X - 1, point.X + 1,
                    point.Y, point.Y + 1,
                    point);
            }
            else if (point.Y == _columns - 1) // проверка последнего столбца (3 - 9)
            {
                // (3) - уже проверена 
                // (9) - уже проверена 
                // Проверка остальной части столбца (6)
                count_living = CountOfLivingCellsRange(
                  point.X - 1, point.X + 1,
                  point.Y - 1, point.Y,
                  point);
            }

            return count_living;
        }
        private int CountOfLivingCellsRange(int rows_from, int rows_to,
             int columns_from, int columns_to,
             Point2D exclude_point)
        {
            int count_living = 0;

            for (int i = rows_from; i <= rows_to; i++)
            {
                for (int j = columns_from; j <= columns_to; j++)
                {
                    if (exclude_point.X == i && exclude_point.Y == j)
                        continue;

                    if (_map[i, j].IsAlive())
                    {
                        count_living++;
                    }
                }
            }

            return count_living;
        }

    }
}

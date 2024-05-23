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
        
        public int CountOfLivingCellsArround(Point2D point) // подсчитывает количество живых ячейк вокруг точки
        {

        }
        private CountOfLivingCellsRange (int rows_from, int columns_to,
           int columns_from, int rows_to, Point2D exclude_point);

    }
}

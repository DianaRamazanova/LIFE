using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
{
    public class LogicOfGame
    {
        private GameField _gameField;
        public LogicOfGame(int rows = 10, int columns = 10)
        {
            _gameField = new GameField(rows, columns);
            RandLocationAliveCells();
        }

        public LogicOfGame(List<Point2D> startLocationAliveCells, int rows = 10, int columns = 10)
        {
            _gameField = new GameField(rows, columns);
        }

        public GameField GetGameField => _gameField;
        private void RandLocationAliveCells()
        {

        }
    }
}

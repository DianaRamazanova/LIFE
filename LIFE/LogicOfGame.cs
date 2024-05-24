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
        public int Rows => _gameField.Rows;
        public int Columns => _gameField.Columns;
        public LogicOfGame(int rows = 10, int columns = 10)
        {
            _gameField = new GameField(rows, columns);
            RandLocationAliveCells();
        }

        public LogicOfGame(List<Point2D> startLocationAliveCells, int rows = 10, int columns = 10)
        {
            _gameField = new GameField(rows, columns);

            foreach (var point in startLocationAliveCells)
            {
                _gameField.Map[point.X, point.Y].State = EStateCell.Alive;
            }
        }

        public GameField GetGameField => _gameField;

        public EStateGame Update()
        {
            int count_alive_cells = 0;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    count_alive_cells = _gameField.CountOfLivingCellsAround(new Point2D(i, j));

                    if (count_alive_cells == 3 || count_alive_cells == 2)
                    {
                        if (count_alive_cells == 3 &&
                            !_gameField.Map[i, j].IsAlive())
                            _gameField.Map[i, j].State = EStateCell.Alive;
                    }
                    else
                    {
                        if (_gameField.Map[i, j].IsAlive())
                            _gameField.Map[i, j].State = EStateCell.Empty;
                    }
                }
            }
            return CheckStateGame();
        }

        private EStateGame CheckStateGame()
        {
            int count_alive_cells = 0;   

            for(int i = 0; i < Rows; i++)
            { 
                for(int j = 0; j < Columns; j++)
                {
                   if (_gameField.Map[i, j].IsAlive())
                        count_alive_cells++;
                }
            }

           if (count_alive_cells > 0)
                 return EStateGame.Run;

            return EStateGame.GameOver;
        }
        private void RandLocationAliveCells()
        {
            Random rand = new Random();
            int count_alive_cells = rand.Next(1, Rows * Columns - 1);
            Point2D point;

            for (int i = 0; i < count_alive_cells; i++)
            {
                point.X = rand.Next(0, Rows - 1);
                point.Y = rand.Next(0, Columns - 1);

                _gameField.Map[point.X, point.Y].State = EStateCell.Alive;
            }
        }
    }
}

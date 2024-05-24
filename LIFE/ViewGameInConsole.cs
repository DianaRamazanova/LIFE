using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
{
    public class ViewGameInConsole
    {
        public void View(GameField gameField)
        {
            for (int i = 0; i < gameField.Rows; i++)
            {
                for (int j = 0; j < gameField.Columns; j++)
                {
                    if (gameField.Map[i, j].IsAlive())
                    {
                        Console.Write("l ");
                    }
                    else
                    {
                        Console.Write("e ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

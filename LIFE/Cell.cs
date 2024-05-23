using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIFE
{
    public class Cell
    {
        private EStateCell _state;

        public Cell() { }
        public Cell(EStateCell state)
        {
            _state = state;
        }

        public EStateCell State // свойство чтоб менять и выводить данные
        { 
            get => _state;
            set => _state = value;
        }
         public bool IsAlive()// проверка клетки
        {
            return _state == EStateCell.Alive;
        }
    }
}

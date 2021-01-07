using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_15
{
    public class BoolMatrix
    {
        private int _lines;
        private int _columns;
        private bool[,] _Matrix;

        public int lines
        {
            get { return _lines; }
        }

        public int columns
        {
            get { return _columns; }
        }

        public bool[,] Matrix
        {
            get { return _Matrix; }
            set
            {
                _lines = value.GetLength(1);
                _columns = value.GetLength(0);
                _Matrix = value;
            }
        }

        public int TrueCount()
        {
            int count = 0;

            for (int i = 0; i < columns; i++)
                for (int j = 0; j < lines; j++)
                    if (_Matrix[i, j] == true) count++;

            return count;
        } //метод для определения количества true значений в матрице

        public bool IsEqualCountInLines() //метод для определения является ли количество false во всех строках одинаковым 
        {
            int count = 0;
            int old_count = 0;

            for (int i = 0; i < columns; i++)                                                    
            {
                for (int j = 0; j < lines; j++)
                    if (_Matrix[i, j] == false) count++;

                if (i == 0)
                {
                    old_count = count;
                    count = 0;
                    continue;
                }
                    
                if (old_count != count)
                    return false;
                else
                    count = 0;
            }

            return true;
        }

        public BoolMatrix(bool[,] M)
        {
            Matrix = M;
        }
    }
}

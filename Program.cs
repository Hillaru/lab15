using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_15
{
    class Program
    {
        static public void PrintMatrix(BoolMatrix Mat)
        {
            for (int i = 0; i < Mat.columns; i++)
            {
                for (int j = 0; j < Mat.lines; j++)
                    Console.Write(Convert.ToInt32(Mat.Matrix[i, j]));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static public void zad1()
        {
            string[] months = {"January", "February", "March",
                              "April", "May", "June", "July",
                              "August", "September", "October",
                              "November", "December"};
            int n = 5;

            var selected_months = from m in months
                                  where m.Length == n
                                  select m;

            Console.WriteLine($"Месяцы с длинной строки = { n }");
            foreach (string m in selected_months)
                Console.WriteLine(m);
            Console.WriteLine();

            selected_months = from m in months
                                  where m.Contains('u') || m == "December"
                                  select m;

            Console.WriteLine("Только зимние и летние месяцы");
            foreach (string m in selected_months)
                Console.WriteLine(m);
            Console.WriteLine();

            selected_months = from m in months
                              orderby m
                              select m;

            Console.WriteLine("Месяцы в алфавитном порядке");
            foreach (string m in selected_months)
                Console.WriteLine(m);
            Console.WriteLine();

            selected_months = from m in months
                              where m.Contains('u') && m.Length >= 4
                              select m;

            Console.WriteLine("Месяцы содержащие букву 'u' и длиной не менее 4 символов");
            foreach (string m in selected_months)
                Console.WriteLine(m);

            Console.ReadKey();
        }

        static public void zad2()
        {
            Random rand = new Random();
            List<BoolMatrix> MatrixList = new List<BoolMatrix> { };

            int n = 200, max_col = 10, max_lin = 10;  //n - количество генерируемых матриц, max_col и max_lin - максимальные размеры матриц

            for (int k = 0; k < n; k++)
            {
                int lines = rand.Next() % max_lin + 2;
                int columns = rand.Next() % max_col + 2;
                bool[,] Mat = new bool[columns, lines];

                for (int i = 0; i < columns; i++)
                    for (int j = 0; j < lines; j++)
                        Mat[i, j] = Convert.ToBoolean(rand.Next() % 2);

                MatrixList.Add(new BoolMatrix(Mat));
            }

            var SelectedList = from mat in MatrixList
                                let minNum = MatrixList.Min(a => a.TrueCount())
                                where mat.TrueCount() == minNum
                                select mat;

            Console.WriteLine("Матрицы с минимальным количеством true");
            foreach (BoolMatrix m in SelectedList)
                PrintMatrix(m);

            Console.ReadKey();
            Console.Clear();

            SelectedList = from mat in MatrixList
                           where mat.IsEqualCountInLines()
                           select mat;

            Console.WriteLine("Список матриц с равным количеством false  в каждой строке");
            foreach (BoolMatrix m in SelectedList)
                PrintMatrix(m);

            Console.ReadKey();
            Console.Clear();

            SelectedList = from mat in MatrixList
                           let maxLength = MatrixList.Max(a => a.Matrix.Length)
                           where mat.Matrix.Length == maxLength
                           select mat;

            Console.WriteLine("Матрицы с максимаьным количеством элементов");
            foreach (BoolMatrix m in SelectedList)
                PrintMatrix(m);

            Console.ReadKey();
            Console.Clear();

            int currentColumns = 5, currentLines = 5; //размеры матриц для выборки

            SelectedList = from mat in MatrixList
                           where mat.lines == currentLines && mat.columns == currentColumns
                           select mat;

            Console.WriteLine($"Матрицы с { currentColumns } колоноками и { currentLines } строками");
            foreach (BoolMatrix m in SelectedList)
                PrintMatrix(m);

            Console.ReadKey();
            Console.Clear();

            SelectedList = from mat in MatrixList
                           orderby mat.TrueCount()
                           select mat;

            Console.WriteLine("Матрицы yпорядоченные по возрастанию количества true значений");
            int str = 0;
            foreach (BoolMatrix m in SelectedList)
            {
                if (str == 25)
                {
                    Console.WriteLine("Нажмите любую клавишу для загрузки следующей чаcти списка");
                    Console.ReadKey();
                    Console.Clear();
                    str = 0;
                }

                PrintMatrix(m);
                str++;
            }
                

            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine();
            zad1();

            Console.Clear();
            Console.WriteLine("Задание 2, 3, 4");
            Console.WriteLine("Для следующего запроса нажимайте любую клавишу");
            Console.WriteLine();
            zad2();
        }
    }
}

//Решить алгоритмическую задачу: Multiply matrixes (Перемножить матрицы)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {

        //Функция ввода количества строк и столбцов матрицы
        public static int TypeSizeMatrix(string stroki, string numbermatrix)
        {
            int i = 0;
            int n = 0;
            string nstrmatr = "";
            for (i = 0; i == n; i++)
            {
                try
                {
                    Console.WriteLine("Введите количество " + stroki + " " + numbermatrix + " матрицы. Максимальный размер 10.");
                    nstrmatr = Console.ReadLine();
                    int nm = Convert.ToInt32(nstrmatr);
                    while (nm > 10 || nm<1)
                    {
                        Console.WriteLine("Неправильное количество " + stroki + ".Введите значение от 1 до 10.");
                        Console.WriteLine("Введите количество " + stroki + " " + numbermatrix + " матрицы");
                        nstrmatr = Console.ReadLine();
                        nm = Convert.ToInt32(nstrmatr);
                    } 
                    return nm;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введённые вами данные не верны");
                    n++;
                }
            }
            return 0;
        }


        // Функция ввода элементов матрицы
        public static double[,] TypeMatrix(string ntmatrix, int nmf, int mmf)
        {
            double[,] arraymatrfunc = new double[10, 10];
            int q = 0;
            int w = 0;
            int k = 0;
            
            string tempfres = "";
            for (q = 1; q <= nmf; q++)
            {
                for (w = 1; w <= mmf; w++)
                {
                    int l = 0;
                    for (k = 0; k == l; k++)
                    {
                        try
                        {
                            Console.WriteLine("Введите " + q + w + " элемент "+ntmatrix+" матрицы");
                            tempfres = Console.ReadLine();
                            arraymatrfunc[q, w] = Convert.ToDouble(tempfres);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Введённые данные не верны. Попробуйте снова.");
                            l++;
                        }
                    }
                }
            }
            return arraymatrfunc;
        }


        // Функция вывода матрицы на экран
        public static string ViewMatrix(string nmatrix, int nmfv, int mmfv, double[,] vmatrix)
        {
            int s = 0;
            int d = 0;
            Console.WriteLine(nmatrix+" матрица имеет вид:");
            for (s = 1; s <= nmfv; s++)
            {
                for (d = 1; d <= mmfv; d++)
                {
                    Console.Write(vmatrix [s, d] + " ");
                }
                Console.WriteLine();
            }
            return "";
        }




        static void Main(string[] args)
        {
            int l = 0;
            int j = 0;
            int m = 0;
            int nm1 = 0;
            int mm1 = 0;
            int nm2 = 0;
            int mm2 = 0;
            double[,] arraymatr1 = new double[10,10];
            double[,] arraymatr2 = new double[10, 10];
            double[,] arrayresmatr = new double[10, 10];
            string conf = "";
            nm1 = TypeSizeMatrix("строк", "первой");
            mm1 = TypeSizeMatrix("столбцов", "первой");
            nm2 = TypeSizeMatrix("строк", "второй");
            mm2 = TypeSizeMatrix("столбцов", "второй");
            //Проверка на одинаковое количества строк первой матрицы и столбцов второй
            while (mm1 != nm2)
            {
                Console.WriteLine("Число столбцов первой матрицы не совпадает с числом строк второй матрицы. Умножение невозможно! Попробуйет ввести корректные данные.");
                mm1 = TypeSizeMatrix("столбцов", "первой");
                nm2 = TypeSizeMatrix("строк", "второй");
            }
            //Ввод элементов первой матрицы 
            arraymatr1 = TypeMatrix("первой",nm1, mm1);
            //Ввод элементов второй матрицы
            arraymatr2 = TypeMatrix("второй",nm2, mm2);
            //Вывод первой матрицы
            ViewMatrix("Первая",nm1, mm1, arraymatr1);
            //Вывод второй матрицы
            ViewMatrix("Вторая", nm2, mm2, arraymatr2);
            //Запрос на выполнение умножения двух матриц
            Console.WriteLine("Выполнить умножение первой матрицы на вторую? y/n");
            conf = Console.ReadLine();
            while (conf != "y" && conf != "n")
            {
                Console.WriteLine("Не могу понять ваш ответ. Выполнить умножение первой матрицы на вторую? y/n");
                conf = Console.ReadLine();
            }
            if (conf == "y")
            {
                //Вычисление элементов матрицы умножения
                for (j = 1; j <= nm1; j++)
                {
                    for (m = 1; m <= mm2; m++)
                    {
                        for (l = 1; l <= mm1; l++)
                        {
                            arrayresmatr[j, m] = arrayresmatr[j, m] + arraymatr1[j, l] * arraymatr2[l, m];
                        }
                    }
                }
                //Вывод результата
                ViewMatrix ("Результирующая", nm1, mm2, arrayresmatr);
            }
            //При отмене вычисления
            if (conf == "n")
            {
                Console.WriteLine ("Извините за беспокойство.");
            }
            Console.ReadLine();
        }
    }
}

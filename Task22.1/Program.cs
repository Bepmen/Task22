using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task22._1
{
    internal class Program
    {


        static void Main(string[] args)
        {

            /*
             
            Сформировать массив случайных целых чисел (размер  задается пользователем). 
            Вычислить сумму чисел массива и максимальное число в массиве.  Реализовать  
            решение  задачи  с  использованием  механизма  задач продолжения. 
             
            */

            Console.Write("Задайте размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.Write($" {array[i]}");
            }
            
            Console.WriteLine();
            
            Task task1 = new Task(SummArray);
            Task task2 = task1.ContinueWith(MaxArray);

            task1.Start();
            Console.ReadKey();

            void SummArray()
            {
                int summ = 0;
                for (int i = 0; i < n; i++)
                {
                    summ += array[i];
                }
                Console.WriteLine($"Сумма чисел массива равна {summ}.");
            }
            void MaxArray(Task task)
            {
                int max = 0;
                for (int i = 0; i < n; i++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                    }
                }
                Console.WriteLine($"Максимальное число в массиве {max}");
            }

        }

    }
}

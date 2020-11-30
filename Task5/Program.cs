using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Введите любую цифру");
            int num = Int32.Parse(Console.ReadLine());
            TaskCompletionSource<int[]> tcs1 = new TaskCompletionSource<int[]>();
            Task<int[]> t1 = tcs1.Task;

            Task.Factory.StartNew(() =>
            {
                var res = new int[num];
                for(var i = 0; i < num; i++)
                {
                    res[i] = i;
                }

                tcs1.SetResult(res);
            });
            int[] result = t1.Result;
            foreach (var item in result)
                Console.Write($" {item}");
        }   
    }
}

//Задание 5
//Создайте приложение по шаблону Console Application. Запросите у пользователя любое число. 
//Создайте асинхронную операцию с помощью класса TaskCompletionSource, которая в контексте 
//потока из пула, считает всю последовательность чисел от 0 до указанного пользователем числа. 
//Результат задачи выведите на экран консоли.

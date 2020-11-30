using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            File.Create("test.txt").Dispose();
            Console.WriteLine($"Введите любой текст: ");
            string text = Console.ReadLine();
            await WriteToFileAsync(text);
        }
        private static async Task WriteToFileAsync(string text)
        {
            using (FileStream fs = new FileStream("test.txt", FileMode.Open, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.Asynchronous))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }

        }
    }
}

//Задание 2
//Создайте приложение по шаблону Console Application. Создайте асинхронный метод 
//WriteToFileAsync, который в асинхронном режиме производит запись в файл. Организуйте ввод 
//сообщений с клавиатуры в консоли. Результат ввода данных пользователем должен быть записан 
//в файл с помощью вашего асинхронного метода WriteToFileAsync.

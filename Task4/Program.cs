using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {

        private static HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            await DownloadHtmlAsync();
        }

        private static async Task DownloadHtmlAsync()
        {
            string httpContent = await httpClient.GetStringAsync("https://itvdn.com/");
            await CountWordsAsync(httpContent);
        }

        private static async Task CountWordsAsync(string httpContent, string searchTerm = "ITVDN")
        {
            var wordCount = await Task.Run(() => httpContent.Split(new[] { searchTerm }, StringSplitOptions.None).Length - 1);

            Console.WriteLine("{0} слов \"{1}\".", wordCount, searchTerm);
            Console.ReadKey();
        }
    }
}

//Задание 4
//Создайте приложение по шаблону Console Application. Создайте асинхронный метод, который 
//асинхронно загружает html код сайта itvdn.com. Создайте асинхронный метод, который 
//асинхронно считает количество упоминаний аббревиатуры «ITVDN» скачанного html кода 
//главной страницы. Выведите результат на экран консоли.

using System;
using MyLibrary;

namespace ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_SIZE = 2;
            const int MAX_SIZE = 100;

            int n = AskData.ReadIntNumber("Введите количество элементов поледовательности (от 2 до 100):", MIN_SIZE, MAX_SIZE);
            List list = List.MakeList(n);
            List.ShowList(list);

            Console.WriteLine("Для завершения работы нажмите Enter");
            Console.ReadLine();
        }
    }
}

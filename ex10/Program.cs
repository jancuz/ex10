using System;
using MyLibrary;

namespace ex10
{
    class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("1. Создать однонаправленный список.");
            Console.WriteLine("2. Напечатать список.");
            Console.WriteLine("3. Добавить элемент с заданным номером.");
            Console.WriteLine("4. Удалить элемент с заданным номером.");
            Console.WriteLine("5. Выход.");
        }

        static void Run()//работа с однонаправленными списками
        {
            int checkRun1 = 0, left = 1, right = 5, number = 0;
            int size = 0;
            const int MIN_SIZE = 2;
            const int MAX_SIZE = 100;
            LinkedList beg = null;
            do
            {
                PrintMenu();
                checkRun1 = AskData.ReadIntNumber("Введите номер пункта, который хотите выполнить", left, right);
                switch (checkRun1)
                {
                    case 1: //создать список
                        {
                            size = AskData.ReadIntNumber("Введите количество элементов списка (от 2 до 100):", MIN_SIZE, MAX_SIZE);
                            beg = LinkedList.MakeList(ref size);
                            break;
                        }

                    case 2: //печать списка
                        {
                            LinkedList.ShowList(beg);
                            break;
                        }

                    case 3: //добавить элемент
                        {
                            beg = LinkedList.RunAddPoint(beg, number, ref size);
                            break;
                        }
                    case 4:
                        {
                            int numDel = AskData.ReadIntNumber("Введите номер элемента для удаления", 1, MAX_SIZE);
                            beg = LinkedList.DelElement(beg, numDel);
                            break;
                        }
                }
            } while (checkRun1 != right);

        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}

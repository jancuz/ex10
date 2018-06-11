using System;
using MyLibrary;

namespace ex10
{
    class List
    {
        public int data;//информационное поле
        public List next;//адресное поле
        public List()//конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public List(int d)//конструктор с параметрами
        {
            data = d;
            next = null;
        }
        public override string ToString()
        {
            return data + " ";
        }

        const int MININT_VALUE = -100;
        const int MAXINT_VALUE = 100;

        //создание элемента списка
        static List MakePoint(int d)
        {
            List p = new List(d);
            return p;
        }

        public static List MakeList(int size) //добавление в конец
        {
            int info = AskData.ReadIntNumber("Введите 1 элемент: ", MININT_VALUE, MAXINT_VALUE);
            List beg = MakePoint(info);
            List r = beg;
            for (int i = 2; i <= size; i++)
            {
                Console.Write("Введите {0} элемент:", i);
                info = AskData.ReadIntNumber("", MININT_VALUE, MAXINT_VALUE);
                List p = MakePoint(info);
                r.next = p;
                r = p;
            }
            return beg;
        }

        // печать элементов списка
        public static void ShowList(List beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            List p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }
    }
}

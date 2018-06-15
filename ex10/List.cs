using System;
using MyLibrary;

namespace ex10
{
    class LinkedList
    {
        public int data;//информационное поле
        public LinkedList next;//адресное поле
        public LinkedList()//конструктор без параметров
        {
            data = 0;
            next = null;
        }
        public LinkedList(int d)//конструктор с параметрами
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
        const int MIN_SIZE = 1;
        const int MAX_SIZE = 100;

        static void PrintForm()
        {
            Console.WriteLine("Введите номер пункта, который хотите выполнить:");
            Console.WriteLine("1. Ввести с клавиатуры");
            Console.WriteLine("2. С помощью ДСЧ");
            Console.WriteLine("3. Назад");
        }

        public static LinkedList MakeList(ref int size) //для формирования списка двумя способами
        {
            int checkMakeList = 0;
            LinkedList beg = null;
            PrintForm();
            checkMakeList = AskData.ReadIntNumber("", 1, 3);
            switch (checkMakeList)
            {
                case 1: beg = MakeListToEndHand(size); Console.WriteLine("Однонаправленный список сформирован"); break;
                case 2: beg = MakeListToEndRandom(size); Console.WriteLine("Однонаправленный список сформирован"); break;
                case 3: size = 0; Console.WriteLine("Однонаправленный список не сформирован!"); break;
            }
            return beg;
        }

        //создание элемента списка
        static LinkedList MakePoint(int d)
        {
            LinkedList p = new LinkedList(d);
            return p;
        }

        static readonly Random rnd = new Random();

        //формирование списка из n элементов путем добавления элементов в конец списка с помощью ДСЧ
        static LinkedList MakeListToEndRandom(int size)
        {
            Random rnd = new Random();
            int info = rnd.Next(MININT_VALUE, MAXINT_VALUE);
            LinkedList beg = MakePoint(info);
            for (int i = 2; i <= size; i++)
            {
                info = rnd.Next(MININT_VALUE, MAXINT_VALUE);
                LinkedList p = MakePoint(info);
                p.next = beg;
                beg = p;
            }
            return beg;
        }

        //формирование списка из n элементов путем добавления элементов в конец списка с клавиатуры
        static LinkedList MakeListToEndHand(int size) //добавление в конец
        {
            Console.WriteLine("Введите 1 элемент:");
            int info = AskData.ReadIntNumber("Введите 1 элемент (от -100 до 100):", MININT_VALUE, MAXINT_VALUE);
            LinkedList beg = MakePoint(info);
            LinkedList r = beg;
            for (int i = 2; i <= size; i++)
            {
                Console.WriteLine("Введите {0} элемент:", i);
                info = AskData.ReadIntNumber("", MININT_VALUE, MAXINT_VALUE);
                LinkedList p = MakePoint(info);
                r.next = p;
                r = p;
            }
            return beg;
        }

        public static void ShowList(LinkedList beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            LinkedList p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }

        public static LinkedList RunAddPoint(LinkedList beg, int number, ref int size) //для добавления элемента списка двумя способами
        {
            int check = 0;
            LinkedList NewPoint = null;
            PrintForm();
            check = AskData.ReadIntNumber("", 1, 3);
            switch (check)
            {
                case 1: NewPoint = FormAddPointHand(NewPoint); beg = AddPoint(beg, NewPoint, number, ref size); break;
                case 2: NewPoint = FormAddPointRandom(NewPoint); beg = AddPoint(beg, NewPoint, number, ref size); break;
                case 3: Console.WriteLine("Элемент не был добавлен!"); break;
            }
            return beg;
        }

        static LinkedList FormAddPointHand(LinkedList NewPoint)
        {
            int info = AskData.ReadIntNumber("Введите элемент, который хотите добавить:", MININT_VALUE, MAXINT_VALUE);//создаем новый элемент
            NewPoint = MakePoint(info);//создаем добавляемый элемент
            return NewPoint;
        }

        static LinkedList FormAddPointRandom(LinkedList NewPoint)
        {
            int info = rnd.Next(MININT_VALUE, MAXINT_VALUE);
            //создаем новый элемент
            NewPoint = MakePoint(info);//создаем добавляемый элемент
            return NewPoint;
        }

        static LinkedList AddPoint(LinkedList beg, LinkedList NewPoint, int number, ref int size)
        {
            do
            {
                number = AskData.ReadIntNumber("Введите номер элемента для добавления", MIN_SIZE, MAX_SIZE);
                if (number > size + 1) Console.WriteLine("Ошибка! Размер списка меньше введенного числа.");
            } while (number > size + 1);

            if (number == 1) //добавление в начало списка
            {
                NewPoint.next = beg;
                beg = NewPoint;
                size++;
                Console.WriteLine("Элемент был добавлен на 1 позицию");
                return beg;
            }
            //вспом. переменная для прохода по списку
            LinkedList p = beg;
            //идем по списку до нужного элемента
            for (int i = 1; i < number - 1 && p.next != null; i++)
                p = p.next;
            //добавляем новый элемент
            NewPoint.next = p.next;
            p.next = NewPoint;
            Console.WriteLine("Элемент был добавлен на {0} позицию", number);
            size++;
            return beg;
        }

        //удаление из однонаправленного списка элемента с заданным номером
        public static LinkedList DelElement(LinkedList beg, int number)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Список пуст!");
                return null;
            }
            if (number == 1)//удаляем первый элемент
            {
                beg = beg.next;
                return beg;
            }
            LinkedList p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Ошибка! Количество элементов в списке меньше введенного числа.");
                return beg;
            }
            //исключаем элемент из списка
            p.next = p.next.next;
            Console.WriteLine("Элемент под номером {0} удален.", number);
            return beg;
        }

    }
}

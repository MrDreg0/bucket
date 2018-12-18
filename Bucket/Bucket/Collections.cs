using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Collections
    {
//------A.1 Массивы (Array)
        public void ExampleArray()
        {
            //Создаем одномерный массив
            int[] Array1 = { 5, 6, 3, 9 };

            //Создаем двухмерный массив
            int[,] Array2 = new int[2, 4];

            //Создаем ступенчатый массив
            int[][] Array3 = new int[2][];

            //Поиск в одномерном массиве
            //Сложность метода О(n), где n - длинна массива
            Console.WriteLine(Array.Find(Array1, n => n == 3));
            Console.WriteLine();

            //Сортировка одномерного массива
            Array.Sort(Array1);

            //Показать коллекцию
            foreach (var item in Array1)
            {
                Console.WriteLine(item);
            }

            //Бинарный поиск в массиве
            //Сложность метода О(log n), где n - длинна массива
            var value = 6;
            Console.WriteLine();
            Console.WriteLine(Array.BinarySearch(Array1, value));
        }

//------A.2 Список (List<T>)
        public void ExampleList()
        {
            //Создаем пустой список
            List<int> List1 = new List<int>();

            //Создаем список с указанной емкостью
            List<int> List2 = new List<int>(5);

            //Добавить в список значение
            //Если Count < Capacity сложность = О(1), иначе О(n), где n - Count
            List1.Add(5);

            //Добавить в список несколько значений
            //Если элементы можно вставить не увеличивая емкость списка, то сложность = O(n), где n - количество добавляемых элементов
            //иначе сложность O(n + m), где n - Count, a m - количество добавляемых элементов
            int[] list = { 4, 3, 8, 2, 1, 7, 10, 6 };
            List1.AddRange(list);

            //Показать коллекцию
            foreach (var item in List1)
            {
                Console.WriteLine(item);
            }

            //Удаление элемента из списка
            //Сложность метода О(n), где n - Count
            List1.Remove(3);

            //Удаление диапазона значений из спика
            //Сложность метода O(n), где n - Count
            List1.RemoveRange(1, 3);

            //Удаление элементов, удовлетворяющих условию
            //Сложность метода O(n), где n - Count
            List1.RemoveAll(item => item > 3);

            //Усечение избыточной емкости стписка
            //Сложность метода O(n), где n - Count
            List1.TrimExcess();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in List1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Count:" + List1.Count());
            Console.WriteLine("Capacity: " + List1.Capacity);
        }

//------A.3 Двойной связанный список (LinkedList<T>)
        public void ExampleLinkedList()
        {
            //Создаем пустой список
            LinkedList<string> LList = new LinkedList<string>();

            //Добавить элемент в начало списка
            //Сложность метода O(1)
            LList.AddFirst("One");
            LList.AddFirst("Seven");
            LList.AddFirst("Five");

            //Добавить элемент в конец списка
            //Сложность метода O(1)
            LList.AddLast("Two");

            //Показать коллекцию
            foreach (var item in LList)
            {
                Console.WriteLine(item);
            }

            //Получить узел списка
            //Сложность метода O(n), где n - Count
            LList.Find("Five");

            //Получить следующий узел списка
            Console.WriteLine(LList.Find("Seven").Next);

            //Получить предыдущий узел списка
            Console.WriteLine(LList.Find("Seven").Previous);
        }

//------A.4 Стэк (Stack<T>)
        public void ExampleStack()
        {   
            //Создаем пустой стек
            Stack<int> Stack = new Stack<int>();

            //Добавить элемент на вершину стека
            //Если размер стека больше Count стека, то сложность O(1), иначе О(n), где n - Count
            Stack.Push(4);
            Stack.Push(1);
            Stack.Push(8);
            Stack.Push(7);

            //Показать коллекцию
            foreach (var item in Stack)
            {
                Console.WriteLine(item);
            }

            //Получить элемент с вершины стека
            //Сложность метода О(1)
            Stack.Peek();

            //Поднять элемент с вершины стека
            //Сложность метода О(1)
            Stack.Pop();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in Stack)
            {
                Console.WriteLine(item);
            }
        }

//------A.5 Очередь (Queue<T>)
        public void ExampleQueue()
        {
            //Создаем пустую очередь
            Queue<int> Queue = new Queue<int>();

            //Добавить элемент в конец очереди
            //Если размер очереди больше Count очереди, то сложность O(1), иначе О(n), где n - Count
            Queue.Enqueue(3);
            Queue.Enqueue(5);
            Queue.Enqueue(1);

            //Показать коллекцию
            foreach (var item in Queue)
            {
                Console.WriteLine(item);
            }

            //Получить элемент из конца очереди
            //Сложность метода О(1)
            Queue.Peek();

            //Поднять элемент из конца очереди
            //Сложность метода О(1)
            Queue.Dequeue();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in Queue)
            {
                Console.WriteLine(item);
            }
        }

//------A.6 Отсортированный ассоциативный список (SortedList<TKey, TValue>)
        public void ExampleSortedList()
        {
            //Создаем пустой отсортированный список
            SortedList<int, string> SList = new SortedList<int, string>();

            //Добавить в список пару ключ-значение
            //Сложность операции О(n)
            SList.Add(13, "Tom");
            SList.Add(7, "Jenna");
            SList.Add(4, "Kit");
            SList.Add(8, "Lex");
            SList.Add(22, "Johan");

            //Показать коллекцию
            foreach (var item in SList)
            {
                Console.WriteLine(item);
            }

            //Получить значение по ключу с помощью индексатора
            //Сложность операции О(log n)
            Console.WriteLine(SList[13]);

            //Получить значение по ключу с помощью TryGetValue
            //Сложность операции О(log n)
            SList.TryGetValue(8, out string value);
            Console.WriteLine(value);

            //Проверить содержит ли список указанный ключ
            //Сложность операции О(log n)
            Console.WriteLine(SList.ContainsKey(10));

            //Проверить содержит ли список указанное значение
            //Сложность операции О(n)
            Console.WriteLine(SList.ContainsValue("Johan"));

            //Получить индекс по ключу
            //Сложность операции О(log n)
            Console.WriteLine(SList.IndexOfKey(4));

            //Получить индекс по значению
            //Сложность операции О(n)
            Console.WriteLine(SList.IndexOfValue("Lex"));

            //Удалить элемент по ключу
            //Сложность операции О(n)
            SList.Remove(8);

            //Удалить элемент по значению
            //Сложность операции О(n)
            SList.RemoveAt(1);

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in SList)
            {
                Console.WriteLine(item);
            }
        }

//------B.1 Отсортированное множество (SortedSet<T>)
        public void ExampleSortedSet()
        {   
            //Создаем новое отсортированное множество
            SortedSet<string> SSet = new SortedSet<string>();

            //Добавить элемент в множество
            SSet.Add("One");
            SSet.Add("Two");
            SSet.Add("Three");
            SSet.Add("Two");
            SSet.Add("Seven");

            //Показать коллекцию
            foreach (var item in SSet)
            {
                Console.WriteLine(item);
            }

            //Проверить наличие элемента в множестве
            //Сложность операции О(log n)
            SSet.Contains("Two");

            //Удалить элемент из множества
            //Сложность операции О(log n)
            SSet.Remove("One");

            //Операция Union
            SortedSet<string> SSet1 = new SortedSet<string>() { "One", "Five", "Six", "Two", "Seven" };
            SSet.UnionWith(SSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация Union");
            foreach (var item in SSet)
            {
                Console.WriteLine(item);
            }

            //Операция Intersect
            SortedSet<string> SSet2 = new SortedSet<string>() { "Six", "Two", "Seven", "Ten" };
            SSet.IntersectWith(SSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Intersect");
            foreach (var item in SSet)
            {
                Console.WriteLine(item);
            }

            //Операция Expect
            SSet1.ExceptWith(SSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Expect");
            foreach (var item in SSet1)
            {
                Console.WriteLine(item);
            }

            //Операция SymmetricExpect
            SSet2.SymmetricExceptWith(SSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация SymmetricExpect");
            foreach (var item in SSet2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Проверка isSubset
            Console.WriteLine(SSet1.IsSubsetOf(SSet));

            //Проверка isSuperset
            Console.WriteLine(SSet2.IsSupersetOf(SSet));

        }

//------B.2 Отсортированный словарь (SortedDictionary<TKey, TValue>)
        public void ExampleSDictionary()
        {
            //Создадим пустой словарь
            SortedDictionary<int, int> SDictionary = new SortedDictionary<int, int>();

            //Добавить в словарь пару ключ-значение
            SDictionary.Add(5, 100);
            SDictionary.Add(3, 400);
            SDictionary.Add(7, 200);
            SDictionary.Add(6, 300);

            //Получить значение по ключу с помощью индексатора
            Console.WriteLine(SDictionary[7]);

            //Получить значение с помощью TryGetValue
            Console.WriteLine(SDictionary.TryGetValue(5, out int value));

            //Проверить, содержит ли словарь указанный ключ
            Console.WriteLine(SDictionary.ContainsKey(10));

            //Проверить, содержить ли словарь указанное значение
            Console.WriteLine(SDictionary.ContainsValue(300));

            //Удалить элемент по ключу
            SDictionary.Remove(7);

            //Показать коллекцию
            foreach (var item in SDictionary)
            {
                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
            }
        }

//------C.1 Множество на основе хеш-таблиц (HashSet<T>)
        public void ExampleHSet()
        {
            //Создаем пустое множество
            HashSet<string> HSet = new HashSet<string>();

            //Добавить элемент в множество
            HSet.Add("One");
            HSet.Add("Two");
            HSet.Add("Three");
            HSet.Add("Four");
            HSet.Add("Ten");

            //Проверить наличие элемента в множестве
            HSet.Contains("One");

            //Удалить элемент из множества
            HSet.Remove("Ten");

            //Операция Union
            HashSet<string> HSet1 = new HashSet<string>() { "One", "Five", "Six" };
            HSet1.UnionWith(HSet);

            //Показать коллекцию
            Console.WriteLine("\nОперация Union");
            foreach (var item in HSet1)
            {
                Console.WriteLine(item);
            }

            //Операция Intersect
            HashSet<string> HSet2 = new HashSet<string>() { "Seven", "Six", "Five", "Ten" };
            HSet2.IntersectWith(HSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация Intersect");
            foreach (var item in HSet2)
            {
                Console.WriteLine(item);
            }

            //Оперция Expect
            HSet.ExceptWith(HSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Expect");
            foreach (var item in HSet2)
            {
                Console.WriteLine(item);
            }

            //Оперция SymetricExpect
            HSet.SymmetricExceptWith(HSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация SymetricExpect");
            foreach (var item in HSet2)
            {
                Console.WriteLine(item);
            }

            //Проверка isSubset
            Console.WriteLine(HSet1.IsSubsetOf(HSet));

            //Проверка isSuperset
            Console.WriteLine(HSet2.IsSupersetOf(HSet));
        }

//------C.1 Множество на основе хеш-таблиц (HashSet<T>)
        public void ExampleDictionary()
        {
            //Создадим пустой словарь
            Dictionary<int, string> Dictionary = new Dictionary<int, string>();

            //Добавить пару ключ-значение
            Dictionary.Add(2, "Two");
            Dictionary.Add(3, "Three");
            Dictionary.Add(1, "One");
            Dictionary.Add(5, "Five");

            //Получить значение по ключу с помощью индексатора
            Console.WriteLine(Dictionary[2]);

            //Получить значение с помощью TryGetValue
            Console.WriteLine(Dictionary.TryGetValue(5, out string value));

            //Проверить, содержит ли словарь указанный ключ
            Console.WriteLine(Dictionary.ContainsKey(7));

            //Проверить, содержит ли словарь указанное зачение
            Console.WriteLine(Dictionary.ContainsValue("Two"));

            //Удалить элемент по ключу
            Dictionary.Remove(1);

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in Dictionary)
            {
                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
            }
        }
    }
}

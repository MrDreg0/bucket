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
            int[] array1 = { 5, 6, 3, 9 };

            //Создаем двухмерный массив
            var array2 = new int[2, 4];

            //Создаем ступенчатый массив
            var array3 = new int[2][];

            //Поиск в одномерном массиве
            //Сложность метода О(n), где n - длинна массива
            Console.WriteLine(Array.Find(array1, n => n == 3));
            Console.WriteLine();

            //Сортировка одномерного массива
            Array.Sort(array1);

            //Показать коллекцию
            foreach (var item in array1)
                Console.WriteLine(item);

            //Бинарный поиск в массиве
            //Сложность метода О(log n), где n - длинна массива
            var value = 6;
            Console.WriteLine();
            Console.WriteLine(Array.BinarySearch(array1, value));
        }

//------A.2 Список (List<T>)
        public void ExampleList()
        {
            //Создаем пустой список
            var list1 = new List<int>();

            //Создаем список с указанной емкостью
            var list2 = new List<int>(5);

            //Добавить в список значение
            //Если Count < Capacity сложность = О(1), иначе О(n), где n - Count
            list1.Add(5);

            //Добавить в список несколько значений
            //Если элементы можно вставить не увеличивая емкость списка, то сложность = O(n), где n - количество добавляемых элементов
            //иначе сложность O(n + m), где n - Count, a m - количество добавляемых элементов
            int[] array = { 4, 3, 8, 2, 1, 7, 10, 6 };
            list1.AddRange(array);

            //Показать коллекцию
            foreach (var item in list1)
                Console.WriteLine(item);

            //Удаление элемента из списка
            //Сложность метода О(n), где n - Count
            list1.Remove(3);

            //Удаление диапазона значений из спика
            //Сложность метода O(n), где n - Count
            list1.RemoveRange(1, 3);

            //Удаление элементов, удовлетворяющих условию
            //Сложность метода O(n), где n - Count
            list1.RemoveAll(item => item > 3);

            //Усечение избыточной емкости стписка
            //Сложность метода O(n), где n - Count
            list1.TrimExcess();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in list1)
                Console.WriteLine(item);
            Console.WriteLine("Count:" + list1.Count());
            Console.WriteLine("Capacity: " + list1.Capacity);
        }

//------A.3 Двойной связанный список (LinkedList<T>)
        public void ExampleLinkedList()
        {
            //Создаем пустой список
            var lList = new LinkedList<string>();

            //Добавить элемент в начало списка
            //Сложность метода O(1)
            lList.AddFirst("One");
            lList.AddFirst("Seven");
            lList.AddFirst("Five");

            //Добавить элемент в конец списка
            //Сложность метода O(1)
            lList.AddLast("Two");

            //Показать коллекцию
            foreach (var item in lList)
                Console.WriteLine(item);

            //Получить узел списка
            //Сложность метода O(n), где n - Count
            lList.Find("Five");

            //Получить следующий узел списка
            Console.WriteLine(lList.Find("Seven").Next);

            //Получить предыдущий узел списка
            Console.WriteLine(lList.Find("Seven").Previous);
        }

//------A.4 Стэк (Stack<T>)
        public void ExampleStack()
        {
            //Создаем пустой стек
            var stack = new Stack<int>();

            //Добавить элемент на вершину стека
            //Если размер стека больше Count стека, то сложность O(1), иначе О(n), где n - Count
            stack.Push(4);
            stack.Push(1);
            stack.Push(8);
            stack.Push(7);

            //Показать коллекцию
            foreach (var item in stack)
                Console.WriteLine(item);

            //Получить элемент с вершины стека
            //Сложность метода О(1)
            stack.Peek();

            //Поднять элемент с вершины стека
            //Сложность метода О(1)
            stack.Pop();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in stack)
                Console.WriteLine(item);
        }

//------A.5 Очередь (Queue<T>)
        public void ExampleQueue()
        {
            //Создаем пустую очередь
            var queue = new Queue<int>();

            //Добавить элемент в конец очереди
            //Если размер очереди больше Count очереди, то сложность O(1), иначе О(n), где n - Count
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(1);

            //Показать коллекцию
            foreach (var item in queue)
                Console.WriteLine(item);

            //Получить элемент из конца очереди
            //Сложность метода О(1)
            queue.Peek();

            //Поднять элемент из конца очереди
            //Сложность метода О(1)
            queue.Dequeue();

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in queue)
                Console.WriteLine(item);
        }

//------A.6 Отсортированный ассоциативный список (SortedList<TKey, TValue>)
        public void ExampleSortedList()
        {
            //Создаем пустой отсортированный список
            var sList = new SortedList<int, string>();

            //Добавить в список пару ключ-значение
            //Сложность операции О(n)
            sList.Add(13, "Tom");
            sList.Add(7, "Jenna");
            sList.Add(4, "Kit");
            sList.Add(8, "Lex");
            sList.Add(22, "Johan");

            //Показать коллекцию
            foreach (var item in sList)
                Console.WriteLine(item);

            //Получить значение по ключу с помощью индексатора
            //Сложность операции О(log n)
            Console.WriteLine(sList[13]);

            //Получить значение по ключу с помощью TryGetValue
            //Сложность операции О(log n)
            sList.TryGetValue(8, out string value);
            Console.WriteLine(value);

            //Проверить содержит ли список указанный ключ
            //Сложность операции О(log n)
            Console.WriteLine(sList.ContainsKey(10));

            //Проверить содержит ли список указанное значение
            //Сложность операции О(n)
            Console.WriteLine(sList.ContainsValue("Johan"));

            //Получить индекс по ключу
            //Сложность операции О(log n)
            Console.WriteLine(sList.IndexOfKey(4));

            //Получить индекс по значению
            //Сложность операции О(n)
            Console.WriteLine(sList.IndexOfValue("Lex"));

            //Удалить элемент по ключу
            //Сложность операции О(n)
            sList.Remove(8);

            //Удалить элемент по значению
            //Сложность операции О(n)
            sList.RemoveAt(1);

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in sList)
                Console.WriteLine(item);
        }

//------B.1 Отсортированное множество (SortedSet<T>)
        public void ExampleSortedSet()
        {
            //Создаем новое отсортированное множество
            var sSet = new SortedSet<string>();

            //Добавить элемент в множество
            sSet.Add("One");
            sSet.Add("Two");
            sSet.Add("Three");
            sSet.Add("Two");
            sSet.Add("Seven");

            //Показать коллекцию
            foreach (var item in sSet)
                Console.WriteLine(item);

            //Проверить наличие элемента в множестве
            //Сложность операции О(log n)
            sSet.Contains("Two");

            //Удалить элемент из множества
            //Сложность операции О(log n)
            sSet.Remove("One");

            //Операция Union
            var sSet1 = new SortedSet<string>() { "One", "Five", "Six", "Two", "Seven" };
            sSet.UnionWith(sSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация Union");
            foreach (var item in sSet)
                Console.WriteLine(item);

            //Операция Intersect
            var sSet2 = new SortedSet<string>() { "Six", "Two", "Seven", "Ten" };
            sSet.IntersectWith(sSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Intersect");
            foreach (var item in sSet)
                Console.WriteLine(item);

            //Операция Expect
            sSet1.ExceptWith(sSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Expect");
            foreach (var item in sSet1)
                Console.WriteLine(item);

            //Операция SymmetricExpect
            sSet2.SymmetricExceptWith(sSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация SymmetricExpect");
            foreach (var item in sSet2)
                Console.WriteLine(item);
            Console.WriteLine();

            //Проверка isSubset
            Console.WriteLine(sSet1.IsSubsetOf(sSet));

            //Проверка isSuperset
            Console.WriteLine(sSet2.IsSupersetOf(sSet));

        }

//------B.2 Отсортированный словарь (SortedDictionary<TKey, TValue>)
        public void ExampleSDictionary()
        {
            //Создадим пустой словарь
            var sDictionary = new SortedDictionary<int, int>();

            //Добавить в словарь пару ключ-значение
            sDictionary.Add(5, 100);
            sDictionary.Add(3, 400);
            sDictionary.Add(7, 200);
            sDictionary.Add(6, 300);

            //Получить значение по ключу с помощью индексатора
            Console.WriteLine(sDictionary[7]);

            //Получить значение с помощью TryGetValue
            Console.WriteLine(sDictionary.TryGetValue(5, out int value));

            //Проверить, содержит ли словарь указанный ключ
            Console.WriteLine(sDictionary.ContainsKey(10));

            //Проверить, содержить ли словарь указанное значение
            Console.WriteLine(sDictionary.ContainsValue(300));

            //Удалить элемент по ключу
            sDictionary.Remove(7);

            //Показать коллекцию
            foreach (var item in sDictionary)
                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
        }

//------C.1 Множество на основе хеш-таблиц (HashSet<T>)
        public void ExampleHSet()
        {
            //Создаем пустое множество
            var hSet = new HashSet<string>();

            //Добавить элемент в множество
            hSet.Add("One");
            hSet.Add("Two");
            hSet.Add("Three");
            hSet.Add("Four");
            hSet.Add("Ten");

            //Проверить наличие элемента в множестве
            hSet.Contains("One");

            //Удалить элемент из множества
            hSet.Remove("Ten");

            //Операция Union
            var hSet1 = new HashSet<string>() { "One", "Five", "Six" };
            hSet1.UnionWith(hSet);

            //Показать коллекцию
            Console.WriteLine("\nОперация Union");
            foreach (var item in hSet1)
                Console.WriteLine(item);

            //Операция Intersect
            var hSet2 = new HashSet<string>() { "Seven", "Six", "Five", "Ten" };
            hSet2.IntersectWith(hSet1);

            //Показать коллекцию
            Console.WriteLine("\nОперация Intersect");
            foreach (var item in hSet2)
                Console.WriteLine(item);

            //Оперция Expect
            hSet.ExceptWith(hSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация Expect");
            foreach (var item in hSet2)
                Console.WriteLine(item);

            //Оперция SymetricExpect
            hSet.SymmetricExceptWith(hSet2);

            //Показать коллекцию
            Console.WriteLine("\nОперация SymetricExpect");
            foreach (var item in hSet2)
                Console.WriteLine(item);

            //Проверка isSubset
            Console.WriteLine(hSet1.IsSubsetOf(hSet));

            //Проверка isSuperset
            Console.WriteLine(hSet2.IsSupersetOf(hSet));
        }

//------C.1 Множество на основе хеш-таблиц (HashSet<T>)
        public void ExampleDictionary()
        {
            //Создадим пустой словарь
            var dictionary = new Dictionary<int, string>();

            //Добавить пару ключ-значение
            dictionary.Add(2, "Two");
            dictionary.Add(3, "Three");
            dictionary.Add(1, "One");
            dictionary.Add(5, "Five");

            //Получить значение по ключу с помощью индексатора
            Console.WriteLine(dictionary[2]);

            //Получить значение с помощью TryGetValue
            Console.WriteLine(dictionary.TryGetValue(5, out string value));

            //Проверить, содержит ли словарь указанный ключ
            Console.WriteLine(dictionary.ContainsKey(7));

            //Проверить, содержит ли словарь указанное зачение
            Console.WriteLine(dictionary.ContainsValue("Two"));

            //Удалить элемент по ключу
            dictionary.Remove(1);

            //Показать коллекцию
            Console.WriteLine();
            foreach (var item in dictionary)
                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Collections
    {
        //A.1 Массивы (Array)

            //Одномерный массив
            private readonly int[] _array1 = { 5, 6, 3, 9 };

            //Двухмерный массив
            private readonly int[,] _array2 = new int[2, 4];

            //Ступенчатый массив
            private readonly int[][] _array3 = new int[2][];

            //Поиск в одномерном массиве
            //Сложность метода О(n), где n - длинна массива
            private void SearchInArray(int num) =>
                Array.Find(_array1, n => n == num);

            //Сортировка одномерного массива
            private void SortArray() =>
                Array.Sort(_array1);

            //Бинарный поиск в массиве
            //Сложность метода О(log n), где n - длинна массива
            private int BinarySearchInArray(Array array, object value) =>
                Array.BinarySearch(array, value);

        //A.2 Список (List<T>)

            //Пустой список
            private readonly List<int> _list1 = new List<int>();

            //Список с указанной емкостью
            private readonly List<int> _list2 = new List<int>(5);

            //Добавить в список значение
            //Если Count < Capacity сложность = О(1), иначе О(n), где n - Count
            private void AddInList(int num) =>
                _list1.Add(num);

            //Добавить в список несколько значений
            //Если элементы можно вставить не увеличивая емкость списка, то сложность = O(n), где n - количество добавляемых элементов
            //иначе сложность O(n + m), где n - Count, a m - количество добавляемых элементов
            private void AddRangeInList(IEnumerable<int> nums) =>
                _list2.AddRange(nums);

            //Удаление элемента из списка
            //Сложность метода О(n), где n - Count
            private void RemoveFromList(int num) =>
                _list1.Remove(num);

            //Удаление диапазона значений из спика
            //Сложность метода O(n), где n - Count
            private void RemoveRangeFromList(int index, int count) =>
                _list1.RemoveRange(index, count);

            //Удаление элементов, удовлетворяющих условию
            //Сложность метода O(n), где n - Count
            private void RemoveAllFromList()
            {
                foreach(var item in _list1)
                {
                    Console.WriteLine(item);
                }
                _list1.RemoveAll(item => item > 3);
                Console.WriteLine("Наличие чисел больше 3 в списке List1: {0}", 
                    _list1.Exists(item => item > 3));
            }

            //Усечение избыточной емкости стписка
            //Сложность метода O(n), где n - Count
            private void TrimExcessList() =>
                _list1.TrimExcess();

        //A.3 Двойной связанный список (LinkedList<T>)

            private readonly LinkedList<string> _srings = new LinkedList<string>();

            //Добавить элемент в начало списка
            //Сложность метода O(1)
            private void AddFirstInLList() =>
                _srings.AddFirst("One");

            //Добавить элемент в конец списка
            //Сложность метода O(1)
            private void AddLastInLList() =>
                _srings.AddLast("Two");

            //Добавить элемент в произвольное место списка
            //Сложность метода O(1)
            private void AddInLList(LinkedListNode<string> node) =>
                _srings.AddAfter(node, "Three");

            //Получить узел списка
            //Сложность метода O(n), где n - Count
            private void TryGetNodeList(string value) =>
                _srings.Find(value);

            //Получить следующий узел списка
            private LinkedListNode<string> TryGetNextNodeList(string value) =>
                _srings.Find(value).Next;

            //Получить предыдущий узел списка
            private LinkedListNode<string> TryGetPrevNodeList(string value) =>
                _srings.Find(value).Previous;

        //A.4 Стэк (Stack<T>)

            private readonly Stack<int> _stack = new Stack<int>();

            //Добавить элемент на вершину стека
            //Если размер стека больше Count стека, то сложность O(1), иначе О(n), где n - Count
            private void AddInStack() =>
                _stack.Push(4);

            //Получить элемент с вершины стека
            //Сложность метода О(1)
            private void PeekFromStack() =>
                _stack.Peek();

            //Поднять элемент с вершины стека
            //Сложность метода О(1)
            private void PopFromStack() =>
                _stack.Pop();

        //A.5 Очередь (Queue<T>)

            private readonly Queue<int> _queue = new Queue<int>();

            //Добавить элемент в конец очереди
            //Если размер очереди больше Count очереди, то сложность O(1), иначе О(n), где n - Count
            private void AddInQueue() =>
                _queue.Enqueue(3);

            //Получить элемент из конца очереди
            //Сложность метода О(1)
            private void PeekFromQueue() =>
                _queue.Peek();

            //Поднять элемент из конца очереди
            //Сложность метода О(1)
            private void DequeueFromQueue() =>
                _queue.Dequeue();

        //A.6 Отсортированный ассоциативный список (SortedList<TKey, TValue>)

            private readonly SortedList<int, string> _slist = new SortedList<int, string>();

            //Добавить в список пару ключ-значение
            private void AddInSList() =>
                _slist.Add(13, "Tom");

        //Получить значение по ключу с помощью индексатора
        private void GetValueViaIndexFromSList(int num) =>
            _slist.IndexOfKey(num);

    }
}

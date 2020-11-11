using System.Collections;

namespace Visual_Program
{
    // Объявление универсального шаблона список, тип данных обозначен как Т
    // Объявление универсального шаблона список, тип данных обозначен как Т
    public class GenericsFIFO<T>
    {
        // Скрытый класс Node (элемент) также работает с типом данных Т
        private class Node
        {
            public Node(T t)
            {
                data = t;
            }
            public T data { get; set; }
            public Node Next { get; set; }
        }
        private Node first; // головной/первый элемент
        private Node last; // последний/хвостовой элемент
        private int count;
        // добавление в очередь
        public void Push(T data)
        {
            Node node = new Node(data);
            Node tempNode = last;
            last = node;
            if (count == 0)
                first = last;
            else
                tempNode.Next = last;
            count++;
        }
        //Извлечение произвольного элемента без его изъятия
        public T Get(int i)
        {
            Node TempFirst = first;
            Node First = first;
            for (int n = 0; n < i - 1; n++)
            {
                First = TempFirst.Next;
                TempFirst = First;
            }
            T output = First.data;
            return output;
        }
        // удаление из очереди
        public T Pop()
        {
            T output = first.data;
            first = first.Next;
            count--;
            return output;
        }
        //Количество элементов
        public int Count
        {
            get { return count; }
        }
        public IEnumerator GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.data;
                current = current.Next;
            }
        }
    }
}

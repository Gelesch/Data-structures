using System;
using System.Security.Cryptography;

namespace ListNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            // Добавляем элементы в конец.
            list.AddLast(new Person("Вася", 18));
            list.AddLast(new Person("Петя", 20));

            // Выводим все элементы на консоль.
            list.PrintAll();
            //Name: Вася Age: 18
            //Name: Петя Age: 20

            //Добавляем элементы в начало.
            list.AddFirst(new Person("Антон", 25));
            list.AddFirst(new Person("Рома", 10));
            // Выводим все элементы на консоль.
            list.PrintAll();
            // Name: Рома Age: 10
            // Name: Антон Age: 25
            // Name: Вася Age: 18
            // Name: Петя Age: 20


            // Удаляем элемент.
            list.Remove(new Person("Вася", 18));
            list.PrintAll();
            // Name: Рома Age: 10
            // Name: Антон Age: 25
            // Name: Петя Age: 20
        }
    }

    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    /// <summary>
    /// Класс, описывающий элемент связного списка.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Хранимые данные.
        /// </summary>
        public Person Value;

        /// <summary>
        /// Следующий элемент связного списка.
        /// </summary>
        public Node Next;

        /// <summary>
        /// Создание нового экземпляра связного списка.
        /// </summary>
        /// <param name="value"> Сохраняемые данные. </param>
        public Node(Person value)
        {
            Value = value;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Хранимые данные. </returns>
        public void Print()
        {
            Console.WriteLine("Name: " + Value.Name + " Age: " + Value.Age);
        }
    }

    public class LinkedList
    {
        /// <summary>
        /// Первый (головной) элемент списка.
        /// </summary>
        public Node Head = null;

        /// <summary>
        /// Крайний (хвостовой) элемент списка. 
        /// </summary>
        public Node Tail = null;

        /// <summary>
        /// Добавить данные в  связный список.
        /// </summary>
        /// <param name="data"></param>
        public void AddLast(Person data)
        {
            if (Head == null)
            {
                Head = new Node(data);
                Tail = Head;
            }
            else
            {
                Tail.Next = new Node(data);
                Tail = Tail.Next;
            }
        }


        /// <summary>
        /// Добавляет ноду в самое начало
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(Person data)
        {
            if (Head == null && Tail == null)
            {
                Head = new Node(data);
                Tail = Head;
            }
            else
            {
                var newNode = Head;
                Head = new Node(data);
                Head.Next = newNode;
            }
        }


        /// <summary>
        /// Удалить данные из связного списка.
        /// Выполняется удаление первого совпадения данных.
        /// </summary>
        /// <param name="data"> Данные, которые будут удалены. </param>
        public void Remove(Person data)
        {
            Node previousNode = null;
            var currentNode = Head;


            while (currentNode != null)
            {
                if (currentNode.Value.Name == data.Name && currentNode.Value.Age == currentNode.Value.Age)
                {    //удалеяем одну единственную ноду
                    if (currentNode ==  Tail)
                    {
                        Tail = previousNode;
                    }
                    // 
                    if (currentNode == Head)
                    {
                        Head = currentNode.Next;
                        break;
                    }

                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                    }
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Вывод всех объектов в консоль
        /// </summary>
        /// <returns></returns>
        public void PrintAll()
        {
            var node = Head;
            while (node != null)
            {
                Console.WriteLine("Name: " + node.Value.Name + " Age:" + node.Value.Age);
                node = node.Next;
            }
        }
    }
}
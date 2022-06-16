using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();
            queue.Enqueue(new Person("Kate", 15));
            queue.Enqueue(new Person("Sam", 15));
            queue.Enqueue(new Person("Alice", 17));
            queue.Enqueue(new Person("Tom", 11));

            Console.WriteLine();
            var firstItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            firstItem.Print(); // Извлеченный элемент: Name: Kate Age: 15
            var secondItem = queue.Dequeue();
            Console.Write($"Извлеченный элемент: ");
            secondItem.Print(); // Извлеченный элемент: Name: Sam Age: 15
            queue = new Queue();
            var Item = queue.Peak(); //null
        }
    }

    /// <summary>
    /// Класс Person
    /// Содержит 2 публичных поля Name и Age
    /// Также должен быть конструктор который принимает Name, Age
    /// </summary>
    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + Name + " Age: " + Age);
        }
    }


    public class Queue
    {
        private const int DEFAULT_COUNT_ELEMENTS = 4;

        private int _headIndex;
        private int _nextIndex;
        private int _count;

        private Person[] _elements;

        public Queue()
        {
            _elements = new Person[DEFAULT_COUNT_ELEMENTS];
        }

        // добавление в очередь
        public void Enqueue(Person data)
        {
            if (_nextIndex - _headIndex >= _elements.Length)

            {
                //создаем новый массив размером x2
                var newArray = new Person[_elements.Length * 2];
                for (int i = 0; i < _elements.Length; i++)
                {
                    newArray[i] = _elements[(_headIndex + i) % _elements.Length];
                }

                _headIndex = 0;
                _nextIndex = _elements.Length;
                _elements = newArray;
            }

            //определяем место куда будет добавлен элемен
            var currentIndex = _nextIndex % _elements.Length;
            _elements[currentIndex] = data;
            //смешаем индекс,куда будет добавлен следуюший элемент
            ++_nextIndex;
        }

        // удаление из очереди
        public Person Dequeue()
        {
            if (_headIndex == _nextIndex)
            {
                throw new IndexOutOfRangeException();
            }

            //берем по модулю элемент который удаляем
            var result = _elements[_headIndex % _elements.Length];

            //перемещаемся на следующий индекс элемента
            ++_headIndex;

            return result;
        }

        // возвращает первый элемент
        public Person Peak()
        {
            if (_headIndex == _nextIndex)
            {
                throw new IndexOutOfRangeException();
            }

            return _elements[_headIndex % _elements.Length];
        }
    }
}
using System;

class MyProgram
{
    static void Main(string[] args)
    {
        CircularArray<int> numbers = new CircularArray<int>(3);
        numbers.Add(5);
        numbers.Add(7);
        numbers.Add(8);
        numbers.Add(91);
        numbers.Add(23);

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers.Get(i));
        }
    }
}

class CircularArray<T>
{
    public int Count => _nextIndex > _elements.Length ? _elements.Length : _nextIndex;
    private T[] _elements;
    private int _nextIndex;

    public CircularArray(int count)
    {
        _elements = new T[count];
    }

    //добавление элемента
    public void Add(T value)
    {
        //получаем модуль текущего индекса
        var currentIndex = _nextIndex % _elements.Length;
        //куда должны записать элемент
        _elements[currentIndex] = value;

        ++_nextIndex;
    }

    public T Get(int index)
    {
        //проверяем  колл.элементов с длиной массива
        // если индекc меньше колличества элментво 
        if (_nextIndex < _elements.Length)
        {
            //то выводим запрашиваемый индекс
            return _elements[index];
        }
        //в остальных случаях выводим индекс(  index(запрашиваемый индекс)+_nextIndex(колл.элементов) %_elements.Length(длина массива))

        return _elements[(_nextIndex + index) % _elements.Length];
    }
}
using System;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        DynamicArray<int> number = new DynamicArray<int>();
        number.Add(15);
        number.Add(17);
        number.Add(19);
        number.Add(21);
        number.Add(23);
        number.Add(25);
        number.Add(27);
        number.Add(29);

        for (int i = 0; i < number.Count; i++)
        {
            Console.WriteLine(number.Get(i));
        }
    }
}

public class DynamicArray<T>
{
    //константа размернсти массива
    private const int DEFAULT_COUNT_ELEMENTS = 4;

    //поле инициализаии массива
    private T[] _elements;

    //поле создания индекса
    private int _nextIndex;


    //свойства которое возвращает колличества элементов
    public int Count => _nextIndex;

    //конструктор создания массива
    public DynamicArray()
    {
        _elements = new T[DEFAULT_COUNT_ELEMENTS];
    }

    
    //метод добавления элемента
    public void Add(T value)
    {
        //если индекс совпадает с длиной массива то
        if (_nextIndex == _elements.Length)
        {
            //увеличиваем размер массива
            Array.Resize(ref _elements, _elements.Length * 2);
        }
         //добавляем элемент в массив
        _elements[_nextIndex] = value;
        
        //увеличиваем счетчик индекса
        _nextIndex++;
    }

    //метод возвращает элементы по индексу
    public T Get(int index)
    {
        return _elements[index];
    }
}
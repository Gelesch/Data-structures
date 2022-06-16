using System;
using System.Collections.Generic;

class MyClass
{
    static void Main(string[] args)
    {
        Heap heap = new Heap();
        heap.Add(7);
        heap.Add(1);
        heap.Add(5);
        heap.Add(19);
        heap.Add(3);
        heap.Add(25);
        heap.Add(2);
        heap.Add(17);

        for (int i = 0; i < heap.count; i++)
        {
            Console.WriteLine(heap.Get(i));
        }

        Console.WriteLine("----------");
        Console.WriteLine("Max 1:"+ heap.ExtractMaximum());
        Console.WriteLine("Max 2:" +heap.ExtractMaximum());
        Console.WriteLine("Max 3:" +heap.ExtractMaximum());
        Console.WriteLine("Max 4:" +heap.ExtractMaximum());
        Console.WriteLine("Max 5:" +heap.ExtractMaximum());
       
    }
}

class Heap
{
    public int count => _heapData.Count;
    private List<int> _heapData = new List<int>();

    //временно Get
    public int Get(int index)
    {
        return _heapData[index];
    }

    public void Add(int value)
    {
        //добавляем эелемен 
        _heapData.Add(value);
        // конец динамического массива List
        Shiftup(_heapData.Count - 1);
    }
    
//просеивание элемента вниз
    private void ShiftDown(int index)
    {
        //Сравниваем левый и правый 
        //Меняем местами с нашим текущим (если этот максимальный больше текущего)

        var leftChildIndex = index * 2 + 1;
        var rightChildIndex = index * 2 + 2;
        
        //если  левого потомка в массиве нету 
        if (leftChildIndex >= _heapData.Count)
        {
            //то просто заканчиваем просеивание
            return;
        }

        var maxChildIndex = leftChildIndex;
        //правый потом есть и он оказался больче чем левый
        if (rightChildIndex < _heapData.Count && _heapData[leftChildIndex] < _heapData[rightChildIndex])
        {
            //тогда пометим индекс максимального потомка-индекс правого потомка
            maxChildIndex = rightChildIndex;
        }

        //если наш элемент оказался Уже больче чем максимальный потомок
        if (_heapData[index] > _heapData[maxChildIndex])
        {
            //то на этом просеивание заканчиваем
            return;
        }
        Swap(_heapData,index,maxChildIndex);
        
        
        //наш текущий элемент(index) оказался на месте (maxChildIndex) 
        //нужно еще раз проверить что он находится в правильной позиции 
        //делаем просеиванеи сверху вниз
        ShiftDown(maxChildIndex);
    }
    
    
//просеиванеи элемента снизу вверх
    private void Shiftup(int index)
    {
        int parentIndex = (index - 1) / 2;

        int currentElement = _heapData[index];
        int parentElement = _heapData[parentIndex];

        if (currentElement > parentElement)
        {
            Swap(_heapData, index, parentIndex);
            Shiftup(parentIndex);
        }
    }

    private void Swap(List<int> array, int leftIndex, int rightIndex)
    {
        (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
    }
//поиска максимального числа в дереве
    public int ExtractMaximum()
    {
        
        //записываем максимальный эелемент в переменную
        var result = _heapData[0];
        
        //перемещаем последний елемент в первый
        _heapData[0] = _heapData[^1];
        
        //начинаем сверху вниз просеивать 
       ShiftDown(0); //передаем 0-вой элемент
        return result ;
    }
}
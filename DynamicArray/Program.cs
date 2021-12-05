using System;
// Создать класс DynamicArray который содержит:
    // 1.приватное поле array
    // 2.Два конструктора которые инициализируют массив
    // 2.1 Первый конструктор по умолчанию и инициализирует массив [0]
    // 2.2 Второй конструктор принимает любое количество цифр и после добавляет их в массив.
    // 3.Публичный метод GetCount, Возвращает количество элементов, которые уже были добавлены в массив.
    // После вызова метода Clear становится 0.
    // 4.Публичный метод GetCapacity
    // Это вместимость вашей буферной зоны.
    // Возвращает количество элементов, которые потенциально могут быть добавлены 
    // в массив без выделения памяти. После вызова метода Clear эта вместимость не должна меняться.
    // Пояснение:
    // Вы можете заранее создать массив, в котором будет храниться немного больше элементов, 
    // для того чтобы при каждом добавлении элемента не создавать новый массив и не копировать 
    // значения всех элементов. 
    // Пример: 
    // У вас Capacity может быть 8, но количество элементов 5.
    // Что будет означать, что вы сможете добавить еще 3 элемента в ваш массив
    // без дополнительных аллокаций памяти.
    // И например когда вы будете добавлять 9-ый элемент, вы можете создать новый буфер, 
    // который будет хранить уже 16 элементов. Т.е. Capacity будет 16, а Cout будет 9.
    // 5. Публичный метод GetArray, Возвращает массив состоящий строго из значений, которые были в него добавлены (т.е. без пустых лишних элементов).
    // Можно возвращать тут копию массива, который содержит ТОЛЬКО элементы, которые реально используются.
    // 6. Приватный метод Resize, увеличивает размер массива и копирует старые элементы в новый массив.
    // 7. Публичный метод Add, увеличивает размер массива и копирует старые элементы в новый массив.
    // 8. Публичный метод Clear, удаляет все элементы массива. Если после этого вызвать Print ничего не будет распечатано.
    // 9. Публичный метод Print, выводит на консоль только заполненные элементы массива.

namespace DynamicArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var infinityArray1 = new DynamicArray(5, 6, 3, 2, 1, 4);
            var infinityArray2 = new DynamicArray(5, 6);
            var infinityArray3 = new DynamicArray();
            for (int i = 0; i < 15; i++)
            {
                infinityArray1.Add(random.Next(0, 100));
                infinityArray2.Add(random.Next(0, 100));
                infinityArray3.Add(random.Next(0, 100));
            }

            infinityArray1.Print();
            infinityArray2.Print();
            infinityArray3.Print();
            infinityArray1.Clear();
            infinityArray2.Clear();
            infinityArray3.Clear();


            for (int i = 0; i < 20; i++)
            {
                infinityArray1.Add(random.Next(0, 100));
                infinityArray2.Add(random.Next(0, 100));
                infinityArray3.Add(random.Next(0, 100));
            }

            infinityArray1.Print();
            infinityArray2.Print();
            infinityArray3.Print();
        }
    }

    public class DynamicArray
    {
        private int[] _array;
        private int _countOfElements;

        public DynamicArray()
        {
            _array = new int[0];
        }

        public DynamicArray(params int[] elemets) : this()
        {
            _array = elemets;
            _countOfElements = elemets.Length;

        }

        public int GetCount()
        {
            return _countOfElements;
        }

        public int GetCapacity()
        {
            return _array.Length;
        }

        public int[] GetArray()
        {
            int[] resultArray = new int[GetCount()];
            Array.Copy(_array, resultArray, GetCount());
            return resultArray;

        }

        private void Resize()
        {
            int[] tempArray = new int[GetCapacity() * 2 + 2];
            for (var i = 0; i < _array.Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        public void Add(int newElemet)
        {
            if (GetCapacity() < GetCount() + 1)
            {
                Resize();
            }
            _array[_countOfElements] = newElemet; 
            _countOfElements += 1;
            
        }

        public void Clear()
        {
            _countOfElements = 0;
        }

        public void Print()
        {
            for (var i = 0; i < GetCount(); i++)
            {
                Console.Write(GetArray()[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
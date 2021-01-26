using System;

namespace findandsort
{
    class Program
    {
        //BubbleSort-пузырьковая сортировка
        //выведет числа из массива по возрастанию
        private static readonly Random random = new Random();
        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }
        public static void Main()
        {
            int[] array = GenerateArray(10);
            BubbleSort(array);
            foreach (int e in array)
                Console.WriteLine(e);


            BubbleSortRange(new[] { 4, 3, 2, 1 }, 1, 2); //вернeт массив new[] {4, 2, 3, 1}
        }
        private static int[] GenerateArray(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next();
            return array;
        }

        //сортировал только указанный диапазон, а элементы за этим диапазоном оставлял на своих местах.
        //BubbleSortRange(new[] {4, 3, 2, 1}, 1, 2); //вернeт массив new[] {4, 2, 3, 1}
        public static void BubbleSortRange(int[] array, int left, int right)
        {
            for (int i = left; i < right; i++)
                for (int j = left; j < right; j++)
                    if (array[j] > array[j + 1])
                    {
                        array[j + 1] = array[j] + array[j + 1];
                        array[j] = array[j + 1] - array[j];
                        array[j + 1] = array[j + 1] - array[j];
                    }
        }

        //сортировка слиянием (в правильном порядке)
        static int[] temporaryArray;
        static void Merge(int[] array, int start, int middle, int end)
        {
            var leftPtr = start;
            var rightPtr = middle + 1;
            var length = end - start + 1;
            for (int i = 0; i < length; i++)
            {
                if (rightPtr > end || (leftPtr <= middle && array[leftPtr] < array[rightPtr]))
                {
                    temporaryArray[i] = array[leftPtr];
                    leftPtr++;
                }
                else
                {
                    temporaryArray[i] = array[rightPtr];
                    rightPtr++;
                }
            }
            for (int i = 0; i < length; i++)
                array[i + start] = temporaryArray[i];
        }
        static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return;
            var middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);
            Merge(array, start, middle, end);

        }
        static void MergeSort(int[] array)
        {
            temporaryArray = new int[array.Length];
            MergeSort(array, 0, array.Length - 1);
        }
        static Random random2 = new Random();
        static int[] GenerateArray2(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random2.Next();
            return array;
        }
        public static void Main2()
        {
            var array = GenerateArray2(10);
            MergeSort(array);
            foreach (var e in array)
                Console.WriteLine(e);
        }

        //быстрая сортировка
        static void HoareSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) HoareSort(array, start, storeIndex - 1);
            if (storeIndex < end) HoareSort(array, storeIndex + 1, end);
        }

        static void HoareSort(int[] array)
        {
            HoareSort(array, 0, array.Length - 1);
        }

        static Random random3 = new Random();

        static int[] GenerateArray3(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random3.Next();
            return array;
        }

        public static void Main3()
        {
            var array = GenerateArray3(10);
            HoareSort(array);
            foreach (var e in array)
                Console.WriteLine(e);
        }
    }
}

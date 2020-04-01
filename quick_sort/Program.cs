using System;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int length_arr = ReadConsole_int_W("Введите кол-во элементов массива: ");
            Random rand = new Random();
            int[] arr = new int[length_arr];
            for (int i = 0; i < length_arr; i++)
            {
                arr[i] = rand.Next(-50, 50);
            }

            ArrayPrint("Изначальный массив", arr);

            arr = QuickSort(arr);
            ArrayPrint("Отсортированный массив", arr);
            Console.ReadLine();
        }

        static int[] QuickSort(int[] arr)
        {
            return QuickSort(arr, 0, arr.Length - 1);
        }

        static int[] QuickSort(int[] arr, int start_index, int end_index)
        {
            if (start_index < end_index)
            {
                int temp = Partition(arr, start_index, end_index);
                arr = QuickSort(arr, start_index, temp);
                arr = QuickSort(arr, temp + 1, end_index);
            }
            return arr;
        }

        static int Partition(int[] arr, int start_index, int end_index)
        {
            int pivot = arr[start_index];
            int left_index = start_index - 1;
            int right_index = end_index + 1;
            while (true)
            {
                do
                {
                    right_index--;
                }
                while (arr[right_index] > pivot);
                do
                {
                    left_index++;
                }
                while (arr[left_index] < pivot);
                if (left_index < right_index)
                {
                    Swap(ref arr[left_index], ref arr[right_index]);
                }
                else
                {
                    return right_index;
                }
            }
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        static void ArrayPrint(string text, int[] arr)
        {
            Console.WriteLine($"{text}");
            for (int i = 0; i < arr.Length; i++)
            {
                IntPrintBeautiful(arr[i]);
            }
            Console.WriteLine();
        }

        static void IntPrintBeautiful(int num, byte count_symbol = 5)
        {
            string text = num < 0 ? $"{num}" : $" {num}";
            for (int i = count_symbol; i > text.Length;)
            {
                text = text.Insert(text.Length, " ");
            }
            Console.Write(text);
        }

        static int ReadConsole_int_W(string text_W)
        {
            while (true)
            {
                Console.Write(text_W);
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Неправильный ввод! Нужно целое число");
                    Console.ReadLine();
                    continue;
                }
                return num;
            }
        }
    }
}

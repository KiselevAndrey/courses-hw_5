using System;
using System.Collections.Generic;

namespace quick_sort_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();
            ParsingText(text, out List<string> leters, out List<string> symbols);

            leters = QuickSort(leters);

            Console.WriteLine("Отсортированная строка с сохранением знаков препинания");
            bool flag = char.IsLetter(text[0]);
            int count = leters.Count > symbols.Count ? leters.Count : symbols.Count;
            for (int i = 0; i < count; i++)
            {
                if (flag)
                {
                    Console.Write((i < leters.Count) ? leters[i] : "");
                    Console.Write((i < symbols.Count) ? symbols[i] : "");
                }
                else
                {
                    Console.Write((i < symbols.Count) ? symbols[i] : "");
                    Console.Write((i < leters.Count) ? leters[i] : "");
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        static void ParsingText(string text, out List<string> leters, out List<string> symbols)
        {
            leters = new List<string>();
            symbols = new List<string>();

            int count_leters = 0;
            int count_symbols = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (count_symbols != 0)
                    {
                        symbols.Add(text.Substring(i - count_symbols, count_symbols));
                        count_symbols = 0;
                    }
                    count_leters++;
                }
                else
                {
                    if (count_leters != 0)
                    {
                        leters.Add(text.Substring(i - count_leters, count_leters));
                        count_leters = 0;
                    }
                    count_symbols++;
                }
            }
        }

        static List<string> QuickSort(List<string> list)
        {
            return QuickSort(list, 0, list.Count - 1);
        }

        static List<string> QuickSort(List<string> list, int start_index, int end_index)
        {
            if (start_index < end_index)
            {
                int temp = Partition(list, start_index, end_index);
                list = QuickSort(list, start_index, temp);
                list = QuickSort(list, temp + 1, end_index);
            }
            return list;
        }

        static int Partition(List<string> list, int start_index, int end_index)
        {
            string pivot = list[start_index];
            int left_index = start_index - 1;
            int right_index = end_index + 1;
            while (true)
            {
                do
                {
                    right_index--;
                }
                while (list[right_index].Length > pivot.Length);
                do
                {
                    left_index++;
                }
                while (list[left_index].Length < pivot.Length);
                if (left_index < right_index)
                {
                    string temp = list[left_index];
                    list[left_index] = list[right_index];
                    list[right_index] = temp;
                }
                else
                {
                    return right_index;
                }
            }
        }
    }
}

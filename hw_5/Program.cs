using System;

namespace hw_5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                #region Start menu
                Console.WriteLine("\n\tДомашнее задание 5\n" +
                    "\n1. Последний отрицательный элемент" +
                    "\n2. 0 после MAX" +
                    "\n3. 0 после MAX (массив массивов)" +
                    "\n4. Посчитать кол-во гласных " +
                    "\n5. Заменить символ на заглавный" +
                    "\n\n0. Выход");

                byte key = ReadConsole_byte_W("\nВведите номер упражнения: ");
                
                // Проверка на выход
                if (key == 0)
                {
                    break;
                }

                Console.Clear();
                #endregion

                switch (key)
                {                    
                    case 1:
                        LastNegativElement();       // Последний отрицательный элемент в одномерном массиве
                        break;

                    case 2:
                        ZeroFromMax();              // 0 после MAX
                        break;

                    case 3:
                        ZeroFromMaxStepMatrix();    // 0 после MAX (массив массивов)
                        break;

                    case 4:
                        CountVowels();              // Посчитать кол-во гласных
                        break;
                    
                    case 5:
                        ToUpSymbol();               // Заменить символ на заглавный
                        break;

                    // Неправильный вариан
                    default:
                        Console.WriteLine("Проверьте правильность выбора! Нет упражнения " + key);
                        break;
                }

                Console.WriteLine("\n\nНажмите Enter.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void LastNegativElement()
        {
            int[] arr = new int[8];
            Random rand = new Random();
            int res_index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-10, 10);
                IntPrintBeautiful(arr[i]);
                if (arr[i] < 0)
                {
                    res_index = i;
                }
            }
            Console.WriteLine();
            if (res_index == -1)
            {
                Console.WriteLine("Отрицательных элементов нет");
            }
            else
            {
                Console.WriteLine($"Последний отрицательный элемент {arr[res_index]} под индексом {res_index}");
            }
        }

        static void ZeroFromMax()
        {
            int rows = ReadConsole_int_W("Введите кол-во строк: ");
            int columns = ReadConsole_int_W("Введите кол-во столбцов: ");
            int[,] matrix = new int[rows, columns];
            Random rand_2 = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand_2.Next(-10, 10);
                }
            }

            MatrixPrint("Изначальная матрица", matrix);

            int index_max;
            for (int i = 0; i < rows; i++)
            {
                index_max = 0;
                for (int j = 1; j < columns; j++)
                {
                    if (matrix[i, j] >= matrix[i, index_max])
                    {
                        index_max = j;
                    }
                }
                for (int j = index_max + 1; j < columns; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            MatrixPrint("Полученная матрица", matrix);
        }

        static void ZeroFromMaxStepMatrix()
        {
            int rows = ReadConsole_int_W("Введите кол-во строк (Потом для КАЖДОЙ строки потребуется ввод столбцов): ");
            int[][] matrix = new int[rows][];
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[ReadConsole_int_W($"Введите кол-во столбцов для строки {i}: ")];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = rand.Next(-10, 10);
                }
            }

            MatrixPrint("Изначальная матрица", matrix);

            int index_max;
            for (int i = 0; i < rows; i++)
            {
                index_max = 0;
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] >= matrix[i][index_max])
                    {
                        index_max = j;
                    }
                }
                for (int j = index_max + 1; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = 0;
                }
            }

            MatrixPrint("Полученная матрица", matrix);
        }

        static void CountVowels()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine().ToLower();
            string vowels = "уеыаоэяиюёeyuioa";
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (vowels.Contains(text[i]))
                {
                    count++;
                }
            }
            Console.WriteLine($"В строке встречается гласных: {count}");
        }

        static void ToUpSymbol()
        {
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();
            Console.Write("\nВведите символ для замены: ");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (char.IsUpper(key))
            {
                Console.WriteLine("Символ уже заглавный!!");
                return;
            }
            char new_key = char.ToUpper(key);
            text = text.Replace(key, new_key);
            Console.WriteLine($"\nНовая строка:\n{text}");
        }

        static void MatrixPrint(string text, int[,] matrix, byte count_symbol = 5)
        {
            Console.WriteLine($"\n{text}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    IntPrintBeautiful(matrix[i, j], count_symbol);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        static void MatrixPrint(string text, int[][] matrix, byte count_symbol = 5)
        {
            Console.WriteLine($"\n{text}");
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    IntPrintBeautiful(matrix[i][j], count_symbol);
                }
                Console.WriteLine();
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

        static byte ReadConsole_byte_W(string text_W)
        {
            while (true)
            {
                Console.Write(text_W);
                if (!byte.TryParse(Console.ReadLine(), out byte num))
                {
                    Console.WriteLine("Неправильный ввод");
                    Console.ReadLine();
                    continue;
                }
                return num;
            }
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

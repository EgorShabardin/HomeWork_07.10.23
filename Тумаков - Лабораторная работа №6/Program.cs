using System;
using System.IO;
using System.Collections.Generic;

namespace Тумаков___Лабораторная_работа__6
{
    class Program
    {
        /// <summary>
        /// Метод, подсчитывающий количество гласных и согласных букв русского алфавита в передаваемом массиве.
        /// </summary>
        /// <param name="lettersArray"> Массив символов. </param>
        /// <returns> Возвращает кортеж, первый элемент которого - число гласных букв, второй - число согласных. </returns>
        static (int, int) CountsLettersFromArray(char[] lettersArray)
        {
            (int, int) lettersNumber = (0, 0);
            char[] vowelsArray = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };

            foreach (char letter in lettersArray)
            {
                if ((int)letter >= 1040 && (int)letter <= 1103)
                {
                    if (Array.IndexOf(vowelsArray, letter) != -1)
                    {
                        lettersNumber.Item1++;
                    }
                    else
                    {
                        lettersNumber.Item2++;
                    }
                }
            }

            return lettersNumber;
        }

        /// <summary>
        /// Метод, подсчитывающий количество гласных и согласных букв русского алфавита в передаваемой коллекции.
        /// </summary>
        /// <param name="lettersList"> Коллекция символов. </param>
        /// <returns> Возвращает кортеж, первый элемент которого - число гласных букв, второй - число согласных. </returns>
        static (int, int) CountsLettersFromList(List<char> lettersList)
        {
            (int, int) lettersNumber = (0, 0);
            List<char> vowelsList = new List<char>() { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };

            foreach (char letter in lettersList)
            {
                if ((int)letter >= 1040 && (int)letter <= 1103)
                {
                    if (vowelsList.Contains(letter))
                    {
                        lettersNumber.Item1++;
                    }
                    else
                    {
                        lettersNumber.Item2++;
                    }
                }
            }

            return lettersNumber;
        }

        /// <summary>
        /// Метод, умножающий две матрицы второго порядка.
        /// </summary>
        /// <param name="firstMatrixArray"> Двумерный массив, содержащий первую матрицу второго порядка. </param>
        /// <param name="secondMatrixArray"> Двумерный массив, содержащий вторую матрицу второго порядка. </param>
        /// <returns> Двумерный массив, содержащий матрицу второго порядка, которая является результатом умножения двух матриц. </returns>
        static int[,] MultiplyingTwoMatrices(int[,] firstMatrixArray, int[,] secondMatrixArray)
        {
            int[,] resultMatrixArray = new int[2, 2];

            for (int i = 0; i < firstMatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrixArray.GetLength(0); j++)
                {
                    resultMatrixArray[i, j] = firstMatrixArray[i, 0] * secondMatrixArray[0, j] + firstMatrixArray[i, 1] * secondMatrixArray[1, j];
                }
            }

            return resultMatrixArray;
        }

        /// <summary>
        /// Метод, умножающий две матрицы второго порядка.
        /// </summary>
        /// <param name="firstMatrixList"> Связанный список, содержащий первую матрицу второго порядка. </param>
        /// <param name="secondMatrixList"> Связанный список, содержащий вторую матрицу второго порядка. </param>
        /// <returns> Связанный список, содержащий матрицу второго порядка, которая является результатом умножения двух матриц. </returns>
        static LinkedList<int> MultiplyingTwoMatrices(LinkedList<int> firstMatrixList, LinkedList<int> secondMatrixList)
        {
            LinkedList<int> resultMatrixList = new LinkedList<int>();

            resultMatrixList.AddLast(firstMatrixList.First.Value * secondMatrixList.First.Value + firstMatrixList.First.Next.Value * secondMatrixList.Last.Previous.Value);
            resultMatrixList.AddLast(firstMatrixList.First.Value * secondMatrixList.First.Next.Value + firstMatrixList.First.Next.Value * secondMatrixList.Last.Value);
            resultMatrixList.AddLast(firstMatrixList.Last.Previous.Value * secondMatrixList.First.Value + firstMatrixList.Last.Value * secondMatrixList.Last.Previous.Value);
            resultMatrixList.AddLast(firstMatrixList.Last.Previous.Value * secondMatrixList.First.Next.Value + firstMatrixList.Last.Value * secondMatrixList.Last.Value);

            return resultMatrixList;
        }

        /// <summary>
        /// Метод, который выводит на экран матрицу второго порядка.
        /// </summary>
        /// <param name="matrix"> Двумерный массив, содержащий матрицу второго порядка. </param>
        static void DisplayingMatrices(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0, 4}", matrix[i, j]));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, который выводит на экран матрицу второго порядка.
        /// </summary>
        /// <param name="matrix"> Связанный список, содержащий матрицу второго порядка. </param>
        static void DisplayingMatrices(LinkedList<int> matrix)
        {
            int count = 0;

            foreach (int number in matrix)
            {
                Console.Write(String.Format("{0, 4}", number));
                count++;

                if (count % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Метод, вычисляющий среднее значение температуры в каждом месяце.
        /// </summary>
        /// <param name="temperature"> Двумерный массив, содержащий значения температуры в каждый день каждого месяца. </param>
        /// <returns> Массив, содержащий среднее значение температуры в каждом месяце. </returns>
        static double[] CalculatesMounthAverageTemp(int[,] temperature)
        {
            double[] mounthAverageTempArray = new double[temperature.GetLength(0)];

            for (int i = 0; i < temperature.GetLength(0); i ++)
            {
                int tempSumm = 0;

                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    tempSumm += temperature[i, j];
                }

                mounthAverageTempArray[i] = (double)tempSumm / temperature.GetLength(1);
            }

            return mounthAverageTempArray;
        }

        /// <summary>
        /// Метод, вычисляющий среднее значение температуры в каждом месяце.
        /// </summary>
        /// <param name="temperature"> Словарь, содержащий ключ - название месяца, значение - массив со значениями температуры в каждый день месяца. </param>
        /// <returns> Словарь, содержащий ключ - название месяца, значение - среднее знаяение температуры в этом месяце. </returns>
        static Dictionary<string, double> CalculatesMounthAverageTemp(Dictionary<string, int[]> temperature)
        {
            Dictionary<string, double> mounthAverageTempDictionary = new Dictionary<string, double>();

            foreach (KeyValuePair<string, int[]> mounth in temperature)
            {
                int tempSumm = 0;

                for (int i = 0; i < mounth.Value.Length; i++)
                {
                    tempSumm += mounth.Value[i];
                }

                mounthAverageTempDictionary.Add(mounth.Key, (double)tempSumm / mounth.Value.Length);
            }

            return mounthAverageTempDictionary;
        }

        /// <summary>
        /// Метод, который выводит среднее значение температуры в каждом месяце на экран.
        /// </summary>
        /// <param name="mounthAverageTempArray"> Массив, содержащий среднее значение температуры в каждом месяце. </param>
        static void DisplaysMounthAverageTemperature(double[] mounthAverageTempArray)
        {
            for (int i = 0; i < mounthAverageTempArray.Length; i++)
            {
                DateTime mounth = new DateTime(1000, 1, 1).AddMonths(i);
                string mounthName = mounth.ToString("MMMM");

                Console.WriteLine($"Средняя температура в {mounthName} равна {mounthAverageTempArray[i]:F} градусам");
            }
        }

        /// <summary>
        /// Метод, который выводит среднее значение температуры в каждом месяце на экран.
        /// </summary>
        /// <param name="mounthAverageTempDictionary"> Словарь, содержащий ключ - название месяца, значение - среднее значение температуры в этом месяце. </param>
        static void DisplaysMounthAverageTemperature(Dictionary<string, double> mounthAverageTempDictionary)
        {
            foreach (KeyValuePair<string, double> mounth in mounthAverageTempDictionary)
            {
                Console.WriteLine($"Средняя темепература в {mounth.Key} равна {mounth.Value:F} градусам");
            }
        }

        static void Main(string[] links)
        {
            // Файлы для заданий распологаются в папке bin\Debug\ProgramFiles. Ссылки на них передаются как аргументы функции Main.
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 81}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №6. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 6.1. Программа подсчитывает число гласных и согласных букв в файле                  -   цифра 1\n" +
                                  "Упражнение 6.2. Программа умножает две матрицы второго порядка                                 -   цифра 2\n" +
                                  "Упражнение 6.3. Программа вычисляет среднюю температуру за год                                 -   цифра 3\n" +
                                  "Домашнее задание 6.1. Программа из Упражнения 6.1, но используются коллекции List              -   цифра 4\n" +
                                  "Домашнее задание 6.2. Программа из Упражнения 6.2, но используются коллекции LinkedList        -   цифра 5\n" +
                                  "Домашнее задание 6.3. Программа из Упражнения 6.3, но используется класс Dictionary            -   цифра 6\n" +
                                  "Закончить выполнение заданий и выйти из программы                                              -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 6.1. Программа подсчитывает число гласных и согласных букв в файле.
                        Console.Clear();
                        Console.WriteLine("{0, 97}", "УПРАЖНЕНИЕ 6.1. ПРОГРАММА ПОДСЧИТЫВАЕТ ЧИСЛО ГЛАСНЫХ И СОГЛАСНЫХ БУКВ В ФАЙЛЕ\n");

                        (int, int) lettersNumber;
                        FileInfo userFile = new FileInfo(links[0]);

                        if (userFile.Exists)
                        {
                            char[] userTextArray = File.ReadAllText(links[0]).ToUpper().ToCharArray();

                            lettersNumber = CountsLettersFromArray(userTextArray);

                            Console.WriteLine($"В приведенном текстовом файле {lettersNumber.Item1} гласных букв и {lettersNumber.Item2} согласных букв из алфавита русского языка");

                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Программа не обнаружила файл. Проверьте наличие файла!");
                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "2":
                        // Упражнение 6.2. Программа умножает две матрицы второго порядка.
                        Console.Clear();
                        Console.WriteLine("{0, 90}", "УПРАЖНЕНИЕ 6.2. ПРОГРАММА УМНОЖАЕТ ДВЕ МАТРИЦЫ ВТОРОГО ПОРЯДКА\n");

                        Random randomNumber = new Random();
                        int[,] firstMatrixArray = new int[2, 2];
                        int[,] secondMatrixArray = new int[2, 2];
                        int[,] resultMatrix;

                        for (int i = 0; i < firstMatrixArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < firstMatrixArray.GetLength(1); j++)
                            {
                                firstMatrixArray[i, j] = randomNumber.Next(20);
                                secondMatrixArray[i, j] = randomNumber.Next(20);
                            }
                        }

                        resultMatrix = MultiplyingTwoMatrices(firstMatrixArray, secondMatrixArray);

                        DisplayingMatrices(firstMatrixArray);
                        Console.WriteLine("{0, 6}", "*");
                        DisplayingMatrices(secondMatrixArray);
                        Console.WriteLine("{0, 6}", "=");
                        DisplayingMatrices(resultMatrix);

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        // Упражнение 6.3. Программа вычисляет среднюю температуру за год.
                        Console.Clear();
                        Console.WriteLine("{0, 90}", "УПРАЖНЕНИЕ 6.3. ПРОГРАММА ВЫЧИСЛЯЕТ СРЕДНЮЮ ТЕМПЕРАТУРУ ЗА ГОД\n");

                        Random randomTemperature = new Random();
                        int[,] temperature = new int[12, 30];
                        double[] mounthAverageTempArray = new double[12];
                        double averageYearTemp = 0;


                        for (int i = 0; i < temperature.GetLength(0); i++)
                        {
                            for (int j = 0; j < temperature.GetLength(1); j++)
                            {
                                temperature[i, j] = randomTemperature.Next(-35, 40);
                            }
                        }

                        mounthAverageTempArray = CalculatesMounthAverageTemp(temperature);
                        DisplaysMounthAverageTemperature(mounthAverageTempArray);

                        for (int i = 0; i < mounthAverageTempArray.Length; i++)
                        {
                            averageYearTemp += mounthAverageTempArray[i];
                        }

                        averageYearTemp /= mounthAverageTempArray.Length;

                        Console.WriteLine($"\nСредняя температура за год равна {averageYearTemp:F} градусам");
                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        // Домашнее задание 6.1. Программа из Упражнения 6.1, но используются коллекции List.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "ДОМАШНЕЕ ЗАДАНИЕ 6.1. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 6.1, НО ИСПОЛЬЗУЮТСЯ КОЛЛЕКЦИИ LIST\n");

                        userFile = new FileInfo(links[0]);

                        if (userFile.Exists)
                        {
                            List<char> userTextList = new List<char>(File.ReadAllText(links[0]).ToUpper().ToCharArray());

                            lettersNumber = CountsLettersFromList(userTextList);

                            Console.WriteLine($"В приведенном текстовом файле {lettersNumber.Item1} гласных букв и {lettersNumber.Item2} согласных букв алфавита русского языка");

                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Программа не обнаружила файл. Проверьте наличие файла!");
                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "5":
                        // Домашнее задание 6.2. Программа из Упражнения 6.2, но используются коллекции LinkedList.
                        Console.Clear();
                        Console.WriteLine("{0, 104}", "ДОМАШНЕЕ ЗАДАНИЕ 6.2. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 6.2, НО ИСПОЛЬЗУЮТСЯ КОЛЛЕКЦИИ LINKEDLIST\n");

                        Random randomNum = new Random();
                        LinkedList<int> firstMatrixList = new LinkedList<int>();
                        LinkedList<int> secondMatrixList = new LinkedList<int>();
                        LinkedList<int> resultMatrixList = new LinkedList<int>();

                        for (int i = 0; i <= 3; i++)
                        {
                            firstMatrixList.AddLast(randomNum.Next(20));
                            secondMatrixList.AddLast(randomNum.Next(20));
                        }

                        resultMatrixList = MultiplyingTwoMatrices(firstMatrixList, secondMatrixList);

                        DisplayingMatrices(firstMatrixList);
                        Console.WriteLine("{0, 6}", "*");
                        DisplayingMatrices(secondMatrixList);
                        Console.WriteLine("{0, 6}", "=");
                        DisplayingMatrices(resultMatrixList);

                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case "6":
                        // Домашнее задание 6.3. Программа из Упражнения 6.3, но используется класс Dictionary.
                        Console.Clear();
                        Console.WriteLine("{0, 101}", "ДОМАШНЕЕ ЗАДАНИЕ 6.3. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 6.3, НО ИСПОЛЬЗУЕТСЯ КЛАСС DICTIONARY\n");

                        Dictionary<string, int[]> yearTemperature = new Dictionary<string, int[]>();
                        Dictionary<string, double> mounthAverageTempList = new Dictionary<string, double>();
                        randomTemperature = new Random();
                        averageYearTemp = 0;

                        for (int i = 0; i < 12; i++)
                        {
                            int[] mounthTemp = new int[30];

                            for (int j = 0; j < 30; j++)
                            {
                                mounthTemp[j] = randomTemperature.Next(-35, 40);
                            }

                            DateTime mounth = new DateTime(1000, 1, 1).AddMonths(i);
                            string mounthName = mounth.ToString("MMMM");
                            yearTemperature.Add(mounthName, mounthTemp);
                        }

                        mounthAverageTempList = CalculatesMounthAverageTemp(yearTemperature);
                        DisplaysMounthAverageTemperature(mounthAverageTempList);

                        foreach (KeyValuePair<string, double> mounth in mounthAverageTempList)
                        {
                            averageYearTemp += mounth.Value;
                        }

                        averageYearTemp /= yearTemperature.Count;

                        Console.WriteLine($"\nСредняя температура за год равна {averageYearTemp:F} градусам");
                        Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("{0, 69}", "ВЫ ВЫШЛИ ИЗ ПРОГРАММЫ");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("{0, 98}", "ТАКОГО ЗАДАНИЯ НЕТ! ДОСТУПНЫЕ ЗАДАНИЯ УКАЗАНЫ В ПОДСКАЗКЕ. ПОВТОРИТЕ ПОПЫТКУ\n");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}

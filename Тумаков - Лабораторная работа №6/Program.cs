using System;
using System.Collections.Generic;
using System.IO;

namespace Тумаков___Лабораторная_работа__6
{
    class Program
    {
        /// <summary>
        /// Метод, подсчитывающий количество гласных и согласных букв в передаваемом массиве.
        /// </summary>
        /// <param name="lettersArray"> Массив символов </param>
        /// <returns> Возвращает кортеж, первый элемент которого число гласных букв, а второй - число согласных </returns>
        static (int, int) CountsVowelsFromArray(char[] lettersArray)
        {
            (int, int) lettersNumber = (0, 0);
            char[] vowelsArray = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };

            foreach (char letter in lettersArray)
            {
                if (Array.IndexOf(vowelsArray, letter) != -1)
                {
                    lettersNumber.Item1++;
                }
                else if (letter == '\r' || letter == '\n' || letter == ' ')
                {
                    continue;
                }
                else
                {
                    lettersNumber.Item2++;
                }
            }
            return lettersNumber;
        }
        /// <summary>
        /// Метод, подсчитывающий количество гласных и согласных букв в передаваемом массиве.
        /// </summary>
        /// <param name="lettersList"> Коллекция символов </param>
        /// <returns> Возвращает кортеж, первый элемент которого число гласных букв, а второй - число согласных </returns>
        static (int, int) CountsVowelsFromArray(List<char> lettersList)
        {
            (int, int) lettersNumber = (0, 0);
            char[] vowelsArray = { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };

            foreach (char letter in lettersList)
            {
                if (Array.IndexOf(vowelsArray, letter) != -1)
                {
                    lettersNumber.Item1++;
                }
                else if (letter == '\r' || letter == '\n' || letter == ' ')
                {
                    continue;
                }
                else
                {
                    lettersNumber.Item2++;
                }
            }
            return lettersNumber;
        }
        /// <summary>
        /// Метод, умножающий две матрицы второго порядка.
        /// </summary>
        /// <param name="firstMatrixArray"> Двумерный массив, содержащий первую матрицу второго порядка. </param>
        /// <param name="secondMatrixArray"> Двумерный массив, содержащий вторую матрицу второго порядка. </param>
        /// <returns> Двумерный массив, содержащий матрицу второго порядка, которая является результатом умножения. </returns>
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
        /// <param name="firstMatrixArray"> Первая матрица второго порядка. </param>
        /// <param name="secondMatrixArray"> Вторая матрица второго порядка. </param>
        /// <returns> Матрица второго порядка, которая является результатом умножения. </returns>
        static LinkedList<int> MultiplyingTwoMatrices(LinkedList<int> firstMatrixList, LinkedList<int> secondMatrixList)
        {
            LinkedList<int> resultMatrixList = new LinkedList<int>();

            resultMatrixList.AddFirst(firstMatrixList.First.Value * secondMatrixList.First.Value + firstMatrixList.First.Next.Value * secondMatrixList.First.Next.Next.Value);
            resultMatrixList.AddLast(firstMatrixList.First.Value * secondMatrixList.First.Next.Value + firstMatrixList.Last.Previous.Value * secondMatrixList.Last.Value);
            resultMatrixList.AddLast(firstMatrixList.Last.Previous.Value * secondMatrixList.First.Value + firstMatrixList.Last.Value * secondMatrixList.Last.Previous.Value);
            resultMatrixList.AddLast(firstMatrixList.Last.Previous.Value * secondMatrixList.First.Next.Value + firstMatrixList.Last.Value * secondMatrixList.Last.Value);

            return resultMatrixList;
        }
        /// <summary>
        /// Метод, который выводит на экран матрицу второго порядка.
        /// </summary>
        /// <param name="matrix"> Матрица второго порядка. </param>
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
        static void DisplayingMatrices(LinkedList<int> matrix)
        {
            int count = 0;
            foreach (int number in matrix)
            {
                Console.Write(String.Format("{0, 4}", number));
                count++;
                if (count == 2)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
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
                mounthAverageTempArray[i] = tempSumm / temperature.GetLength(1);
            }
            return mounthAverageTempArray;
        }
        static Dictionary<string, double>  CalculatesMounthAverageTemp(Dictionary<string, int[]> yearTemperature)
        {
            Dictionary<string, double> mounthAverageTempDictionary = new Dictionary<string, double>();

            foreach (var mounth in yearTemperature)
            {
                int tempSumm = 0;
                for (int i = 0; i < mounth.Value.Length; i++)
                {
                    tempSumm += mounth.Value[i];
                }

                mounthAverageTempDictionary.Add(mounth.Key, tempSumm / mounth.Value.Length);
            }
            return mounthAverageTempDictionary;
        }
        static void DisplaysMounthAverageTemperature(double[] mounthAverageTempArray)
        {
            for (int i = 0; i < mounthAverageTempArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"Средняя температура в Январе равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 1:
                        Console.WriteLine($"Средняя температура в Феврале равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 2:
                        Console.WriteLine($"Средняя температура в Марте равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 3:
                        Console.WriteLine($"Средняя температура в Апреле равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 4:
                        Console.WriteLine($"Средняя температура в Мае равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 5:
                        Console.WriteLine($"Средняя температура в Июне равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 6:
                        Console.WriteLine($"Средняя температура в Июле равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 7:
                        Console.WriteLine($"Средняя температура в Августе равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 8:
                        Console.WriteLine($"Средняя температура в Сентябре равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 9:
                        Console.WriteLine($"Средняя температура в Октябре равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 10:
                        Console.WriteLine($"Средняя температура в Ноябре равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                    case 11:
                        Console.WriteLine($"Средняя температура в Декабре равна {mounthAverageTempArray[i]:F} градусам");
                        break;
                }
            }
        }
        static void DisplaysMounthAverageTemperature(Dictionary<string, double> mounthAverageTempDictionary)
        {
            foreach (var mounth in mounthAverageTempDictionary)
            {
                Console.WriteLine($"Средняя темепература в {mounth.Key} равна {mounth.Value:F} градусам");
            }
        }
            static void Main(string[] links)
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 81}", "ТУМАКОВ - ЛАБОРАТОРНАЯ РАБОТА №6. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 6.1. Программа подсчитывает число гласных и согласных букв в файле              -   цифра 1\n" +
                                  "Упражнение 6.2. Программа умножает две матрицы второго порядка                             -   цифра 2\n" +
                                  "Упражнение 6.3. Программа вычисляет среднюю температуру за год                             -   цифра 3\n" +
                                  "Домашнее задание 6.1. Программа из Упражнения 6.1, но используются коллекции List          -   цифра 4\n" +
                                  "Домашнее задание 6.2. Программа из Упражнения 6.2, но используются коллекции LinkedList    -   цифра 5\n" +
                                  "Домашнее задание 6.3. Программа из Упражнения 6.3, но используется класс Dictionary        -   цифра 6\n" +
                                  "Закончить выполнение заданий и выйти из программы                                          -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Упражнение 6.1. Программа подсчитывает число гласных и согласных букв в файле.
                        Console.Clear();
                        Console.WriteLine("{0, 97}", "УПРАЖНЕНИЕ 6.1. ПРОГРАММА ПОДСЧИТЫВАЕТ ЧИСЛО ГЛАСНЫХ И СОГЛАСНЫХ БУКВ В ФАЙЛЕ\n");

                        FileInfo userFile = new FileInfo(links[0]);

                        if (userFile.Exists)
                        {
                            char[] userTextArray = File.ReadAllText(links[0]).ToUpper().ToCharArray();

                            (int, int) lettersNumber = CountsVowelsFromArray(userTextArray);

                            Console.WriteLine($"В приведенном текстовом файле {lettersNumber.Item1} гласных букв и {lettersNumber.Item2} согласных букв");

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
                        // Упражнение 6.2. Программа умножает матрицы второго порядка.
                        Console.Clear();
                        Console.WriteLine("{0, 90}", "УПРАЖНЕНИЕ 6.2. ПРОГРАММА УМНОЖАЕТ ДВЕ МАТРИЦЫ ВТОРОГО ПОРЯДКА\n");

                        Random randomNumber = new Random();
                        int[,] firstMatrixArray = new int[2, 2];
                        int[,] secondMatrixArray = new int[2, 2];
                        int[,] resultMatrix;

                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
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

                        FileInfo userTextFile = new FileInfo(links[0]);

                        if (userTextFile.Exists)
                        {
                            List<char> userTextList = new List<char>(File.ReadAllText(links[0]).ToUpper().ToCharArray());

                            (int, int) lettersNumber = CountsVowelsFromArray(userTextList);

                            Console.WriteLine($"В приведенном текстовом файле {lettersNumber.Item1} гласных букв и {lettersNumber.Item2} согласных букв");

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
                        Console.WriteLine("{0, 105}", "ДОМАШНЕЕ ЗАДАНИЕ 6.2. ПРОГРАММА ИЗ УПРАЖНЕНИЯ 6.2, НО ИСПОЛЬЗУЮТСЯ КОЛЛЕКЦИИ LINKEDLIST\n");

                        Random randomNum = new Random();
                        LinkedList<int> firstMatrixList = new LinkedList<int>();
                        LinkedList<int> secondMatrixList = new LinkedList<int>();
                        LinkedList<int> resultMatrixList = new LinkedList<int>();

                        firstMatrixList.AddFirst(randomNum.Next(20));
                        secondMatrixList.AddFirst(randomNum.Next(20));

                        for (int i = 0; i <= 2; i++)
                        {
                            firstMatrixList.AddAfter(firstMatrixList.First, randomNum.Next(20));
                            secondMatrixList.AddAfter(secondMatrixList.First, randomNum.Next(20));
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
                        Random randomTemp = new Random();
                        averageYearTemp = 0;

                        for (int i = 0; i < 12; i++)
                        {
                            int[] mounthTemp = new int[30];
                            for (int j = 0; j < 30; j++)
                            {
                                mounthTemp[j] = randomTemp.Next(-35, 40);
                            }
                            switch (i)
                            {
                                case 0:
                                    yearTemperature.Add("Январь", mounthTemp);
                                    break;
                                case 1:
                                    yearTemperature.Add("Февраль", mounthTemp);
                                    break;
                                case 2:
                                    yearTemperature.Add("Март", mounthTemp);
                                    break;
                                case 3:
                                    yearTemperature.Add("Апрель", mounthTemp);
                                    break;
                                case 4:
                                    yearTemperature.Add("Май", mounthTemp);
                                    break;
                                case 5:
                                    yearTemperature.Add("Июнь", mounthTemp);
                                    break;
                                case 6:
                                    yearTemperature.Add("Июль", mounthTemp);
                                    break;
                                case 7:
                                    yearTemperature.Add("Август", mounthTemp);
                                    break;
                                case 8:
                                    yearTemperature.Add("Сентябрь", mounthTemp);
                                    break;
                                case 9:
                                    yearTemperature.Add("Октябрь", mounthTemp);
                                    break;
                                case 10:
                                    yearTemperature.Add("Ноябрь", mounthTemp);
                                    break;
                                case 11:
                                    yearTemperature.Add("Декабрь", mounthTemp);
                                    break;
                            }
                        }
                        mounthAverageTempList = CalculatesMounthAverageTemp(yearTemperature);
                        DisplaysMounthAverageTemperature(mounthAverageTempList);

                        foreach (var mounth in mounthAverageTempList)
                        {
                            averageYearTemp += mounth.Value;
                        }

                        averageYearTemp /= 12;

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

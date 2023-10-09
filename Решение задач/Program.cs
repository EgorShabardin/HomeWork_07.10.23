using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Решение_задач
{   /// <summary>
    /// Структура, содержащая данные о студенте (имя фамилия, год рождения, экзамен, балл), а также метод, который заполняет структуру.
    /// </summary>
    class Program
    {
        struct Student
        {
            public string name;
            public string surname;
            public int birthdayYear;
            public string exam;
            public int examScores;
            /// <summary>
            /// Метод, заполняющий структуру Sudent.
            /// </summary>
            /// <param name="studentDataArray"> Массив с данными студента </param>
            /// <returns> Возвращает результат преобразования некоторых данных в целые числа </returns>
            public (bool, bool) FillingStudentData(string[] studentDataArray)
            {
                (bool, bool) ParseResult;

                name = studentDataArray[0];
                surname = studentDataArray[1];
                ParseResult.Item1 = int.TryParse(studentDataArray[2], out birthdayYear);
                exam = studentDataArray[3];
                ParseResult.Item2 = int.TryParse(studentDataArray[4], out examScores);

                return ParseResult;
            }
        }
        /// <summary>
        /// Метод, который выводит список студентов на экран.
        /// </summary>
        /// <param name="studentsList"> Словарь со студентами </param>
        static void DisplayStudentsList(Dictionary<string, Student> studentsList)
        {
            Console.WriteLine("{0, 68}", "СПИСОК СТУДЕНТОВ\n");
            Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}\n", "Имя", "Фамилия", "Год_рождения", "Экзамен", "Баллы");

            foreach (var student in studentsList)
            {
                Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}", student.Value.name, student.Value.surname,
                                  student.Value.birthdayYear, student.Value.exam, student.Value.examScores);
            }
            Console.WriteLine();
        }
        struct GrandMother
        {
            public string name;
            public int age;
            public string[] illnesses;
            public string[] medicines;
        }
        struct Hospital
        {
            public string name;
            public string[] illnesses;
            public int patientsToday;
            public int patientsTotal;
        }
        static void Main(string[] links)
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 71}", "РЕШЕНИЕ ЗАДАЧ. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1. Программа создает коллекцию List с картинками, перемешивает ее и выводит на экран                    -   цифра 1\n" +
                                  "Задание №2. Программа создает словарь студентов и реализует различные действия с этим словарем    -   цифра 2\n" +
                                  "Задание №3. Программа получает число и выводит на экран его рисунок                               -   цифра 3\n" +
                                  "Задание №4. Программа создает 5 дедов и подсчитывает количество фингалов                          -   цифра 4\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                 -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        break;

                    case "2":
                        // Задание №2. Программа создает словарь студентов и реализует различные действия с этим словарем.
                        Console.Clear();
                        Console.WriteLine("{0, 107}", "ЗАДАНИЕ №2. ПРОГРАММА СОЗДАЕТ СЛОВАРЬ СТУДЕНТОВ И РЕАЛИЗУЕТ РАЗЛИЧНЫЕ ДЕЙСТВИЯ С ЭТИМ СЛОВАРЕМ\n");

                        Dictionary<string, Student> studentsDictionary = new Dictionary<string, Student>();
                        FileInfo studentsDataFile = new FileInfo(links[0]);
                        string actionsStudentsDictionary;
                        (bool, bool) parseResult = (false, false);
                        bool actionsStudentsDictionaryEnd = false;

                        if (studentsDataFile.Exists)
                        {
                            string[] studentDataArray = File.ReadAllLines(links[0]);

                            for (int i = 0; i < studentDataArray.Length; i++)
                            {
                                string[] studentData = studentDataArray[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                Student student = new Student();

                                parseResult = student.FillingStudentData(studentData);

                                studentsDictionary.Add(studentData[0] + studentData[1], student);
                            }

                            if (parseResult.Item1 && parseResult.Item2)
                            {
                                do
                                {
                                    Console.WriteLine("{0, 77}", "МЕНЮ РАБОТЫ СО СПИСКОМ СТУДЕНТОВ\n");
                                    Console.WriteLine("Подсказка:\n" +
                                                      "Чтобы добавить нового студента в список, введите                       Новый студент\n" +
                                                      "Чтобы удалить студента из списка, введите                              Удалить\n" +
                                                      "Чтобы отсортировать студентов по баллам экзамента, введите             Сортировать\n" +
                                                      "Чтобы закончить работу со списком, введите                             Закончить\n");

                                    DisplayStudentsList(studentsDictionary);
                                    Console.Write("Введитите действие, которое вы хотите сделать со списком студентов: ");
                                    actionsStudentsDictionary = Console.ReadLine().ToUpper();

                                    switch (actionsStudentsDictionary)
                                    {
                                        case "НОВЫЙ СТУДЕНТ":
                                            Console.Clear();
                                            DisplayStudentsList(studentsDictionary);

                                            Student student = new Student();

                                            Console.WriteLine("Введите данные студента через пробел (имя, фамилия, год рождения, экзамен, баллы): ");
                                            string[] studentData = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);

                                            parseResult = student.FillingStudentData(studentData);

                                            if (parseResult.Item1 && parseResult.Item2 && studentData.Length == 5)
                                            {
                                                studentsDictionary.Add(studentData[0] + studentData[1], student);

                                                Console.WriteLine("\nВы добавили нового студента!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nВы ввели некорректные данные. Повторите попытку!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            break;

                                        case "УДАЛИТЬ":
                                            Console.Clear();
                                            DisplayStudentsList(studentsDictionary);

                                            string studentName, studentSurname;

                                            Console.Write("Введите имя студента, которого необходимо удалить: ");
                                            studentName = Console.ReadLine();
                                            Console.Write("Введите фамилию студента, которого необходимо удалить: ");
                                            studentSurname = Console.ReadLine();

                                            if (studentsDictionary.ContainsKey(studentName + studentSurname))
                                            {
                                                studentsDictionary.Remove(studentName + studentSurname);
                                                Console.WriteLine("\nВы удалили студетна!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого студента в списке нет. Повторите попытку!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            break;

                                        case "СОРТИРОВАТЬ":
                                            Console.Clear();
                                            DisplayStudentsList(studentsDictionary);

                                            studentsDictionary = studentsDictionary.OrderBy(data => data.Value.examScores).ToDictionary(data => data.Key, data => data.Value);
                                            Console.Clear();
                                            break;

                                        case "ЗАКОНЧИТЬ":
                                            Console.Clear();
                                            actionsStudentsDictionaryEnd = true;
                                            break;

                                        default:
                                            Console.Clear();
                                            Console.WriteLine("{0, 80}", "Такое действие со списком студентов нельзя выполнить. Повторите попытку!");
                                            break;
                                    }
                                } while (!actionsStudentsDictionaryEnd);
                            }
                            else
                            {
                                Console.WriteLine("В файле находятся некорректные данные!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Программа не обнаружила файл. Проверьте наличие файла!");
                            Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "3":
                        //
                        Console.Clear();
                        Console.WriteLine();

                        Queue <GrandMother> grandMothersList = new Queue<GrandMother>();
                        Stack<Hospital> hospitalList = new Stack<Hospital>();
                        bool grandMotherHospitalTaskEnd = false;

                        Hospital firstHospital = new Hospital();
                        firstHospital.name = "Северная";
                        firstHospital.illnesses = new string[] { "ангина", "простуда", "грипп", "больная спина" };
                        firstHospital.patientsToday = 0;
                        firstHospital.patientsTotal = 10;
                        hospitalList.Push(firstHospital);

                        Hospital secondHospital = new Hospital();
                        secondHospital.name = "Южная";
                        secondHospital.illnesses = new string[] { "больная нога", "простуда", "больное горло", "больная голова" };
                        secondHospital.patientsToday = 0;
                        secondHospital.patientsTotal = 5;
                        hospitalList.Push(secondHospital);

                        Hospital thirdHospital = new Hospital();
                        thirdHospital.name = "Центральная";
                        thirdHospital.illnesses = new string[] { "больная шея", "больная голова", "ангина", "грипп" };
                        thirdHospital.patientsToday = 0;
                        thirdHospital.patientsTotal = 3;
                        hospitalList.Push(thirdHospital);

                        do
                        {
                            Console.WriteLine("Чтобы закончить выполнение задание, введите закончить");
                            string name;
                            string[] illnesses, medicines;
                            int birthdayYear;
                            bool result

                            Console.Write("Введите имя бабули: ");
                            name = Console.ReadLine();
                            Console.Write("Введите год рождения бабули: ");
                            result = int.TryParse(Console.ReadLine(), out birthdayYear);


                        } while (!grandMotherHospitalTaskEnd);
                        break;
                    case "4":
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while (!tasksEnd);
        }
    }
}

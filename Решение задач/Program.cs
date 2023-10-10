using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Решение_задач
{
    class Program
    {   
        /// <summary>
        /// Структура, содержащая данные о студенте (имя фамилия, год рождения, экзамен, балл) и метод, который заполняет структуру.
        /// </summary>
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
                exam = studentDataArray[3];
                ParseResult.Item1 = int.TryParse(studentDataArray[2], out birthdayYear);
                ParseResult.Item2 = int.TryParse(studentDataArray[4], out examScores);

                return ParseResult;
            }
        }
        /// <summary>
        /// Метод, который выводит список студентов на экран.
        /// </summary>
        /// <param name="studentsList"> Словарь, содержащий студентов </param>
        static void DisplayStudentsDictionary(Dictionary<string, Student> studentsDictionary)
        {
            Console.WriteLine("{0, 68}", "СПИСОК СТУДЕНТОВ\n");
            Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}\n", "Имя", "Фамилия", "Год_рождения", "Экзамен", "Баллы");

            for (int i = 0; i < studentsDictionary.Count; i++)
            {
                KeyValuePair<string, Student> student = studentsDictionary.ElementAt(i);
                Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}", student.Value.name, student.Value.surname, 
                                             student.Value.birthdayYear, student.Value.exam, student.Value.examScores);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Структура, содержащая данные о бабуле (имя, возраст, болезни, лекарства) и метод, который заполняет структуру.
        /// </summary>
        struct Grandmother
        {
            public string name;
            public int age;
            public string[] illnesses;
            public string[] medicines;
            /// <summary>
            /// Медод, заполняющий структуру Grandmother
            /// </summary>
            /// <param name="grannyName"> Строка, содержащая имя бабули </param>
            /// <param name="grannyBirthdayYear"> Целое число - год рождения бабули </param>
            /// <param name="grannyIllnesses"> Массив строк - болезни бабули </param>
            /// <param name="grannyMedicines"> Массив строк - лекарства бабули </param>
            public void FillingsGrandMotherData(string grannyName, int grannyBirthdayYear, string[] grannyIllnesses, string[] grannyMedicines)
            {
                int todayYear = DateTime.Today.Year;

                name = grannyName;
                age = todayYear - grannyBirthdayYear;
                illnesses = grannyIllnesses;
                medicines = grannyMedicines;
            }
        }
        /// <summary>
        /// Структура, содержащая данные о больнице (название, болезни, количество бабуль сегодня, максимальное количество бабуль.
        /// </summary>
        struct Hospital
        {
            public string name;
            public string[] illnesses;
            public int patientsToday;
            public int patientsTotal;
        }
        /// <summary>
        /// Метод, распределяющий бабуль по больницам
        /// </summary>
        /// <param name="grandmotherQueue"> Очередь, содержащая бабуль </param>
        /// <param name="hospitalsStack"> Стек, содержащий больницы </param>
        /// <returns> Возвращает true, если бабуля попала в больницу, или false, если бабуля осталась на улице </returns>
        static bool DistributionGrandmothersToHospitals(Queue<Grandmother> grandmotherQueue, Stack<Hospital> hospitalsStack)
        {
            Grandmother granny = grandmotherQueue.Dequeue();
            int hospitalNumbers = hospitalsStack.Count;
            double numberEligibleDiseases = 0;

            if (granny.illnesses.Length == 0)
            {
                for (int i = 0; i < hospitalNumbers; i++)
                {
                    Hospital hospital = hospitalsStack.Pop();

                    if (hospital.patientsToday < hospital.patientsTotal)
                    {
                        hospital.patientsToday++;
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < hospitalNumbers; i++)
                {
                    Hospital hospital = hospitalsStack.Pop();

                    foreach (string illness in granny.illnesses)
                    {
                        if (Array.IndexOf(hospital.illnesses, illness.ToLower()) != -1)
                        {
                            numberEligibleDiseases++;
                        }
                    }

                    if ((numberEligibleDiseases / granny.illnesses.Length * 100) > 50)
                    {
                        if (hospital.patientsToday < hospital.patientsTotal)
                        {
                            hospital.patientsToday++;
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// Метод, который выводит таблицу больниц на экран
        /// </summary>
        /// <param name="hospitalsStack"> Стек, содержащий больницы </param>
        static void DisplaysHospitalData(List<Hospital> hospitalsStack)
        {
            Console.WriteLine("{0, 66}", "Список больниц\n");
            Console.WriteLine("{0, 15} {1, 36} {2, 30} {3, 25}\n", "Название", "Список болезней", "Пациентов сейчас", "Пациентов максимум");

            for (int i = 0; i < hospitalsStack.Count; i++)
            {
                Hospital hospital = hospitalsStack[i];
                string illnesses = "";

                for (int j = 0; j < hospital.illnesses.Length; j++)
                {
                    illnesses += hospital.illnesses[j] + " ";
                }

                Console.WriteLine("{0, 15} {1, 37} {2, 29} {3, 25}", hospital.name, illnesses, hospital.patientsToday, hospital.patientsTotal);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод, который выводит таблицу бабуль на экран
        /// </summary>
        /// <param name="grandmothersQueue"> Очередь, содержащая бабуль </param>
        static void DisplaysGrangmotherData(List<Grandmother> grandmothersList)
        {
            Console.WriteLine("{0, 66}", "Список бабуль\n");
            Console.WriteLine("{0, 15} {1, 36} {2, 30} {3, 25}\n", "Имя", "Список болезней", "Список лекарств", "Возраст");

            for (int i = 0; i < grandmothersList.Count; i++)
            {
                Grandmother granny = grandmothersList[i];
                string illnesses = "";
                string medicines = "";

                for (int j = 0; j < granny.illnesses.Length; j++)
                {
                    illnesses += granny.illnesses[j] + " ";
                    medicines += granny.medicines[j] + " ";
                }

                Console.WriteLine("{0, 15} {1, 37} {2, 30} {3, 24}", granny.name, illnesses, medicines, granny.age);
            }
            Console.WriteLine();
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
                        //
                        Console.Clear();
                        Console.WriteLine();


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

                                    DisplayStudentsDictionary(studentsDictionary);
                                    Console.Write("Введитите действие, которое вы хотите сделать со списком студентов: ");
                                    actionsStudentsDictionary = Console.ReadLine().ToUpper();

                                    switch (actionsStudentsDictionary)
                                    {
                                        case "НОВЫЙ СТУДЕНТ":
                                            Console.Clear();
                                            DisplayStudentsDictionary(studentsDictionary);

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
                                            DisplayStudentsDictionary(studentsDictionary);

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
                                            DisplayStudentsDictionary(studentsDictionary);

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
                        // Задание №3. Программа получает на вход бабуль и распределяет их по больницам.
                        Console.Clear();
                        Console.WriteLine("{0, 100}", "ЗАДАНИЕ №3. ПРОГРАММА ПОЛУЧАЕТ НА ВХОД БАБУЛЬ И РАСПРЕДЕЛЯЕТ ИХ ПО БОЛЬНИЦАМ\n");

                        Queue<Grandmother> grandmothersQueue = new Queue<Grandmother>();
                        List<Grandmother> grandmothersList = new List<Grandmother>();
                        List<Hospital> hospitalList = new List<Hospital>();
                        bool grandMotherHospitalTaskEnd = false;

                        Hospital firstHospital = new Hospital();
                        firstHospital.name = "Северная";
                        firstHospital.illnesses = new string[] { "ангина", "простуда", "грипп", "спина" };
                        firstHospital.patientsToday = 0;
                        firstHospital.patientsTotal = 10;
                        hospitalList.Add(firstHospital);

                        Hospital secondHospital = new Hospital();
                        secondHospital.name = "Южная";
                        secondHospital.illnesses = new string[] { "нога", "простуда", "горло", "голова" };
                        secondHospital.patientsToday = 0;
                        secondHospital.patientsTotal = 5;
                        hospitalList.Add(secondHospital);

                        Hospital thirdHospital = new Hospital();
                        thirdHospital.name = "Центральная";
                        thirdHospital.illnesses = new string[] { "шея", "голова", "ангина", "грипп" };
                        thirdHospital.patientsToday = 0;
                        thirdHospital.patientsTotal = 3;
                        hospitalList.Add(thirdHospital);

                        do
                        {
                            DisplaysHospitalData(hospitalList);
                            DisplaysGrangmotherData(grandmothersList);
                            Console.WriteLine("Чтобы закончить выполнение задание, введите закончить");
                            Grandmother grandmother = new Grandmother();
                            string name;
                            string[] illnesses, medicines;
                            int birthdayYear;
                            bool result;

                            Console.Write("Введите имя бабули: ");
                            name = Console.ReadLine();
                            Console.Write("Введите год рождения бабули: ");
                            result = int.TryParse(Console.ReadLine(), out birthdayYear);
                            Console.Write("Введите болезни бабули через пробел: ");
                            illnesses = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);
                            Console.Write("Введите лекарства бабули через пробел: ");
                            medicines = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);

                            if (result)
                            {
                                bool resultGranny;
                                Stack<Hospital> hospitalStack = new Stack<Hospital>(hospitalList);

                                grandmother.FillingsGrandMotherData(name, birthdayYear, illnesses, medicines);
                                grandmothersList.Add(grandmother);
                                grandmothersQueue.Enqueue(grandmother);
                                resultGranny = DistributionGrandmothersToHospitals(grandmothersQueue, hospitalStack);

                                if (resultGranny)
                                {
                                    Console.WriteLine("Бабуля попала в больницу!");
                                    Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Бабуля не попала в больницу. Она плачет на улице(");
                                    Console.Write("Чтобы продолжить нажмите на любую кнопку: ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели некорректные данные. Повторите попытку!");
                                Console.Clear();
                            }
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

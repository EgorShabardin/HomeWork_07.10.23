using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace Решение_задач
{
    class Program
    {
        /// <summary>
        /// Метод, который перемешивает коллекцию изображений и коллекцию их индексов.
        /// </summary>
        /// <param name="imagesList"> Коллекция изображений. </param>
        /// <param name="imageIndexesList"> Коллекция индексов изображений. </param>
        static void ShufflingCollections(List<Image> imagesList, List<int> imageIndexesList)
        {
            Random randomIndex = new Random();

            for (int i = (imagesList.Count - 1); i >= 1; i--)
            {
                int index = randomIndex.Next(i - 1);

                int number = imageIndexesList[index];
                Image img = imagesList[index];

                imageIndexesList[index] = imageIndexesList[i];
                imageIndexesList[i] = number;    
                imagesList[index] = imagesList[i];
                imagesList[i] = img;
            }
        }
       
        /// <summary>
        /// Структура, содержащая данные о студенте (имя, фамилия, год рождения, экзамен, балл) и метод, который заполняет структуру.
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
            /// <returns> Возвращает результат преобразования некоторых данных в тип int. </returns>
            public (bool, bool) FillingStudentData(string[] studentDataArray)
            {
                (bool, bool) parseResult;

                name = studentDataArray[0];
                surname = studentDataArray[1];
                exam = studentDataArray[3];
                parseResult.Item1 = int.TryParse(studentDataArray[2], out birthdayYear);
                parseResult.Item2 = int.TryParse(studentDataArray[4], out examScores);

                return parseResult;
            }
        }

        /// <summary>
        /// Метод, который выводит студентов списком на экран.
        /// </summary>
        /// <param name="studentsDictionary"> Словарь, содержащий всех студентов. </param>
        static void DisplayStudentsDictionary(Dictionary<string, Student> studentsDictionary)
        {
            Console.WriteLine("{0, 68}", "СПИСОК СТУДЕНТОВ\n");
            Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}\n", "Имя", "Фамилия", "Год рождения", "Экзамен", "Баллы");

            for (int i = 0; i < studentsDictionary.Count; i++)
            {
                KeyValuePair<string, Student> student = studentsDictionary.ElementAt(i);

                Console.WriteLine("{0, 10} {1, 22} {2, 27} {3, 22} {4, 20}", student.Value.name, student.Value.surname, student.Value.birthdayYear, student.Value.exam, student.Value.examScores);
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
            /// Медод, заполняющий структуру Grandmother.
            /// </summary>
            /// <param name="grannyName"> Строка, содержащая имя бабули. </param>
            /// <param name="grannyBirthdayYear"> Целое число - год рождения бабули. </param>
            /// <param name="grannyIllnesses"> Массив строк - болезни бабули. </param>
            /// <param name="grannyMedicines"> Массив строк - лекарства бабули. </param>
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
        /// Структура, содержащая данные о больнице (название, болезни, количество бабуль сегодня, максимальное количество бабуль).
        /// </summary>
        struct Hospital
        {
            public string name;
            public string[] illnesses;
            public int patientsToday;
            public int patientsTotal;
        }

        /// <summary>
        /// Метод, распределяющий бабуль по больницам.
        /// </summary>
        /// <param name="grandmotherQueue"> Очередь, содержащая бабуль. </param>
        /// <param name="hospitalsStack"> Стек, содержащий больницы. </param>
        /// <returns> Возвращает true, если бабуля попала в больницу, и false, если бабуля в больницу не попала. </returns>
        static bool DistributionGrandmothersToHospitals(Queue<Grandmother> grandmotherQueue, Stack<Hospital> firstHospitalsStack)
        {
            Grandmother granny = grandmotherQueue.Dequeue();
            Stack <Hospital> secondHospitalsStack = new Stack<Hospital>();
            double numberEligibleDiseases = 0;

            if (granny.illnesses.Length == 0)
            {
                for (int i = 0; i < (firstHospitalsStack.Count + secondHospitalsStack.Count); i++)
                {
                    Hospital hospital = firstHospitalsStack.Pop(); 

                    if (hospital.patientsToday < hospital.patientsTotal)
                    {
                        hospital.patientsToday++;
                        firstHospitalsStack.Push(hospital);

                        foreach (Hospital unsuitableHospitals in secondHospitalsStack)
                        {
                            firstHospitalsStack.Push(unsuitableHospitals);
                        }

                        return true;
                    }

                    secondHospitalsStack.Push(hospital);
                }
            }
            else
            {
                for (int i = 0; i < (firstHospitalsStack.Count + secondHospitalsStack.Count); i++)
                {
                    Hospital hospital = firstHospitalsStack.Pop();

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
                            firstHospitalsStack.Push(hospital);

                            foreach (Hospital unsuitableHospitals in secondHospitalsStack)
                            {
                                firstHospitalsStack.Push(unsuitableHospitals);
                            }

                            return true;                 
                        }
                    }

                    secondHospitalsStack.Push(hospital);
                }
            }

            foreach (Hospital unsuitableHospitals in secondHospitalsStack)
            {
                firstHospitalsStack.Push(unsuitableHospitals);
            }
            return false;
        }

        /// <summary>
        /// Метод, который выводит больницы и бабуль таблицей на экран.
        /// </summary>
        /// <param name="hospitalsStack"> Стек, содержащий больницы. </param>
        /// <param name="grandmothersList"> Список, содержащий бабуль. </param>
        static void DisplaysHospitalsAndGrandmothersData(Stack<Hospital> hospitalsStack, List<Grandmother> grandmothersList)
        {
            Console.WriteLine("{0, 66}", "СПИСОК БОЛЬНИЦ\n");
            Console.WriteLine("{0, 15} {1, 36} {2, 30} {3, 25}\n", "Название", "Список болезней", "Пациентов сейчас", "Пациентов максимум");

            Stack<Hospital> hospitals = new Stack<Hospital>(hospitalsStack);

            for (int i = 0; i < hospitalsStack.Count; i++)
            {
                Hospital hospital = hospitals.Pop();
                string illnesses = "";

                for (int j = 0; j < hospital.illnesses.Length; j++)
                {
                    illnesses += hospital.illnesses[j] + " ";
                }

                Console.WriteLine("{0, 15} {1, 37} {2, 29} {3, 25}", hospital.name, illnesses, hospital.patientsToday, hospital.patientsTotal);
            }

            Console.WriteLine();

            Console.WriteLine("{0, 66}", "СПИСОК БАБУЛЬ\n");
            Console.WriteLine("{0, 15} {1, 36} {2, 30} {3, 25}\n", "Имя", "Список болезней", "Список лекарств", "Возраст");

            for (int i = 0; i < grandmothersList.Count; i++)
            {
                Grandmother granny = grandmothersList[i];
                string illnesses = "";
                string medicines = "";

                for (int j = 0; j < granny.illnesses.Length; j++)
                {
                    illnesses += granny.illnesses[j] + " ";
                }

                for (int j = 0; j < granny.medicines.Length; j++)
                {
                    medicines += granny.medicines[j] + " ";
                }

                Console.WriteLine("{0, 15} {1, 37} {2, 30} {3, 24}", granny.name, illnesses, medicines, granny.age);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Структура, содержащая данные о графе (вершины графа, текущая вершина обхода, предыдущая вершина обхода, текущий путь обхода, пути обхода графа), 
        /// метод, заполняющий структуру, и метод, выполняющий обход графа в глубину.
        /// </summary>
        struct Graph
        {
            public Dictionary<char, char[]> graphVerticesEdges;
            public char currentVertex;
            public string lastVertexes;
            public string curentGraphTraversalPath;
            public List<string> graphTraversalPaths;

            /// <summary>
            /// Метод, заполняющий структуру Graph.
            /// </summary>
            /// <param name="graph"> Словарь, содержащий ключ - вершину, значение - вершины, с которыми она соеденина. </param>
            public void FillingGraphData(Dictionary<char, char[]> graph)
            {
                graphVerticesEdges = graph;
                currentVertex = graph.ElementAt(0).Key;
                lastVertexes = "";
                curentGraphTraversalPath = graph.ElementAt(0).Key.ToString();
                graphTraversalPaths = new List<string>();
            }

            /// <summary>
            /// Метод, выполняющий обход графа в глубину.
            /// </summary>
            public void DepthFirstGraphTraversal()
            {
                if (graphVerticesEdges[currentVertex].Length == 1)
                {
                    graphTraversalPaths.Add(curentGraphTraversalPath);
                    currentVertex = curentGraphTraversalPath[curentGraphTraversalPath.Length - 2];
                }
                else
                {                 
                    foreach (char nextVertix in graphVerticesEdges[currentVertex])
                    {
                        bool result = true;
                        foreach (char lastVertex in curentGraphTraversalPath)
                        {
                            if (nextVertix == lastVertex)
                            {
                                result = false;
                                break;
                            }
                        }
                        if (result)
                        {
                            curentGraphTraversalPath += nextVertix;
                            currentVertex = nextVertix;
                            DepthFirstGraphTraversal();
                        }
                    }
                }
                curentGraphTraversalPath = curentGraphTraversalPath.Remove(curentGraphTraversalPath.Length - 1);
            }
        }

        static void Main(string[] links)
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("{0, 73}", "РЕШЕНИЕ ЗАДАЧ. МЕНЮ ЗАДАНИЙ\n");
                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1. Программа создает List с картинками, перемешивает и выводит на экран их индексы             -   цифра 1\n" +
                                  "Задание №2. Программа создает словарь студентов и реализует различные действия с этим словарем          -   цифра 2\n" +
                                  "Задание №3. Программа получает бабулек и распределяет их по больницам                                   -   цифра 3\n" +
                                  "Задание №4. Программа получает граф, обходит его в глубину и выводит кратчайший путь                    -   цифра 4\n" +
                                  "Закончить выполнение заданий и выйти из программы                                                       -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        // Задание №1. Программа создает List с картинками, перемешивает и выводит на экран их индексы.
                        Console.Clear();
                        Console.WriteLine("{0, 106}", "ЗАДАНИЕ №1. ПРОГРАММА СОЗДАЕТ LIST С КАРТИНКАМИ, ПЕРЕМЕШИВАЕТ И ВЫВОДИТ НА ЭКРАН ИХ ИНДЕКСЫ\n");

                        List<Image> imagesList = new List<Image>(64);
                        List<int> imagesIndex = new List<int>(64);

                        for (int i = 0; i < 64; i++)
                        {
                            string link = "ProgramFiles/image" + i.ToString() + ".jpg";
                            imagesList.Add(Image.FromFile(link));
                        }

                        Console.WriteLine("Были номера: ");

                        for (int i = 0; i < 32; i++)
                        {
                            imagesIndex.AddRange(new[] { i, i });
                            Console.Write(i.ToString() + " " + i.ToString() + " ");
                        }

                        Console.WriteLine("\n\nСтали номера: ");

                        ShufflingCollections(imagesList, imagesIndex);

                        foreach (int index in imagesIndex)
                        {
                            Console.Write(index.ToString() + " ");
                        }

                        Console.Write("\n\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                        Console.ReadKey();
                        Console.Clear();
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
                                string[] studentData = studentDataArray[i].Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);
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
                                                      "Чтобы добавить нового студента в список, введите                            Новый студент\n" +
                                                      "Чтобы удалить студента из списка, введите                                   Удалить\n" +
                                                      "Чтобы отсортировать студентов по баллам экзамента, введите                  Сортировать\n" +
                                                      "Чтобы закончить работу со списком, введите                                  Закончить\n");

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

                                                Console.WriteLine("\nВЫ ДОБАВИЛИ НОВОГО СТУДЕНТА!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nВы ввели некорректные данные. Повторите попытку!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку ");
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
                                                Console.WriteLine("\nВЫ УДАЛИЛИ СТУДЕНТА!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого студента в списке нет. Повторите попытку!");
                                                Console.Write("Чтобы продолжить нажмите на любую кнопку ");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            break;

                                        case "СОРТИРОВАТЬ":
                                            studentsDictionary = studentsDictionary.OrderBy(data => data.Value.examScores).ToDictionary(data => data.Key, data => data.Value);
                                            Console.Clear();
                                            break;

                                        case "ЗАКОНЧИТЬ":
                                            Console.Clear();
                                            actionsStudentsDictionaryEnd = true;
                                            break;

                                        default:
                                            Console.Clear();
                                            Console.WriteLine("{0, 97}", "ТАКОЕ ДЕЙСТВИЕ СО СПИСКОМ СТУДЕНТОВ ВЫПОЛНИТЬ НЕЛЬЗЯ. ПОВТОРИТЕ ПОПЫТКУ!\n");
                                            break;
                                    }
                                } while (!actionsStudentsDictionaryEnd);
                            }
                            else
                            {
                                Console.WriteLine("В файле находятся некорректные данные!");
                                Console.Write("\nЧтобы закончить выполнение упражнения, нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
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
                        Stack<Hospital> hospitalStack = new Stack<Hospital>();
                        List<Grandmother> grandmothersList = new List<Grandmother>();
                        bool grandmotherHospitalTaskEnd = false;
                        bool distributionResult;

                        Hospital firstHospital = new Hospital();
                        firstHospital.name = "Северная";
                        firstHospital.illnesses = new string[] { "ангина", "простуда", "грипп", "спина" };
                        firstHospital.patientsToday = 0;
                        firstHospital.patientsTotal = 2;
                        hospitalStack.Push(firstHospital);

                        Hospital secondHospital = new Hospital();
                        secondHospital.name = "Южная";
                        secondHospital.illnesses = new string[] { "нога", "простуда", "горло", "голова" };
                        secondHospital.patientsToday = 0;
                        secondHospital.patientsTotal = 5;
                        hospitalStack.Push(secondHospital);

                        Hospital thirdHospital = new Hospital();
                        thirdHospital.name = "Центральная";
                        thirdHospital.illnesses = new string[] { "шея", "голова", "ангина", "грипп" };
                        thirdHospital.patientsToday = 0;
                        thirdHospital.patientsTotal = 3;
                        hospitalStack.Push(thirdHospital);

                        do
                        {
                            DisplaysHospitalsAndGrandmothersData(hospitalStack, grandmothersList);

                            Grandmother grandmother = new Grandmother();
                            string name;
                            string[] illnesses, medicines;
                            int birthdayYear;
                            bool fillingResult;

                            Console.Write("Введите имя бабули: ");
                            name = Console.ReadLine();
                            Console.Write("Введите год рождения бабули: ");
                            fillingResult = int.TryParse(Console.ReadLine(), out birthdayYear);
                            Console.Write("Введите болезни бабули через пробел: ");
                            illnesses = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);
                            Console.Write("Введите лекарства бабули через пробел: ");
                            medicines = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries);

                            if (fillingResult)
                            {
                                grandmother.FillingsGrandMotherData(name, birthdayYear, illnesses, medicines);
                                grandmothersQueue.Enqueue(grandmother);
                                
                                distributionResult = DistributionGrandmothersToHospitals(grandmothersQueue, hospitalStack);

                                if (distributionResult)
                                {
                                    grandmothersList.Add(grandmother);

                                    Console.Clear();
                                    DisplaysHospitalsAndGrandmothersData(hospitalStack, grandmothersList);

                                    Console.WriteLine("\nБАБУЛЯ ПОПАЛА В БОЛЬНИЦУ!\n");
                                    Console.Write("Чтобы закончить выполнение задания, введите ЗАКОНЧИТЬ. Чтобы продолжить выполнение задания, нажмите Enter: ");

                                    if (Console.ReadLine().ToLower() == "закончить")
                                    {
                                        grandmotherHospitalTaskEnd = true;
                                    }

                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("\nБАБУЛЯ НЕ ПОПАЛА В БОЛЬНИЦУ. ОНА ПЛАЧЕТ НА УЛИЦЕ(\n");
                                    Console.WriteLine("Чтобы закончить выполнение задания, введите ЗАКОНЧИТЬ. Чтобы продолжить выполнение задания, нажмите Ente: ");

                                    if (Console.ReadLine().ToLower() == "закончить")
                                    {
                                        grandmotherHospitalTaskEnd = true;
                                    }

                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nВы ввели некорректные данные. Повторите попытку!");
                                Console.Write("Чтобы продолжить нажмите на любую кнопку ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        } while (!grandmotherHospitalTaskEnd);
                        break;

                    case "4":
                        // Задание №4. Программа получает граф, обходит его в глубину и выводит кратчайший путь.
                        Console.Clear();
                        Console.WriteLine("{0, 103}", "ЗАДАНИЕ №4. ПРОГРАММА ПОЛУЧАЕТ ГРАФ, ОБХОДИТ ЕГО В ГЛУБИНУ И ВЫВОДИТ КРАТЧАЙШИЙ ПУТЬ\n");

                        Graph graph = new Graph();
                        string minGraphPath;

                        Dictionary<char, char[]> graphVerticesEdges = new Dictionary<char, char[]>()
                        {
                            {'A', new char[] { 'B', 'C' } },
                            {'B', new char[] { 'A', 'D' } },
                            {'C', new char[] { 'A', 'E', 'F' } },
                            {'D', new char[] { 'B', 'G', 'H' } },
                            {'E', new char[] { 'C', 'I', 'J' } },
                            {'F', new char[] { 'C' } },
                            {'G', new char[] { 'D' } },
                            {'H', new char[] { 'D' } },
                            {'I', new char[] { 'E' } },
                            {'J', new char[] { 'E' } },
                        };

                        graph.FillingGraphData(graphVerticesEdges);
                        graph.DepthFirstGraphTraversal();

                        minGraphPath = graph.graphTraversalPaths[0];

                        for (int i = 0; i < graph.graphTraversalPaths.Count; i++)
                        {
                            if (minGraphPath.Length > graph.graphTraversalPaths[i].Length)
                            {
                                minGraphPath = graph.graphTraversalPaths[i];
                            }
                        }

                        Console.WriteLine($"Минимальный путь в глубину по графу - {minGraphPath}");

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

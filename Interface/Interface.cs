using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLogNameSpace;
using DVDNameSpace;
using FileLogNameSpace;
using FlashNameSpace;
using HDDNameSpace;
using ILogNameSpace;
using ISerializeNameSpace;
using PriceListNameSpace;
using SomeInfoGeneratorNameSpace;
using StorageNameSpace;

namespace InterfaceNameSpace
{
    //                      Список носителей информации
    //  Разработать приложение, которое формирует список носителей информации,
    //таких как, Flash-память, DVD-диск, съемный HDD.Каждый носитель информации
    //является объектом соответствующего класса: 
    //  • класс Flash - память; 
    //  • класс DVD - диск; 
    //  • класс съемный HDD.
    //  Все три класса являются производными от абстрактного класса «Носитель
    //информации». 
    //  В базовом классе хранится имя производителя, модель, 
    //ёмкость носителя, количество.Класс обладает всеми необходимыми свойствами для
    //доступа к полям, а также виртуальными методами формирования отчёта, загрузки
    //данных и сохранения данных.В производных классах переопределяются методы
    //формирования отчёта.Кроме того, каждый из производных
    //классов дополняется следующими полями: 
    //  • класс Flash-память: скорость USB; 
    //  • класс съемный HDD: скорость вращения шпинделя; 
    //  • класс DVD - диск: скорость записи.
    //  Работа с объектами соответствующих классов производится через ссылки на
    //базовый класс, которые хранятся в обобщённой коллекции List. 
    //Приложение должно предоставлять следующие возможности: 
    //  • добавление носителя информации в список; 
    //  • удаление носителя информации из списка по заданному критерию; 
    //  • печать списка; 
    //  • изменение определённых параметров носителя информации; 
    //  • поиск носителя информации по заданному критерию; 
    //  • считывание данных из файла и запись данных в файл.
    //  Важно понимать следующее.Класс носителя информации и его наследники не
    //должны зависеть от способа печати.Поэтому печать происходит через метод ReportOutput
    //интерфейса ILog.Способ печати определяется клиентским кодом, который создаёт
    //объект одного из классов ConsoleLog, FileLog.Класс PriceList, который хранит список
    //носителей информации, не должен зависеть от способа сохранения и загрузки
    //данных.Поэтому загрузка и сохранение происходит через методы Save и Load
    //интерфейса ISerialize. Способ загрузки и сохранения определяется клиентским
    //кодом, который создаёт объект одного из классов BinarySerialize, JSONSerialize,
    //XMLSerialize.
    //  Все классы и интерфейсы следует разместить в DLL-модулях (Class Library)

    // Сборка мусора. Модель явной очистки ресурсов.-20221104_190002-Запись собрания 01:53:50 2,16,30

    // Классы:
    // Базовый класс носитель информации. // Storage
    // 3 производных класса: // Flash, HDD, DVD
    // Класс PriceList (хранит список носителей - list, загрузка/сохранение(серриализация)). // PriceList 
    // Интерфейс ILog. // ILog
    // 2 реализации интерфейса ILog: // класс ConsoleLog, класс FileLog
    // Интерфейс ISerialize. // ISerialize
    // 3 реализации интерфейса ISerialize: // класс BinarySerialize, класс JSONSerialize, класс XMLSerialize
    // Клиентский класс Interface (работа с меню, общение с клиентом). // Interface
    // Все классы кроме Interface должны быть в отдельных DLL-модулях (Class Library)
    // *********************************************************************************************************************

    // Организующий класс. Все обьекты создаються в нем и отправляються по назначению.
    internal class Interface
    {
        // Поля.
        private PriceList priceList;
        //private ILog log;
        //private ISerialize serialize;

        // Конструктор.
        public Interface()
        {
            priceList = new PriceList();
            //log = null;
            //serialize = null;
        }

        // Метод генерации носителей информации в список.
        private void Generate(int amount)
        {
            SomeInfoGenerator someInfoGenerator = new SomeInfoGenerator();
            Random random = new Random();
            int selector = -1;
            do
            {
                // Генерируем носители информации, заполняем случайными данными и добавляем их в список.
                selector = random.Next(0, 3);
                switch (selector)
                {
                    case 0:
                        DVD dvd = new DVD();
                        someInfoGenerator.FillUpDVD(ref dvd);
                        priceList.Add(dvd);
                        break;
                    case 1:
                        Flash flash = new Flash();
                        someInfoGenerator.FillUpFlash(ref flash);
                        priceList.Add(flash);
                        break;
                    case 2:
                        HDD hdd = new HDD();
                        someInfoGenerator.FillUpHDD(ref hdd);
                        priceList.Add(hdd);
                        break;
                }
                amount--;
            } while (amount > 0);
        }

        // Главное меню программы.
        public void MainMenu()
        {
            Console.Clear();
            // Пункты главного меню.
            MainMenuItems();
            string answer;
            answer = Console.ReadLine();
            switch (answer)
            {
                case "1": // 1. Добавить носитель информации.
                    {
                        Console.Clear();
                        // Пункты меню добавления носителя информации.
                        Submenu_1_Item();
                        // Переменная для хранения выбранного пункта меню в подменю.
                        string answer2;
                        answer2 = Console.ReadLine();
                        switch (answer2)
                        {
                            case "1": // 1. Flash - память.
                                {
                                    Console.Clear();
                                    // Переменные для хранения данных.
                                    string manufacturer = "";
                                    string model = "";
                                    int capacity = 0;
                                    int quantity = 0;
                                    double speed = 0.0;
                                    // Ввод данных.
                                    try
                                    {
                                        Console.WriteLine("Введите производителя: ");
                                        manufacturer = Console.ReadLine();
                                        Console.WriteLine("Введите модель: ");
                                        model = Console.ReadLine();
                                        Console.WriteLine("Введите объем памяти: ");
                                        capacity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите количество: ");
                                        quantity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите скорость чтения/записи флеш-накопителя в Мбит/с.: ");
                                        speed = Convert.ToDouble(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Упс! Что-то пошло не так. Попробуйте еще раз.");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        MainMenu();
                                    }
                                    // Создание объекта класса Flash.
                                    Storage flash = new Flash(manufacturer, model, capacity, quantity, speed);
                                    // Добавление объекта в список.
                                    priceList.Add(flash);
                                    // Вывод сообщения об успешном добавлении.
                                    Console.WriteLine("Носитель информации успешно добавлен.");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                            case "2": // 2. HDD - жесткий диск.
                                {
                                    Console.Clear();
                                    // Переменные для хранения данных.
                                    string manufacturer = "";
                                    string model = "";
                                    int capacity = 0;
                                    int quantity = 0;
                                    double spindleSpeed = 0.0;
                                    // Ввод данных.
                                    try
                                    {
                                        Console.WriteLine("Введите производителя: ");
                                        manufacturer = Console.ReadLine();
                                        Console.WriteLine("Введите модель: ");
                                        model = Console.ReadLine();
                                        Console.WriteLine("Введите объем памяти: ");
                                        capacity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите количество: ");
                                        quantity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите скорость вращения шпинделя жесткого диска в об/мин.: ");
                                        spindleSpeed = Convert.ToDouble(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Упс! Что-то пошло не так. Попробуйте еще раз.");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        MainMenu();
                                        //return; todo:а нужно ли ?
                                    }
                                    // Создание объекта класса HDD.
                                    Storage hdd = new HDD(manufacturer, model, capacity, quantity, spindleSpeed);
                                    // Добавление объекта в список.
                                    priceList.Add(hdd);
                                    // Вывод сообщения об успешном добавлении.
                                    Console.WriteLine("Носитель информации успешно добавлен.");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                            case "3": // 3. DVD - дисковод.
                                {
                                    Console.Clear();
                                    // Переменные для хранения данных.
                                    string manufacturer = "";
                                    string model = "";
                                    int capacity = 0;
                                    int quantity = 0;
                                    double writeSpeed = 0.0;
                                    // Ввод данных.
                                    try
                                    {
                                        Console.WriteLine("Введите производителя: ");
                                        manufacturer = Console.ReadLine();
                                        Console.WriteLine("Введите модель: ");
                                        model = Console.ReadLine();
                                        Console.WriteLine("Введите объем памяти: ");
                                        capacity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите количество: ");
                                        quantity = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Введите скорость записи DVD-дисков в Мбит/с: ");
                                        writeSpeed = Convert.ToDouble(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                        Console.WriteLine("Упс! Что-то пошло не так. Попробуйте еще раз.");
                                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        MainMenu();
                                    }
                                    // Создание объекта класса DVD.
                                    Storage dvd = new DVD(manufacturer, model, capacity, quantity, writeSpeed);
                                    // Добавление объекта в список.
                                    priceList.Add(dvd);
                                    // Вывод сообщения об успешном добавлении.
                                    Console.WriteLine("Носитель информации успешно добавлен.");
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                            case "4": // 4. Назад.
                                {
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                        }
                        break;
                    }
                case "2": // 2. Удалить носитель информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "3": // 3. Редактировать носитель информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "4": // 4. Загрузить список носителей информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "5": // 5. Поиск носителей информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "6": // 6. Вывод списка носителей информации...
                    {
                        Console.Clear();
                        // Пункты меню добавления носителя информации.
                        Submenu_6_Item();
                        // Переменная для хранения выбранного пункта меню в подменю.
                        string answer3 = default;
                        try
                        {
                            answer3 = Console.ReadLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Упс! Что-то пошло не так. Попробуйте еще раз.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu();
                        }
                        switch (answer3)
                        {
                            case "1": // 1. Вывод списка носителей информации в консоль.
                                {
                                    Console.Clear();
                                    // Вывод списка носителей информации в консоль.
                                    ConsoleLog consoleLog = new ConsoleLog();
                                    priceList.ReportOutput(consoleLog);
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                            case "2": // 2. Вывод списка носителей информации с помощью BinarySerialize в файл.
                                {
                                    Console.Clear();
                                    // Вывод списка носителей информации с помощью BinarySerialize в файл.
                                    FileLog fileLog = new FileLog();
                                    priceList.ReportOutput(fileLog);
                                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    // Возврат в главное меню.
                                    MainMenu();
                                    break;
                                }
                        }
                        break;

                    }
                case "7": // 7. Сгенерировать носителей информации.
                    {
                        Console.Clear();
                        Console.WriteLine("Какое количество носителей информации вы хотите сгенерировать? ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        Generate(count);
                        Console.WriteLine("В список добавлено {0} носителей информации.", count);
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                        MainMenu();
                        break;
                    }
                case "8": // 8. Выход.
                    {
                        Console.Clear();
                        Console.WriteLine("Выход из программы.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный пункт меню");
                        MainMenu();
                        break;
                    }
            }
        }

        // Подменю пункта №1 главного меню. Пункты меню добавления носителя информации.
        private static void Submenu_1_Item()
        {
            Console.WriteLine("1. Flash - память");
            Console.WriteLine("2. HDD - жесткий диск");
            Console.WriteLine("3. DVD - диск");
            Console.WriteLine("4. Назад");
            Console.WriteLine("Введите номер пункта меню: ");
        }

        // Пункты меню добавления носителя информации.
        private static void Submenu_6_Item()
        {
            Console.WriteLine("1. Вывести список носителей информации в консоль.");
            Console.WriteLine("2. Вывести список носителей информации в файл.");
            Console.WriteLine("3. Назад");
            Console.WriteLine("Введите номер пункта меню: ");
        }

        // Пункты главного меню.
        private static void MainMenuItems()
        {
            Console.WriteLine("1. Добавить носитель информации...");
            Console.WriteLine("2. Удалить носитель информации");
            Console.WriteLine("3. Редактировать носитель информации");
            Console.WriteLine("4. Загрузить список носителей информации");
            Console.WriteLine("5. Поиск носителей информации");
            Console.WriteLine("6. Вывод списка носителей информации...");
            Console.WriteLine("7. Сгенерировать носителей информации");
            Console.WriteLine("8. Выход");
            Console.WriteLine("Выберите пункт меню:");
        }
    }
}

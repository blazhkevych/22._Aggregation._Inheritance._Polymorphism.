using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashNameSpace;
using StorageNameSpace;

namespace Interface
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
    //должны зависеть от способа печати.Поэтому печать происходит через метод Print
    //интерфейса ILog.Способ печати определяется клиентским кодом, который создаёт
    //объект одного из классов ConsoleLog, FileLog.Класс PriceList, который хранит список
    //носителей информации, не должен зависеть от способа сохранения и загрузки
    //данных.Поэтому загрузка и сохранение происходит через методы Save и Load
    //интерфейса ISerialize. Способ загрузки и сохранения определяется клиентским
    //кодом, который создаёт объект одного из классов BinarySerialize, JSONSerialize,
    //XMLSerialize.
    //  Все классы и интерфейсы следует разместить в DLL-модулях (Class Library)

    // Сборка мусора. Модель явной очистки ресурсов.-20221104_190002-Запись собрания 01:53:50 2,16,17

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
        // Главное меню программы.
        public void MainMenu()
        {
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
                        Console.WriteLine("1. Flash - память.");
                        Console.WriteLine("2. HDD - жесткий диск.");
                        Console.WriteLine("3. DVD - диск.");
                        Console.WriteLine("4. Назад.");
                        Console.WriteLine("Введите номер пункта меню: ");

                        // Переменная для хранения выбранного пункта меню.
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
                                        Console.WriteLine("Введите скорость: ");
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
                                        //return; todo:а нужно ли ?
                                    }

                                    // Создание объекта класса Flash.
                                    Storage flash = new Flash(manufacturer, model, capacity, quantity, speed);

                                    // Добавление объекта в список.
                                    //PriceList.Add(flash);

                                    // Вывод сообщения об успешном добавлении.
                                    Console.WriteLine("Носитель информации успешно добавлен.");
                                    Console.ReadKey();
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
                case "4": // 4. Сохранить список носителей информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "5": // 5. Загрузить список носителей информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "6": // 6. Печать списка носителей информации.
                    {
                        Console.Clear();

                        break;
                    }
                case "7": // 7. Выход.
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

        // Пункты главного меню.
        private static void MainMenuItems()
        {
            Console.WriteLine("1. Добавить носитель информации.");
            Console.WriteLine("2. Удалить носитель информации.");
            Console.WriteLine("3. Редактировать носитель информации.");
            Console.WriteLine("4. Сохранить список носителей информации.");
            Console.WriteLine("5. Загрузить список носителей информации.");
            Console.WriteLine("6. Печать списка носителей информации.");
            Console.WriteLine("7. Выход.");
            Console.WriteLine("Выберите пункт меню:");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!\nПожалуйста, введите путь до файла (расширение .xlsx),\n" +
                "например C:\\Users\\...\\list.xlsx: ");
            string fileName = Console.ReadLine();
            while (!fileName.EndsWith(".xlsx"))
            {
                Console.WriteLine("Неверный формат! Попробуйте еще!");
                fileName = Console.ReadLine();
            }

            //string fileName = @"C:\Users\ACER\Downloads\list.xlsx";
            Reader reader = new Reader(fileName);
            Writer writer = new Writer(fileName);

            Store store = new Store();
            reader.Read(Store.RequisitionWorkSheet, store, new Requisition());
            reader.Read(Store.ClientWorkSheet, store, new Client());
            reader.Read(Store.ProductSheet, store, new Product());


            while(true)
            {
                Console.WriteLine("\n\n(Для выхода введите Exit)");
                Console.WriteLine("Выберите команду: ");
                Console.WriteLine("1. Вывод данных о товаре (введите 1). ");
                Console.WriteLine("2. Изменение контактного лица (введите 2).");
                Console.WriteLine("3. Определить золотого клиента (введите 3).");

                string str = Console.ReadLine();
                if(str == "Exit")
                {
                    break;
                }
                if (str == "1") ProductInfo(store); //сценарий 1 задания 
                if (str == "2") ChangeClientInfo(store, writer); //сценарий 2-го
                if (str == "3") GetBestClient(store); //сценарий 3-го
            }

            Console.ReadKey();
        }
        public static void ProductInfo(Store store)
        {
            Console.Clear();
            Console.WriteLine("Введите номер товара: ");
            List<Product> products = store.GetProducts();
            // Вывод списка продутов для выбора одного из них. 
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + " (введите " + (i) + "). ");
            }

            string str = Console.ReadLine();
            // Проверка введенных данных на корректность. 
            int index;
            if(ErrorHandler.IsNumber(str))
            {
                index = Convert.ToInt32(str);
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
                return;
            }

            if(!ErrorHandler.IndexInRange(index, products.Count))
            {
                Console.WriteLine("Такого номера нет!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Вы выбрали: " + products[index].Name);


            //Вывод результата
            List<string> values = StoreAnalyze.ProductInfoAnalyze(store, products[index]);

            string spliter = "---------------------------------------------------";
            Console.WriteLine(spliter);
            if (values.Count == 0) Console.WriteLine("Данный товар не был продан. ");
            foreach(var value in values)
            {
                if(value == "") Console.WriteLine(spliter);
                else Console.WriteLine(value);
            }
            Console.WriteLine(spliter);

        }
        public static void ChangeClientInfo(Store store, Writer writer)
        {
            Console.Clear();
            Console.WriteLine("Введите номер организации: ");
            List<Client> clients = store.GetClients();
            for (int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine(clients[i].Company + " (введите " + (i) + "). ");
            }

            string str = Console.ReadLine();
            int index;
            // Проверка данных на корректность. 
            if (ErrorHandler.IsNumber(str))
            {
                index = Convert.ToInt32(str);
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
                return;
            }

            if (!ErrorHandler.IndexInRange(index, clients.Count))
            {
                Console.WriteLine("Такого номера нет!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Вы выбрали: " + clients[index].Company);
            Console.WriteLine("Введите новые ФИО: ");

            string contacts = Console.ReadLine();

            string result = writer.Write(index + 2, contacts);
            Console.WriteLine("Новое записанное значение: " + result);
        }
        public static void GetBestClient(Store store)
        {
            Console.Clear();
            Console.WriteLine("Укажите срок: ");
            Console.WriteLine("За месяц (введите 1). ");
            Console.WriteLine("За год (введите 2). ");

            string str = Console.ReadLine();

            if(str == "1")
            {
                Console.WriteLine("Введите номер месяца: ");
                string month = Console.ReadLine();
                if(ErrorHandler.IsNumber(month) && ErrorHandler.MonthCorrect(Convert.ToInt32(month)))
                {
                    Console.WriteLine("Введите номер года: ");
                    string year = Console.ReadLine();
                    if(ErrorHandler.IsNumber(year) && ErrorHandler.YearCorrect(Convert.ToInt32(year)))
                    {
                        string client = StoreAnalyze.BestClient(store, Convert.ToInt32(year), Convert.ToInt32(month));
                        Console.WriteLine("Золотой клиент " + client);
                    }
                    else
                    {
                        Console.WriteLine("Вы указали неверный год!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не корректное значение!");
                    return;
                }
            }
            else if(str == "2") {
                Console.WriteLine("Введите номер года: ");
                string year = Console.ReadLine();
                if (ErrorHandler.IsNumber(year) && ErrorHandler.YearCorrect(Convert.ToInt32(year)))
                {
                    string client = StoreAnalyze.BestClient(store, Convert.ToInt32(year));
                    Console.WriteLine("Золотой клиент " + client);
                }
                else
                {
                    Console.WriteLine("Вы указали неверный год!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Такого номера в списке нет!");
            }

        }
        
    }
}

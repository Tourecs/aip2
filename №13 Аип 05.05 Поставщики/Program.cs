using System;
using System.Collections.Generic;

namespace SimpleInventory
{
    class Product
    {
        public int Id;
        public string Name;

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Supplier
    {
        public int Id;
        public string Name;
        public string Phone;

        public Supplier(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
    }

    class Transaction
    {
        public int ProductId;
        public int SupplierId;
        public string Date;
        public int Count;
        public int Price;

        public Transaction(int productId, int supplierId, string date, int count, int price)
        {
            ProductId = productId;
            SupplierId = supplierId;
            Date = date;
            Count = count;
            Price = price;
        }
    }

    class Program
    {
        static List<Product> products = new List<Product>();
        static List<Supplier> suppliers = new List<Supplier>();
        static List<Transaction> transactions = new List<Transaction>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить продукт");
                Console.WriteLine("2. Добавить поставщика");
                Console.WriteLine("3. Добавить транзакцию");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        AddSupplier();
                        break;
                    case "3":
                        AddTransaction();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Введите название продукта: ");
            string name = Console.ReadLine();
            int id = products.Count;
            products.Add(new Product(id, name));
            Console.WriteLine("Продукт добавлен. Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void AddSupplier()
        {
            Console.Write("Введите имя поставщика: ");
            string name = Console.ReadLine();
            Console.Write("Введите телефон поставщика: ");
            string phone = Console.ReadLine();
            int id = suppliers.Count;
            suppliers.Add(new Supplier(id, name, phone));
            Console.WriteLine("Поставщик добавлен. Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void AddTransaction()
        {
            Console.Write("Введите ID продукта: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Введите ID поставщика: ");
            int supplierId = int.Parse(Console.ReadLine());
            Console.Write("Введите дату (YYYY-MM-DD): ");
            string date = Console.ReadLine();
            Console.Write("Введите количество: ");
            int count = int.Parse(Console.ReadLine());
            Console.Write("Введите цену: ");
            int price = int.Parse(Console.ReadLine());

            transactions.Add(new Transaction(productId, supplierId, date, count, price));
            Console.WriteLine("Транзакция добавлена. Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}

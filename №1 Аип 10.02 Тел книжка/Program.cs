using System;
using System.Collections.Generic;

namespace aip
{
     public class User
    {
        public int Id;
        public string Name;
        public List<Phone> Phones;
        public User(int id, string name)
        {
            Id = id;
            Name = name;
            Phones = new List<Phone>();
        }

        public void AddPhone(Phone phone)
        {
            Phones.Add(phone);
        }

         public string GetInfo()
        {
            string info = $"- Имя: {Name}, ID: {Id}, Номера:\n";
            foreach (var phone in Phones)
            {
                info += phone.GetInfo() + "\n";
            }
            return info;
        }
    }

    public class Phone
    {
        public string Number;
        public string Operator;
        public string City;
        public string Year;
        public Phone(string number, string operatorName, string city, string year)
        {
            Number = number;
            Operator = operatorName;
            City = city;
            Year = year;
        }
        public string GetInfo()
        {
            return $"-- Номер: {Number}, Оператор: {Operator}, Город: {City}, Год: {Year}";
        }
    }
    public class Menu
    {
        private Logic logic;
        public Menu(Logic logic)
        {
            this.logic = logic;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать абонента");
                Console.WriteLine("2. Поиск");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    logic.CreateUser();
                }
                else if (input == "2")
                {
                    SelectUser();
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    ShowError();
                }
            }
        }
        private void SelectUser()
        {
            while (true)
            {
                Console.WriteLine("Поиск:");
                Console.WriteLine("1. Все пользователи");
                Console.WriteLine("2. По номеру");
                Console.WriteLine("3. По оператору");
                Console.WriteLine("4. По году");
                Console.WriteLine("5. По городу");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    logic.ShowAllUsers();
                }
                else if (input == "2")
                {
                    Console.Write("Введите номер телефона: ");
                    string phone = Console.ReadLine();
                    logic.FindUserByPhone(phone);
                }
                else if (input == "3")
                {
                    Console.Write("Введите оператора: ");
                    string operatorName = Console.ReadLine();
                    logic.FindUsersByOperator(operatorName);
                }
                else if (input == "4")
                {
                    Console.Write("Введите год: ");
                    string year = Console.ReadLine();
                    logic.FindUsersByYear(year);
                }
                else if (input == "5")
                {
                    Console.Write("Введите город: ");
                    string city = Console.ReadLine();
                    logic.FindUsersByCity(city);
                }
                else if (input == "6")
                {
                    break;
                }
                else
                {
                    ShowError();
                }
            }
        }
        private void ShowError()
        {
            Console.WriteLine("Ошибка. Нажмите любую клавишу");
            Console.ReadKey();
        }
    }
    public class Logic
    {
        private List<User> users = new List<User>();
        private int userId = 0;
        public void CreateUser()
        {
            Console.Clear();
            Console.Write("Введите полное имя: ");
            string name = Console.ReadLine();
            User user = new User(userId++, name);

            while (true)
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                Console.Write("Введите оператора: ");
                string operatorName = Console.ReadLine();
                Console.Write("Введите город: ");
                string city = Console.ReadLine();
                Console.Write("Введите год: ");
                string year = Console.ReadLine();

                Phone phone = new Phone(number, operatorName, city, year);
                user.AddPhone(phone);

                Console.Write("Добавить еще номер? (Да/Нет): ");
                string answer = Console.ReadLine();
                if (answer != "Да") break;
            }

            users.Add(user);
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }
        public void ShowAllUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine(user.GetInfo());
            }
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }
        public void FindUserByPhone(string phone)
        {
            foreach (var user in users)
            {
                foreach (var p in user.Phones)
                {
                    if (p.Number == phone)
                    {
                        Console.WriteLine(user.GetInfo());
                        return;
                    }
                }
            }
            Console.WriteLine("Пользователь не найден");
            Console.ReadKey();
        }
        public void FindUsersByOperator(string operatorName)
        {
            foreach (var user in users)
            {
                foreach (var p in user.Phones)
                {
                    if (p.Operator == operatorName)
                    {
                        Console.WriteLine(user.GetInfo());
                        return;
                    }
                }
            }
            Console.WriteLine("Пользователь не найден");
            Console.ReadKey();
        }
        public void FindUsersByYear(string year)
        {
            foreach (var user in users)
            {
                foreach (var p in user.Phones)
                {
                    if (p.Year == year)
                    {
                        Console.WriteLine(user.GetInfo());
                        return;
                    }
                }
            }
            Console.WriteLine("Пользователь не найден");
            Console.ReadKey();
        }
        public void FindUsersByCity(string city)
        {
            foreach (var user in users)
            {
                foreach (var p in user.Phones)
                {
                    if (p.City == city)
                    {
                        Console.WriteLine(user.GetInfo());
                        return;
                    }
                }
            }
            Console.WriteLine("Пользователь не найден");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Menu menu = new Menu(logic);
            menu.Run();
        }
    }
}
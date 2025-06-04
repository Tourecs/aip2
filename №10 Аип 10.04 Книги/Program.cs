using System;
using System.Collections.Generic;

public struct TimeInfo
{
    public string? DateTaken;
    public string? DateReturned;
}

namespace Books
{
    class Book
    {
        public int bookId;
        public string authorName;
        public string bookTitle;
        public int publishYear;
        public string publisherName;
        public List<TimeInfo> history;

        public Book(int id, string author, string title, int year, string publisher)
        {
            bookId = id;
            authorName = author;
            bookTitle = title;
            publishYear = year;
            publisherName = publisher;
            history = new List<TimeInfo>();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"---\nID: {bookId}\nАвтор: {authorName}\nНазвание: {bookTitle}\nГод: {publishYear}\nИздательство: {publisherName}\nВыдач: {history.Count}\n---");
        }

        public void AddTake(string takeDate)
        {
            history.Add(new TimeInfo() { DateTaken = takeDate });
        }

        public void AddReturn(string returnDate)
        {
            string takeDate = history[history.Count - 1].DateTaken;
            history.RemoveAt(history.Count - 1);
            history.Add(new TimeInfo() { DateTaken = takeDate, DateReturned = returnDate });
        }

        public bool IsAvailable()
        {
            if (history.Count == 0 || history[history.Count - 1].DateReturned != null)
                return true;
            return false;
        }

        public bool IsTakenNotReturned()
        {
            foreach (var record in history)
            {
                if (record.DateReturned == null)
                    return true;
            }
            return false;
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
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        logic.RegisterBook();
                        break;
                    case "2":
                        logic.IssueBook();
                        break;
                    case "3":
                        logic.ReturnBook();
                        break;
                    case "4":
                        ShowSelectors();
                        break;
                    case "5":
                        logic.ShowNotReturnedBooks();
                        break;
                    case "q":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void ShowSelectors()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                ShowSelectorMenu();
                Console.Write("Выберите пункт: ");
                string sel = Console.ReadLine();

                switch (sel)
                {
                    case "1":
                        logic.ShowAvailableBooks();
                        break;
                    case "2":
                        logic.ShowNotReturnedBooks();
                        break;
                    case "q":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void ShowMainMenu()
        {
            Console.WriteLine("-- Главное меню --");
            Console.WriteLine("1 - Зарегистрировать книгу");
            Console.WriteLine("2 - Выдать книгу");
            Console.WriteLine("3 - Вернуть книгу");
            Console.WriteLine("4 - Выбор");
            Console.WriteLine("5 - Книги не возвращены");
            Console.WriteLine("q - Выход");
            Console.Write("Ваш выбор: ");
        }

        void ShowSelectorMenu()
        {
            Console.WriteLine("-- Меню выбора --");
            Console.WriteLine("1 - Показать доступные книги");
            Console.WriteLine("2 - Показать книги, которые не вернули");
            Console.WriteLine("q - Назад");
        }
    }

    public class Logic
    {
        List<Book> bookList = new List<Book>();

        public void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("-- Регистрация книги --");

            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Год издания: ");
            int year = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Издательство: ");
            string publisher = Console.ReadLine();

            bookList.Add(new Book(bookList.Count, author, title, year, publisher));

            Console.WriteLine("Книга добавлена! Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void IssueBook()
        {
            Console.Clear();
            Console.WriteLine("-- Выдача книги --");

            Console.Write("Введите ID книги: ");
            int id = int.Parse(Console.ReadLine() ?? "-1");

            if (id < 0 || id >= bookList.Count)
            {
                Console.WriteLine("Такой книги нет!");
                Console.ReadKey();
                return;
            }

            if (!bookList[id].IsAvailable())
            {
                Console.WriteLine("Книга уже выдана!");
                Console.ReadKey();
                return;
            }

            Console.Write("Дата выдачи (например, 01.01.2024): ");
            string dateTake = Console.ReadLine();

            bookList[id].AddTake(dateTake);

            Console.WriteLine("Книга выдана! Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("-- Возврат книги --");

            Console.Write("Введите ID книги: ");
            int id = int.Parse(Console.ReadLine() ?? "-1");

            if (id < 0 || id >= bookList.Count)
            {
                Console.WriteLine("Такой книги нет!");
                Console.ReadKey();
                return;
            }

            if (bookList[id].IsAvailable())
            {
                Console.WriteLine("Книга не выдана!");
                Console.ReadKey();
                return;
            }

            Console.Write("Дата возврата (например, 05.01.2024): ");
            string dateReturn = Console.ReadLine();

            bookList[id].AddReturn(dateReturn);

            Console.WriteLine("Книга возвращена! Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void ShowAvailableBooks()
        {
            Console.Clear();
            Console.WriteLine("-- Доступные книги --");
            foreach (var book in bookList)
            {
                if (book.IsAvailable())
                {
                    book.ShowInfo();
                }
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void ShowNotReturnedBooks()
        {
            Console.Clear();
            Console.WriteLine("-- Книги не возвращены --");
            foreach (var book in bookList)
            {
                if (book.IsTakenNotReturned())
                {
                    book.ShowInfo();
                }
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Logic logic = new Logic();
            Menu menu = new Menu(logic);
            menu.Run();
        }
    }
}

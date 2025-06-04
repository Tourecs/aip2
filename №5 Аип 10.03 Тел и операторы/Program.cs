using System;
using System.Linq;

public class Phone
{
    public string PhoneNumber;

    public Phone(string phoneNumber)
    {
        if (IsValidPhoneNumber(phoneNumber))
        {
            PhoneNumber = phoneNumber;
        }
        else
        {
            throw new ArgumentException("Неверный номер телефона.");
        }
    }

    private bool IsValidPhoneNumber(string number)
    {
        // Логика проверки номера телефона
        return !string.IsNullOrWhiteSpace(number) && number.All(char.IsDigit);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Phone myPhone = new Phone("79999999999");
            Console.WriteLine($"Номер телефона: {myPhone.PhoneNumber}");
            myPhone.PhoneNumber = "abc";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}

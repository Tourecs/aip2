using System;
using System.Collections.Generic;

public class Car
{
	public string Year { get; set; }
	public string Name { get; set; }
	public string Owner { get; set; }
	public bool Clean { get; set; }

	public Car(string year, string name, string owner, bool Clean)
	{
		Year = year;
		Name = name;
		Owner = owner;
		Clean = Clean;
	}
}

public delegate void WashingEventHandler(Car car);

public class CarWash
{
	public event WashingEventHandler Washing;

	public void WashCar(Car car)
	{
		if (car.Clean)
		{
			Console.WriteLine($"Машина {car.Name} уже чиста");
			return;
		}

		car.Clean = true;
		Console.WriteLine($"Машина {car.Name} успешно помыта");

		Washing?.Invoke(car);
	}
}
public class Garage
{
	private List<Car> cars = new List<Car>();

	public void AddCar(Car car)
	{
		cars.Add(car);
	}

	public bool ContainsCar(Car car)
	{
		return cars.Contains(car);
	}
}
class Program
{
	static void Main()
	{
		Garage garage = new Garage();
		CarWash carWash = new CarWash();

		Car car = new Car("2024", "Mazda", "3", false);
		garage.AddCar(car);

		carWash.Washing += CarWash_WashingEvent;

		if (garage.ContainsCar(car))
		{
			carWash.WashCar(car);
		}
		else
		{
			Console.WriteLine("Машина не найдена в гараже");
		}
	}

	static void CarWash_WashingEvent(Car car)
	{
		Console.WriteLine($"Машина {car.Name} прошла мойку");
	}
}

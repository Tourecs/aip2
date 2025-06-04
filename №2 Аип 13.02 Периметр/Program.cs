interface IResult
{
    double GetPerimeter();
    double GetArea();
}

class Figure
{
    public string Name { get; set; }
}

class Circle : Figure, IResult
{
    public int Radius { get; }

    public Circle(int radius)
    {
        Radius = radius;
        Name = "Circle";
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

class Square : Figure, IResult
{
    public int Side { get; }

    public Square(int side)
    {
        Side = side;
        Name = "Square";
    }

    public double GetPerimeter()
    {
        return 4 * Side;
    }

    public double GetArea()
    {
        return Math.Pow(Side, 2);
    }
}

class Triangle : Figure, IResult
{
    public int Side { get; }

    public Triangle(int side)
    {
        Side = side;
        Name = "Triangle";
    }

    public double GetPerimeter()
    {
        return 3 * Side;
    }

    public double GetArea()
    {
        return (Math.Sqrt(3) / 4) * Math.Pow(Side, 2);
    }
}

class Program
{
    static void Main()
    {
        var square = new Square(4);
        Console.WriteLine($"- {square.Name}:\nPerimeter: {square.GetPerimeter()}\nArea: {square.GetArea()}");

        var circle = new Circle(5);
        Console.WriteLine($"- {circle.Name}:\nPerimeter: {circle.GetPerimeter()}\nArea: {circle.GetArea()}");

        var triangle = new Triangle(6);
        Console.WriteLine($"- {triangle.Name}:\nPerimeter: {triangle.GetPerimeter()}\nArea: {triangle.GetArea()}");
    }
}

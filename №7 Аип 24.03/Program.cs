using System;

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string GetPosition()
        {
            return $"({X}, {Y})";
        }
    }
    public class OutOfBoundsEvent
    {
        public Point OutPoint;

        public OutOfBoundsEvent(Point outPoint)
        {
            OutPoint = outPoint;
            Console.WriteLine("Событие вызвано: точка вышла за пределы");
        }
    }

    public delegate void OutOfBoundsEventHandler(Point outPoint);

    public class Game
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;
        public int MinX, MaxX;
        public int MinY, MaxY;

        public Point CurrentPoint;
        public event OutOfBoundsEventHandler OnOutOfBounds;

        public Game(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight, Point currentPoint)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
            CurrentPoint = currentPoint;

            MinX = Math.Min(topLeft.X, Math.Min(topRight.X, Math.Min(bottomLeft.X, bottomRight.X)));
            MaxX = Math.Max(topLeft.X, Math.Max(topRight.X, Math.Max(bottomLeft.X, bottomRight.X)));
            MinY = Math.Min(topLeft.Y, Math.Min(topRight.Y, Math.Min(bottomLeft.Y, bottomRight.Y)));
            MaxY = Math.Max(topLeft.Y, Math.Max(topRight.Y, Math.Max(bottomLeft.Y, bottomRight.Y)));
        }

        private Random random = new Random();

        public bool IsPointInsideField()
        {
            return (CurrentPoint.X >= MinX && CurrentPoint.X <= MaxX && CurrentPoint.Y >= MinY && CurrentPoint.Y <= MaxY);
        }

        public void MoveRandomly()
        {
            int newX = CurrentPoint.X + random.Next(-2, 3);
            int newY = CurrentPoint.Y + random.Next(-2, 3);

            CurrentPoint.X = newX;
            CurrentPoint.Y = newY;

            if (!IsPointInsideField())
            {
                OnOutOfBounds?.Invoke(CurrentPoint);
            }

            Console.WriteLine($"Текущая позиция: {CurrentPoint.GetPosition()}");
        }
    }

    class Program
    {
        static void Main()
        {
            Point topLeft = new Point(0, 0);
            Point topRight = new Point(10, 0);
            Point bottomLeft = new Point(0, 10);
            Point bottomRight = new Point(3, 10);

            Point startPoint = new Point(5, 5);
            Game game = new Game(topLeft, topRight, bottomLeft, bottomRight, startPoint);

            game.OnOutOfBounds += (point) =>
            {
                Console.WriteLine($"Точка {point.GetPosition()} вышла за пределы поля");
            };

            for (int i = 0; i <= 10; i++)
            {
                game.MoveRandomly();
            }
        }
    }

namespace Classroom;

public class MainClass
{
    public static void Main()
    {
        Point firstPoint = new(0, 0), secondPoint = new(0, 0);
        Circle circle;
        int count = 0;

        while(count < 2)
        {
            if (count == 0)
            {
                Console.WriteLine("Введите координаты первой точки: ");
            }
            else
            {
                Console.WriteLine("Введите координаты второй точки: ");
            }

            string? input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Вы ввели пустую строку. Попробуйте еще раз.");
                continue;
            }
            string[] coordinates = input.Split(' ');
            if (coordinates.Length != 2)
            {
                Console.WriteLine("Вы ввели неверное количество координат. Попробуйте еще раз.");
                continue;
            }
            if (!double.TryParse(coordinates[0], out double x) || !double.TryParse(coordinates[1], out double y))
            {
                Console.WriteLine("Вы ввели неверные координаты. Попробуйте еще раз.");
                continue;
            }
            if (x < -200 || x > 200 || y < -150 || y > 150)
            {
                Console.WriteLine("Координаты выходят за пределы допустимых значений. Попробуйте еще раз.");
                continue;
            }

            if (count == 0)
            {
                firstPoint = new Point(x, y);
                Console.WriteLine("Первая точка успешно создана.");
            }
            else
            {
                secondPoint = new Point(x, y);
                Console.WriteLine("Вторая точка успешно создана.");

                break;
            }

            count++;
        }

        circle = new Circle(firstPoint, secondPoint);

        Console.WriteLine("Выбор сложности задачи: 1 - основная, 2 - дополнительная");
        string? choice = Console.ReadLine();
        if (choice == "1")
        {
            MainTask(circle);
        }
        else if (choice == "2")
        {
            AdditionalTask(circle);
        }
        else
        {
            Console.WriteLine("Вы ввели неверное значение. Попробуйте еще раз.");
        }
    }

    private static string CompareCircles(Circle firstCircle, Circle secondCircle)
    {
        string output = firstCircle > secondCircle ? "Первая окружность больше второй." : (firstCircle < secondCircle ? "Вторая окружность больше первой." : "Окружности равны.");
        return output;
    }

    private static void MainTask(Circle circle)
    {
        while (true)
        {
            Console.WriteLine("Введите 4 координаты для создания новой окружности: ");
            string? yetAnotherInput = Console.ReadLine();

            if (yetAnotherInput == "0 0 0 0")
            {
                break;
            }

            if (yetAnotherInput == null)
            {
                Console.WriteLine("Вы ввели пустую строку. Попробуйте еще раз.");
                continue;
            }
            string[] coordinates = yetAnotherInput.Split(' ');
            if (coordinates.Length != 4)
            {
                Console.WriteLine("Вы ввели неверное количество координат. Попробуйте еще раз.");
                continue;
            }
            if (!double.TryParse(coordinates[0], out double x1) ||
                !double.TryParse(coordinates[1], out double y1) ||
                !double.TryParse(coordinates[2], out double x2) ||
                !double.TryParse(coordinates[3], out double y2))
            {
                Console.WriteLine("Вы ввели неверные координаты. Попробуйте еще раз.");
                continue;
            }
            if (x1 < -200 || x1 > 200 || y1 < -150 || y1 > 150
                || x2 < -200 || x2 > 200 || y2 < -150 || y2 > 150)
            {
                Console.WriteLine("Координаты выходят за пределы допустимых значений. Попробуйте еще раз.");
                continue;
            }

            var yetAnotherCircle = new Circle(new Point(x1, y1), new Point(x2, y2));

            Console.WriteLine(CompareCircles(circle, yetAnotherCircle));
        }
    }

    private static void AdditionalTask(Circle circle)
    {
        string[] lines = File.ReadAllLines("input.txt");
        foreach (string line in lines)
        {
            string[] coordinates = line.Split(' ');

            if (coordinates.Length != 4)
            {
                continue;
            }
            if (!double.TryParse(coordinates[0], out double x1) ||
                !double.TryParse(coordinates[1], out double y1) ||
                !double.TryParse(coordinates[2], out double x2) ||
                !double.TryParse(coordinates[3], out double y2))
            {
                continue;
            }

            if (x1 < -200 || x1 > 200 || y1 < -150 || y1 > 150
                || x2 < -200 || x2 > 200 || y2 < -150 || y2 > 150)
            {
                continue;
            }

            var yetAnotherCircle = new Circle(new Point(x1, y1), new Point(x2, y2));

            Console.WriteLine(CompareCircles(circle, yetAnotherCircle));
        }
    }
}

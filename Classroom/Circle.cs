namespace Classroom;

public class Circle(Point firstPoint, Point secondPoint)
{
    public double Radius { get; } = Math.Sqrt(Math.Pow(secondPoint.X - firstPoint.X, 2) + Math.Pow(secondPoint.Y - firstPoint.Y, 2));
    
    public static bool operator >(Circle firstCircle, Circle secondCircle)
    {
        return firstCircle.Radius > secondCircle.Radius;
    }
    
    public static bool operator <(Circle firstCircle, Circle secondCircle)
    {
        return firstCircle.Radius < secondCircle.Radius;
    }
    
    public static bool operator ==(Circle firstCircle, Circle secondCircle)
    {
        const double epsilon = 1e-10;
        return Math.Abs(firstCircle.Radius - secondCircle.Radius) < epsilon;
    }
    
    public static bool operator !=(Circle firstCircle, Circle secondCircle)
    {
        return !(firstCircle == secondCircle);
    }
}
class Circle
{
    private double _radius;

    public Circle()
    {
        _radius = 0.0;
    }

    public Circle(double radius)
    {
        _radius = radius;
        SetRaduis(radius);
    }
   public void SetRaduis(double radius)
    {
        if (radius <= 0)
        {
            Console.WriteLine("Error");
            return;
        }
        _radius = radius;
    }
    public double GetRadius()
    {
        return _radius;
    }
    public double GetArea()
    {
        return Math.PI *_radius *_radius;
    }
}
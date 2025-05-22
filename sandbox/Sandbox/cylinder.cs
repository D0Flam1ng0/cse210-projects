
using System.Reflection.Metadata.Ecma335;

class Cylinder
{

    private Circle _circle;
    private double _height;

    public Cylinder()
    {
        _height = 0.0;
        _circle = null;
    }
    public Cylinder(Circle circle)
    {
         _height = 0.0;
        _circle = circle;
    }
    public Cylinder(double height, Circle circle)
    {
         _height = height;
        _circle = circle;
    }
    public Cylinder(double height, double radius)
    {
         _height = height;
        _circle = new Circle(radius);
    }
     public void SetHeight(double height)
    {
        _height = height;
    }

    public void SetCircle(Circle circle)
    {
        _circle = circle;
    }
    public double GetVolume()
    {
        return Math.PI * _circle.GetRadius() * _circle.GetRadius() * _height;
    }
}
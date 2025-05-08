
using System.Reflection.Metadata.Ecma335;

class Cylinder
{

    private Circle _circle;
    private double _height;
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
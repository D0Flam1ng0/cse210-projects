using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class PoliceMan : Person
{
    private string _weapons;
    private int _hoursWorked;
    private double _hourlyWage;
    public PoliceMan(string fristname, string lastname, int age, string weapons, int hours, double hourlywage)
    : base(fristname, lastname, age)
    {
        _weapons = weapons;
    }

    public string GetPoliceManInfo()
    {
        return $"Weapon: {_weapons} :: {GetPersonInfo()}";
    }
    public virtual string GetPersonInfo()
    {
        return $"Weapon: {_weapons} :: {base.GetPersonInfo()}";
    }
    public override double GetSalary()
    {
        double pay = _hoursWorked * _hourlyWage;
        if (_hoursWorked > 40)
        {
            return 40 * _hourlyWage + (_hoursWorked - 40 * _hourlyWage * 2);
        }
        return pay;
    }
}
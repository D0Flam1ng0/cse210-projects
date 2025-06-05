class PoliceMan : Person
{
    private string _weapons;
    public PoliceMan(string fristname, string lastname, int age, string weapons)
    : base(fristname, lastname, age)
    {
        _weapons = weapons;
    }

    public string GetPoliceManInfo()
    {
        return $"Weapon: {_weapons} :: {GetPersonInfo()}";
    }
}
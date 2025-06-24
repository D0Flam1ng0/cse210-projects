class Doctor : Person
{
    private string _tool;
    private double _salary;
    public Doctor(string fristname, string lastname, int age, string tool, double salary)
    : base(fristname, lastname, age)
    {
        _tool = tool;
    }

    public string GetDoctorInfo()
    {
        return $"Tool: {_tool} :: {GetPersonInfo()}";
    }
    public virtual string GetPersonInfo()
    {
        return $"Tool: {_tool} :: {base.GetPersonInfo()}";
    }
    public override double getSalary()
    {
        return _salary;
    }
}

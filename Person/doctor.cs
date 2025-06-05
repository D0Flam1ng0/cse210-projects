class Doctor : Person
{
    private string _tool;
    public Doctor(string fristname, string lastname, int age, string tool)
    : base(fristname, lastname, age)
    {
        _tool = tool;
    }

    public string GetDoctorInfo()
    {
        return $"Tool: {_tool} :: {GetPersonInfo()}";
    }
}
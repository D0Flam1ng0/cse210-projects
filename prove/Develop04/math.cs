class Math : Assignments
{
    private string _homework;
    public Math(string fristname, string lastname, string assignments, string homework)
    : base(fristname, lastname, assignments)
    {
        _homework = homework;
    }
    public string GetMathInfo()
    {
        return @$"{GetAssignmentsInfo()}
{_homework}";
    }
}
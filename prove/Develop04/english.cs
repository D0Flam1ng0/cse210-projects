class English : Assignments
{
    private string _writing;
    public English(string fristname, string lastname, string assignments, string writing)
    : base(fristname, lastname, assignments)
    {
        _writing = writing;
    }
    public string GetEnglishInfo()
    {
        return @$"{GetAssignmentsInfo()}
{_writing}";
    }
}
class Assignments
{

    private string _lname;

    private string _fname;

    private string _subject;


    public Assignments(string fname, string lname, string subject)
    {
        _lname = lname;
        _fname = fname;
        _subject = subject;
    }
    public string GetAssignmentsInfo()
    {
        return $"{_fname} {_lname} - {_subject}";
    }
}
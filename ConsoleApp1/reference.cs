public class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }

    public string GetDisplayText()
    {
        return _reference;
    }
}

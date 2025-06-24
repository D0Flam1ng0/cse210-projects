abstract class Person
{

    private string _lastname;

    private string _fristname;

    private int _age;

    public Person(string lastname, string fristname, int age)
    {
        _lastname = lastname;
        _fristname = fristname;
        _age = age;
    }
    public virtual string GetPersonInfo()
    {
        return $"{_fristname} {_lastname} Age: {_age}";
    }
    public abstract double getSalary();
    
}
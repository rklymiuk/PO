namespace po_lab02.classes;

public class Person
{
    
    protected string _firstName;
    protected string _lastName;
    protected DateTime _dateOfBirth;
    public string FirstName { get => _firstName; set => _firstName=value; }
    public string LastName { get => _lastName; set => _lastName=value; }
    public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth=value; }

     public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        _firstName = firstName;
        _lastName = lastName;
        _dateOfBirth = dateOfBirth;
    }

   public Person() : this(string.Empty, string.Empty, DateTime.MinValue){}
    
    public override string ToString() {
        return $"Osoba: {_firstName} {_lastName} \n Data urodzenia: {_dateOfBirth}";
    }
}
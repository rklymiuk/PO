namespace lab04.classes;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }
    public Person():this(string.Empty, string.Empty, DateTime.MinValue){}
    public override string ToString()
    {
        return $"{FirstName} /{LastName}/{DateOfBirth.ToShortDateString()}";
    }
}
namespace lab03.classes;

public  abstract class Person
{
    string firstName;
    string lastName;

    public string FirstName
    {
        get => firstName;
        set => firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => lastName;
        set => lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Person(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public Person() : this(string.Empty, string.Empty){}

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName}";
    }
    
}
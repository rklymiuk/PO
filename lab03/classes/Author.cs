namespace lab03.classes;

public class Author:Person
{

    string _nationality;
    
    public string Nationality
    {
        
        get => _nationality; 
        
       
        set => _nationality = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Author(string firstName, string lastName, string nationality) : base(firstName, lastName)
    {

        this.Nationality = nationality ?? throw new ArgumentNullException(nameof(nationality));
        
    }
    public Author():this(string.Empty, string.Empty, string.Empty){}

    public override string ToString()
    {
        return $"author:{this.FirstName} {this.LastName}/ {this.Nationality}";
    }
}
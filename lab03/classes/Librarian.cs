namespace lab03.classes;

public class Librarian:Person
{
    DateTime HireDate;
    double Salary;

    public Librarian(string firstName, string lastName, DateTime hireDate, double salary) : base(firstName, lastName)
    {
        HireDate = hireDate;
        Salary = salary;
    }
    public Librarian() : this(string.Empty,string.Empty,DateTime.Now, 0){}
    public override string ToString()
    {
        return $"librarian:{FirstName} {LastName}/ {HireDate}/ {Salary}";
    }
}
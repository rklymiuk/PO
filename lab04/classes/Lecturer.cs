namespace lab04.classes;

public class Lecturer : Person
{
    public string AcademicTitle { get; set; }
    public string Position { get; set; }

    public Lecturer(string firstname, string lastname, DateTime date, string academicTitle, string position) : base(
        firstname, lastname, date)
    {
        AcademicTitle = academicTitle;
        Position = position;
    }

    public override string ToString()
    {
        return base.ToString() + AcademicTitle + Position;
        
    }
}
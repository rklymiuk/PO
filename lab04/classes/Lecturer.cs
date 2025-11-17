namespace lab04.classes;

public class Lecturer : Person
{
    public string AcademicTitle { get; set; }
    public string Position { get; set; }

    public override string ToString()
    {
        return base.ToString() + AcademicTitle + Position;
        
    }
}
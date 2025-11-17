using lab04.Interfaces;

namespace lab04.classes;

public class Student : Person, IClassWithIList
{
    private static int nextId = 0;
    private static int _id;
    private int group;
    private int _semester;
    
    public static int Id
    {
        get => _id;
    }

    public int Group
    {
        get => group;
        set
        {
            if (value > 0)
            {
                group = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Group must be bigger than zero");
            }
        }
    }

    public int Semester
    {
        get => _semester;
        set
        {
            if (value > 0)
            {
                _semester = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("semester cannot be zero");
            }
        }
    }
    public string Specialization { get; set; }
    public int IndexId{get; set;}
    public double AverageGrade
    {
        get => Grades.Average(g => g.Value);
    }
   
    public IList<FinalGrade> Grades
    {
        get; 
        set=>
        
    }
    
}
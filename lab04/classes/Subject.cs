namespace lab04.classes;

public class Subject
{

    private int _semester;
    private string _specialization;
    private int _hoursCount;
    public string Name
    {
        get;
        set;
    }

    public string Specialization
    {
        get=>_specialization;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Specialization cannot be empty");
            }
            _specialization = value;
            
        }
    }

    public int Semester
    {
        get => _semester;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Semester cannot be less or equal to zero");
            }
            _semester = value;
        }
    }

    public int HoursCount
    {
        get=>_hoursCount;
        set
        {
            if (HoursCount < 0)
            {
                throw new ArgumentException("Hours count cannot be less or equal to zero");
            }
            _hoursCount = value;
        }
    }

    public Subject(string name, string specialization, int semester, int hoursCount)
    {
        Name = name;
            
        Semester = semester;
        Specialization = specialization;
        HoursCount = hoursCount;
    }

    public Subject() : this("noname", "no specialization", 1, 1){}
    public  override  string ToString()
    {
        return $"{Name}/{Specialization}/{Semester}/{HoursCount}";
    }
    
    
}
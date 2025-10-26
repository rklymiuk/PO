namespace po_lab02.classes;

public class  Student : Person
{
    private int _year;
    private int _group;
    private int _indexId;
        
    private List<Grade> _grades = new List<Grade>();
    public int Year { get => _year; set => _year=value; }
    public int Group { get => _group; set => _group=value; }
    public int IndexId { get => _indexId; private set => _indexId=value; }
    public List<Grade> Grades { get => _grades; set => _grades=value??new List<Grade>(); }

    public Student() : base()
    {
        _year = 0;
        _group = 0;
        _indexId = 0;
        _grades= null;
    }

    public Student(string firstName, string lastName, DateTime dateOfBirth, int year, int group, int indexId
        ) : base(firstName, lastName, dateOfBirth)
    {
        _year = year;
        _group = group;
        _indexId = indexId;
        
    }
    public override string ToString() {
        string s = base.ToString() + $"Student: {_year}/{_group}/{_indexId}/oceny:\n";
        foreach(var o in Grades){ s+="- "+o +"\n";}
        return s;
    }

    public void AddGrade(string subjectName, double value, DateTime date)
    {   
        
        _grades.Add(new Grade(subjectName, value, date));
    }
    public void AddGrade(Grade grade)
    {
        if (grade != null)
        {
            _grades.Add(grade);
        }
    }
    public void DeleteGrade(Grade grade) => Grades.Remove(grade);


    public void DeleteGrade(string subjectName, double value, DateTime date)
    {
        
        var gradeToRemove = Grades.FirstOrDefault(g =>
            g.Value == value &&
            g.SubjectName == subjectName &&
            g.Date  == date);

        if (gradeToRemove != null)
            Grades.Remove(gradeToRemove);
    }

    public void  DeleteGrades(string subjectName)
    {
        Grade temp = null;
        foreach (Grade grade in Grades)
        {
            if (grade.SubjectName == subjectName)
            {
                temp = grade;
            }
        }
        Grades.Remove(temp);
    }

    public void DeleteGrades()
    {
        Grades.Clear();
    }

    public string GetGrades()
    {
        string s = "";
        foreach (Grade grade in Grades)
        {
            s+=grade.ToString();
        }
        return s;
    }
    
}
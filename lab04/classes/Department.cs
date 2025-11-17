using lab04.Interfaces;

namespace lab04.classes;

public class Department : IClassWithIList 
{
    public string Name { get; set; }
    public Person Dean { get; set; }
    public IList<OrganizationUnit> OrganizationUnits { get; set; }
    public IList<Subject> Subjects { get; set; }
    public IList<Student> Students { get; set; }

    public Department(string name, Person dean, IList<Subject> subjects, IList<Student> students)
        
    {
        Name = name;
        Dean = dean;
        Subjects = subjects;
        Students = students;
        
    }
    public override string ToString()
    {
        return $"{Name}/{Dean}" +  string.Join(", ", Subjects) + string.Join(", ", Students);
    }
}
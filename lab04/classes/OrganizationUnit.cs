using lab04.Interfaces;

namespace lab04.classes;

public class OrganizationUnit : IClassWithIList
{
    public string Name { get; set; }
    public string Address{ get; set; }
    public IList<Lecturer> Lecturers{ get; set; } =  new List<Lecturer>();

    public OrganizationUnit(string name, string address, IList<Lecturer> lecturers)
    {
        Name = name;
        Address = address;
        Lecturers = lecturers;
    }
    public override string ToString()
    {
        return string.Join(", ", Lecturers);
    }
}
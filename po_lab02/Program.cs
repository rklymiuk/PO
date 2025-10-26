namespace po_lab02;
using po_lab02.classes;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Kod testowy 1");
        Console.WriteLine("-----------------------------------------------------------------------");
        Person person1 = new("Alex","Nowak",new(2035,3,8,12,30,10));
        Person person2 = new Student("Michalina","Wójcik",new(2032,6,1),3,5,12345);
        Person person3 = new Player("Marian","Kozłowski",new(2033,12,24),"Striker","ARS Warsaw",41);
        Console.WriteLine(person1);
        Console.WriteLine(person2);
        Console.WriteLine(person3);
        Student student = new("Katarzyna","Piotrowska",new(2030,12,31),2,5,54321);
        Console.WriteLine(student);
        ((Player)person3).ScoreGoal();
        Console.WriteLine(person3);
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Kod testowy 2");
        Console.WriteLine("-----------------------------------------------------------------------");
        ((Student)person2).AddGrade("PO",5.0D,new(2051,2,14));
        ((Student)person2).AddGrade("Bazy Danych",5.0D,new(2052,11,11));
        Console.WriteLine(person2);
        Grade grade = new("Bazy Danych",5.0D,new(2053,5,1));
        student.AddGrade(grade);
        student.AddGrade("AWWW",5.0D,new(2054,12,6));
        student.AddGrade("AWWW",4.5D,new(2055,10,31));
        var grades = student.GetGrades();
        Console.WriteLine(student);
        student.DeleteGrade("AWWW",4.5D,new(2055,10,31));
        Console.WriteLine(student);
        student.DeleteGrades("AWWW");
        Console.WriteLine(student);
        student.AddGrade("AWWW",5.0D,new(2056,11,1));
        student.DeleteGrades();
        Console.WriteLine(student);
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine("Kod testowy 3");
        Console.WriteLine("-----------------------------------------------------------------------");
        Person footballPlayer = new FootballPlayer("Mateusz","Żuraw",new(2031,7,4),"striker","BTR Paris",10);
        Person handballPlayer = new HandballPlayer("Patrycja","Szymańska",new(2030,5,1),"striker","EQY Tokyo");
        Console.WriteLine(footballPlayer);
        Console.WriteLine(handballPlayer);
        ((Player)handballPlayer).ScoreGoal();
        (footballPlayer as Player)?.ScoreGoal();
        Console.WriteLine(footballPlayer);
        Console.WriteLine(handballPlayer);
    }
}
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace lab04;
using lab04.classes;
using lab04.Interfaces;
class Program
{
    static void Main(string[] args)
    {
        //-----------------------------------------------------------------------
// Przygotowanie danych
//-----------------------------------------------------------------------
#region Przygotowanie danych
Subject soop = new("Programowanie obiektowe","Informatyka",2,60);
Subject sdb = new("Bazy danych","Informatyka",3,45);
Subject sweb = new("Technologie internetowe","Informatyka",4,45);
Subject sma = new("Matematyka","Informatyka",1,30);
Console.WriteLine($"[] Przedmioty po zainicjowaniu:\n{soop}\n{sdb}\n{sweb}\n");
Lecturer l1 = new("Jan","Nowak",new (2040,6,1),"dr inż.","Adiunkt");
Lecturer l2 = new("Maja","Kot",new (2030,8,15),"dr","Asystent");
Lecturer l3 = new("Jan","Walas",new (2045,12,6),"prof.","Profesor");
Console.WriteLine($"[] Wykładowcy po zainicjowaniu:\n{l1}\n{l2}\n{l3}\n");
Student s1 = new("Anna","Misiak",new (2055,4,1),"Informatyka",1,2);
Student s2 = new("Ewa","Kowalska",new (2055,3,8),"Informatyka",1,3);
Student s3 = new("Olga","Siejska",new (2055,1,6),"Informatyka",2,3);
Console.WriteLine($"[] Studenci po zainicjowaniu:\n{s1}\n{s2}\n{s3}\n");
IList<FinalGrade> grades1 = [
/*new(soop, 5.0, new(2075,6,1)),*/
new(sdb, 4.0, new(2075,5,1)),
new(sweb, 3.5, new(2075,4,1))
];
IList<FinalGrade> grades2 = [
new(soop, 3.0, new(2075,6,1)),
new(sdb, 2.0, new(2075,5,1)),
new(sweb, 4.0, new(2075,4,15))
];
IList<FinalGrade> grades3 = [
new(soop, 5.0, new(2075,6,1)),
new(sdb, 5.0, new(2075,3,8)),
new(sweb, 5.0, new(2075,3,15))
];

Console.WriteLine($"[] Listy ocen po zainicjowaniu:\n{grades1}\n{grades2}\n{grades3}\n"); 
OrganizationUnit ou1 = new("Katedra TI","ul. Polna 1",[l1,l2]);
OrganizationUnit ou2 = new("Katedra BD","ul. Polna 2",[l3]);
Lecturer dean = new("Andrzej","Lewandowski",new DateTime(2035,2,14),"dr hab. inż.","Dziekan");
Department d1 = new("WIiSI",dean,[soop,sdb,sweb,sma],[s1,s2,s3]);
Console.WriteLine($"[] Wydział po zainicjowaniu:\n{d1}\n");
#endregion
//-----------------------------------------------------------------------
// Testowanie metod rozszerzeń (TMR): Add, AddRange
//-----------------------------------------------------------------------
Console.WriteLine($"[] Studenci przed dodaniem ocen:\n{s1}\n{s2}\n{s3}\n");
s1.Add<FinalGrade>(new(soop,5.0,new(2075,6,1)));
s1.AddRange<FinalGrade>(grades1);
s2.AddRange<FinalGrade>(grades2);
s3.AddRange<FinalGrade>(grades3);
Console.WriteLine($"[] Studenci po dodaniu ocen:\n{s1}\n{s2}\n{s3}\n");
d1.AddRange<OrganizationUnit>([ou1,ou2]);
Console.WriteLine($"[] Wydział po dodaniu jednostek:\n{d1}\n");
//-----------------------------------------------------------------------
// TMR: Contains, IndexOf, Remove
//-----------------------------------------------------------------------
FinalGrade nowaOcena = new(sdb,4.5,new(2075,7,1));
s1.Add<FinalGrade>(nowaOcena);
bool contains1 = s1.Contains<FinalGrade>(nowaOcena); //true
bool contains2 = s1.Contains<FinalGrade>(new(sdb,4.5,new(2075,7,4))); //false
Console.WriteLine($"[] contains1={contains1}, contains2={contains2}\n");
int index = s1.IndexOf<FinalGrade>(nowaOcena); //3
Console.WriteLine($"[] index={index}\n");
s1.Remove<FinalGrade>(nowaOcena);
Console.WriteLine($"[] s1 po usunięciu nowej oceny:\n{s1}\n");
//-----------------------------------------------------------------------
// Dodatkowy test: RemoveAt
//-----------------------------------------------------------------------
Console.WriteLine("[] Test RemoveAt:");
FinalGrade ocenaMatematyka = new(sma,5.0,new(2075,9,1));
s1.Add<FinalGrade>(ocenaMatematyka);
int idx = s1.IndexOf<FinalGrade>(ocenaMatematyka);
if(idx!=-1) s1.RemoveAt<FinalGrade>(idx);
Console.WriteLine($"s1 po RemoveAt({idx}):\n{s1}\n");
//-----------------------------------------------------------------------

// TMR: Update
//-----------------------------------------------------------------------
Console.WriteLine($"[] s2 przed poprawą oceny z BD:\n{s2}\n");
var stara = s2.Grades.FirstOrDefault(g => g.Subject.Name=="Bazy danych"&&g.Value==2);
s2.Update<FinalGrade>(stara,new(sdb,4.5,new DateTime(2075,9,30)));
Console.WriteLine($"[] s2 po poprawie oceny z BD:\n{s2}\n");
    }
}
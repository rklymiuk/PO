namespace lab03;
using lab03.classes;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy operacji podstawowych");
Console.WriteLine("-----------------------------------------------------------");
Author a1 = new("Anna","Tracz","polska");
Author a2 = new("Jan","Bielik","polska");
Author a3 = new("Maria","Miłka","polska");
Item i1 = new Book("Kompendium programisty",2,"PolPress",new
DateTime(2065,12,06),500,[a1,a2]);
((Book)i1).AddAuthor(a3);
Item i4 = new Book("Kompendium administratora baz danych",3,"PolPress",new
DateTime(2065,05,01),500,[a3]);
((Book)i4).AddAuthor(a1);
Item i2 = new Journal("Przegląd techniczny",1,"MyPress",new
DateTime(2060,06,01),1);
var bookBarCode = ((Book)i1).GenerateBarCode();
Console.WriteLine($"{i1} \r\n Kod kreskowy: {bookBarCode}");
var journalBarCode = ((Journal)i2).GenerateBarCode();
Console.WriteLine($"{i2} \r\n Kod kreskowy: {journalBarCode}");
List<Item> items1 = [i1,i2,i4];
Catalog c1 = new("Książki o programowaniu",items1);
c1.AddItem(new Journal("Wzorce programistyczne",1,"ITPress",new
DateTime(2060,02,14),1));
Console.WriteLine(c1);
Console.WriteLine('\n'+c1.GetAllItems("Wszystkie pozycje w katalogu:"));
Console.WriteLine("-----------------------------------------------------------");

Console.WriteLine("Testy wyszukiwania przedmiotów");
Console.WriteLine("-----------------------------------------------------------");
string searchedValue = "Kompendium programisty";
Item? foundedItemByTitle = c1?.FindItem(item => item.Title==searchedValue);
Item? foundedItemById = c1?.FindItem(item => item.Id==1);
Item? foundedItemByDateRange = c1?.FindItem(
item => item.DateOfIssue>=new DateTime(2055,01,01)&&
item.DateOfIssue<=new DateTime(2085,12,31)
);
Console.WriteLine("Wyszukanie po id:\n"+foundedItemById);
Console.WriteLine("Wyszukanie po tytule:\n"+foundedItemByTitle);
Console.WriteLine("Wyszukanie po datach:\n"+foundedItemByDateRange);
Item? foundedItemByIdOld = c1?.FindItemBy(1);
Item? foundedItemByTitleOld = c1?.FindItemBy(searchedValue);
Console.WriteLine("Wyszukanie po id (wersja 2):\n"+foundedItemByIdOld);
Console.WriteLine("Wyszukanie po tytule (wersja 2):\n"+foundedItemByTitleOld);
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy dla bibliotek");
Console.WriteLine("-----------------------------------------------------------");
Person l1 = new Librarian("Maja","Kowal",DateTime.Now.Date,2040);
Person l2 = new Librarian("Jan","Morus",DateTime.Now.Date,2040);
Library lib1 = new("Częstochowa, Armii Krajowej 36",[(Librarian)l1],[]);
lib1.AddLibrarian((Librarian)l2);
Console.WriteLine(lib1.GetAllLibrarians("Wszyscy bibliotekarze:"));
Catalog c2 = new("Powieści",[]);
lib1.AddCatalog(c2);
if(c1!=null) lib1.AddCatalog(c1);
Item i3 = new Book("Głos większości",4,"Nasze wersy",new
DateTime(2061,03,08),800,[ a1 ]);
lib1.AddItem(i3,"Powieści");
Console.WriteLine(lib1);
Console.WriteLine(lib1.GetAllItems("Wszystkie pozycje w bibliotece:"));
var foundedById = lib1.FindItemBy(4);
var foundedByTitle = lib1.FindItemBy(searchedValue);
var foundedByLambda = lib1.FindItem(x => x.Publisher=="ITPress");
Console.WriteLine(foundedById);
Console.WriteLine(foundedByTitle);
Console.WriteLine(foundedByLambda);
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy dla dodawania i usuwania przedmiotów");
Console.WriteLine("-----------------------------------------------------------");
Catalog c3 = new("Literatura fantastyczna",[]);
Library lib2 = new("Warszawa, Marszałkowska 12",[],[c3]);
var bookToAdd = new Book("Lot ku centrum",5,"Super Press",new
DateTime(2060,06,01),350,[a1]);
c3.AddItem(bookToAdd);
Console.WriteLine("Po dodaniu książki:");
Console.WriteLine(c3.GetAllItems("Pozycje w katalogu:"));
c3.RemoveItem(bookToAdd);
Console.WriteLine("Po usunięciu książki:");
Console.Write(c3.GetAllItems("Pozycje w katalogu:"));

Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy wyszukiwania z bardziej złożonymi warunkami");
Console.WriteLine("-----------------------------------------------------------");
var foundByMultipleConditions =
lib1?.FindItem(x => x.Publisher=="ITPress"&&x.DateOfIssue>=new
DateTime(2040,01,01));
Console.WriteLine("Wyszukiwanie po wielu warunkach:");
Console.WriteLine(foundByMultipleConditions);
Console.WriteLine("Pozycja zawierająca w tytule 'ę':");
Console.WriteLine(lib1?.Catalogs[0].FindItem(c =>
c.Title.Contains('ę'))?.ToString());
Console.WriteLine("Pozycja zawierająca w tytule 'ę' (z Expression):");

Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy dla błędnych argumentów");
Console.WriteLine("-----------------------------------------------------------");
Item? nonExistentItem = lib1?.FindItemBy(999);
Console.WriteLine("Wyszukiwanie nieistniejącego przedmiotu (ID 999):");
Console.WriteLine(nonExistentItem?.ToString()??"Nie znaleziono przedmiotu");
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy grupowania po roku wydania (metoda generyczna)");
Console.WriteLine("-----------------------------------------------------------");
lib1 ??= new();
List<GroupedItemsByKeyReport<int,Item>>? groupedByYear =
GroupItemsHelper.GroupItemsBy(
lib1.Catalogs.SelectMany(c => c.Items).ToList(),
item => item.DateOfIssue.Year
);
if(groupedByYear is not null) foreach(var e in
groupedByYear)Console.WriteLine(e);
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy grupowania po wydawcy (metoda generyczna)");
Console.WriteLine("-----------------------------------------------------------");
List<GroupedItemsByKeyReport<string,Item>>? groupedByPublisher =
GroupItemsHelper.GroupItemsBy(
lib1.Catalogs.SelectMany(c => c.Items).ToList(),
item => item.Publisher
);
if(groupedByPublisher is not null) foreach(var e in groupedByPublisher)
Console.WriteLine(e);
Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy grupowania książek po liczbie stron (m. generyczna)");
Console.WriteLine("-----------------------------------------------------------");
List<GroupedItemsByKeyReport<int,Book>>? groupedByPageCount =
GroupItemsHelper.GroupItemsBy(
lib1.Catalogs.SelectMany(c => c.Items).OfType<Book>().ToList(),
item => item.PageCount
);
if(groupedByPageCount is not null) foreach(var e in groupedByPageCount)
Console.WriteLine(e);

Console.WriteLine("-----------------------------------------------------------");
Console.WriteLine("Testy grupowania autorów po narodowości (m. generyczna)");
Console.WriteLine("-----------------------------------------------------------");
List<GroupedItemsByKeyReport<string,Author>>? groupedByNationality =
GroupItemsHelper.GroupItemsBy(
lib1.Catalogs
.SelectMany(c => c.Items)
.OfType<Book>()
.SelectMany(b => b.Authors)
.Distinct()
.ToList(),
item => item.Nationality
);
if(groupedByNationality is not null) foreach(var e in groupedByNationality)
Console.WriteLine(e);
    }
}
namespace lab03.classes;

public class Library
{
    private string _adress;
    private List<Catalog> _catalogs;
    private List<Librarian> _librarians;

    public string Adress
    {
        get => _adress;
        set
        {
            _adress = value;
        }
    }

    public List<Librarian> Librarians
    {
        get => _librarians;
        set
        {
            _librarians = value;
        }
    }

    public List<Catalog> Catalogs
    {
        get => _catalogs;
        set
        {
            _catalogs = value;
        }
    }

    public Library(string address, List<Librarian> librarians, List<Catalog> catalogs)
    {
        _adress = address;
        _librarians = librarians;
        _catalogs = catalogs;
    }

    public Library() : this(string.Empty, new List<Librarian>(), new List<Catalog>()){}

    public void AddLibrarian(Librarian librarian)
    {
        if (!Librarians.Contains(librarian))
        {
            Librarians.Add(librarian);
        }
        else throw new ArgumentException( $"Librarians already contains {librarian.ToString()}");

    }

    public void RemoveLibrarian(Librarian librarian)
    {
        if (Librarians.Contains(librarian))
        {
            Librarians.Remove(librarian);
        }
        else throw new ArgumentException( $"Librarians does not contain {librarian.ToString()}");
    }
    public void AddCatalog(Catalog catalog)
    {
        if (!Catalogs.Contains(catalog))
        {
            Catalogs.Add(catalog);
        }
        else throw new ArgumentException( $"Catalogs already contains {catalog.ToString()}");

    }
    public void RemoveCatalog(Catalog catalog)
    {
        if (Catalogs.Contains(catalog))
        {
            Catalogs.Remove(catalog);
        }
        else throw new ArgumentException( $"Catalogs does not contain {catalog.ToString()}");
    }

    
    public  string GetAllLibrarians(string s = "")=>s+=string.Join("\n", Librarians.Select(x => x.ToString()));

    public void AddItem(Item item, string thematicDepartment)
    {
        var targetCatalog = Catalogs.FirstOrDefault(c => c.ThematicDepartment == thematicDepartment);
        if (targetCatalog != null) { targetCatalog.AddItem(item); }
        else { throw new ArgumentException($"No catalog found for department: {thematicDepartment}"); }
    }

    public string GetAllItems(string s = "") => s+=string.Join("\n", Catalogs.SelectMany(c => c.Items).Select(i => i.ToString()));
    public Item? FindItemBy(int id) => Catalogs.SelectMany(c => c.Items).FirstOrDefault(i => i.Id == id);
    public Item? FindItemBy(string title) => Catalogs.SelectMany(c => c.Items).FirstOrDefault(i => i.Title == title);

    public Item? FindItem(Func<Item, bool> predicate)
    {
        return Catalogs.SelectMany(c => c.Items).FirstOrDefault(predicate);
    }

    public override string ToString()
    {
        
        return $"Library: {Adress}/Num of librarians  {Librarians.Count}/ Num of catalogs  {Catalogs.Count}";
    }
}
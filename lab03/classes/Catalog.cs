namespace lab03.classes;

public class Catalog
{
    List<Item> _items;
    private string _thematicDepartment;

    public List<Item> Items
    {

        get => _items;
        
        set => _items = value;
    }


    public string ThematicDepartment
    {
        get => _thematicDepartment;
        set => _thematicDepartment = value;
        
    }

    public Catalog(string thematicDepartment,  List<Item> items)
    {
        _thematicDepartment = thematicDepartment;
        _items = items;
        
    }

    public Catalog(List<Item> items)
    {
        _items = items;
        
    }

    public Catalog() : this(string.Empty, new List<Item>()){}

    public void AddItem(Item item)
    {
        if(!Items.Any(i => i.Title == item.Title)){
            Items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        if (Items.Any(i => i.Title == item.Title))
        {
            Items.Remove(item);
        }
    }
   
    public override string ToString()
    {
        string s = $"Catalog:{ThematicDepartment}, Contains:"+string.Join("\n",  Items.Select(i => i.ToString()));
        return s;
    }
    public string GetAllItems(string s= "") => s+=string.Join("\n", Items.Select(i => i.ToString()));
    public Item? FindItemBy(int id) => Items.FirstOrDefault(i => i.Id == id);
    public Item? FindItemBy(string title) => Items.FirstOrDefault(i => i.Title == title);

    public Item? FindItem(Func<Item, bool> predicate)
    {
        return Items.FirstOrDefault(predicate);
    }

    
}
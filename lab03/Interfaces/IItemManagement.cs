namespace lab03.Interfaces;
using lab03.classes;
public interface IItemManagement
{
    public string GetAllItems();
    public Item FindItemBy(int id);
    public Item FindItemBy(string name);
    public Item FindItem(Func<Item, bool> predicate);
    
}
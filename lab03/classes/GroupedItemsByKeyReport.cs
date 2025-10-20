namespace lab03.classes;

public class GroupedItemsByKeyReport<TKey, TValue>
{
    private List<TValue> _items;
    private TKey _key;
    

    public List<TValue> Items
    {
        get => _items;
        set => _items = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TKey Key
    {
        get => _key;
        set => _key = value ?? throw new ArgumentNullException(nameof(value));
    }

    public GroupedItemsByKeyReport()
    {
        _key = default!;
        _items = new List<TValue>();
    }

    public GroupedItemsByKeyReport(TKey key, List<TValue> items)
    {
        _key = key;
        _items = items ?? throw new ArgumentNullException(nameof(items));
    }
    
    public override string ToString()
    {
        return $"key:{_key} items:{_items.Count}";
    }
}
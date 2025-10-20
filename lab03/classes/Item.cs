using lab03.Interfaces;

namespace lab03.classes;

public abstract class Item : IBarCodeGenerator
{
    DateTime _dateofIssue;
    int _id;
    string _publisher;
    string _title;

    public DateTime DateOfIssue
    {
        get =>_dateofIssue;
        set => _dateofIssue= value;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Publisher
    {
        get =>_publisher;
        set => _publisher = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Item(string title, string publisher, int id, DateTime dateOfIssue)
    {
        _title = title ?? throw new ArgumentNullException(nameof(title));
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        _id = id;
        _dateofIssue = dateOfIssue;
    }
    public Item():this("", "", 0,DateTime.MinValue){}
  

    public override string ToString()
    {
        return $"{_title}/{_publisher}/{_id}/{_dateofIssue}";
    }

    public abstract string GenerateBarCode();
}
namespace lab03.classes;

public class Journal : Item
{
    private int _number;

    public int Number
    {
        get => _number;
        set => _number = value;
    }
    public Journal(string title, int id, string publisher,DateTime dateOfIssue, int number)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Id = id;
        Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        DateOfIssue = dateOfIssue;
        Number = number;
        
    }

    public Journal() : this(string.Empty, 0, string.Empty, DateTime.Now, 0){}

    public override string ToString()
    {
        return $"{Title},{Id},{Publisher},{DateOfIssue},{Number}";
    }

    public override string GenerateBarCode()
    {
        return $"J-{Id}-{DateOfIssue}-{Number}";
    }
}
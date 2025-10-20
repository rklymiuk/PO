using lab03.Interfaces;

namespace lab03.classes;

public class Book : Item
{
    List <Author> _authors;
    int _pageCount;

    public List<Author> Authors
    {
        get => _authors;
        set => _authors = value ?? throw new ArgumentNullException(nameof(value));
    }
    public int PageCount
    {
        get => _pageCount;
    }

    public Book(string title, int id, string publisher, DateTime dateOfIssue, int pageCount, List<Author> authors): base(title, publisher, id, dateOfIssue)
    {
        _pageCount = pageCount;
        _authors = authors ?? throw new ArgumentNullException(nameof(authors));
        
    }

    public Book():this(string.Empty,0,string.Empty,DateTime.MinValue,0,new List<Author>()){}

    public  override string  GenerateBarCode()
    {
        return $"B-{Id}-{DateOfIssue}-{Publisher}";
    }

    public void RemoveAuthor(Author author)
    {
        _authors.Remove(author);
    }

    public void AddAuthor(Author author)
    {
        _authors.Add(author);
    }

    public override string ToString()
    {
        string temp = string.Join(",", Authors);
        return $"{Title},{Id},{Publisher},{DateOfIssue},{PageCount},{temp}";
    }
}
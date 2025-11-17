namespace lab04.classes;

public class FinalGrade
{
    private Subject _subject;
    private double _value;

    public Subject Subject
    {
        get=>_subject;
        set
        {
            if (_subject != null)
            {
                throw new InvalidOperationException("Subject cannot be null");
            }
            _subject = value;
        }
    }

    public double Value
    {
        get => _value;
        set
        {
            if (value < 2.0)
            {
                throw new InvalidOperationException("Value cannot be less than 2");
            }
            _value = value;
        }
    }
    public DateTime Date { get; set; }

    public FinalGrade(Subject subject, double value, DateTime date)
    {
        Subject = subject;
        Value = value;
        Date = date;
    }
    public FinalGrade():this(new Subject(), 2.1, DateTime.Now){}

    public override string ToString()
    {
        return $"{Subject}/{Date.ToShortDateString()}/ {Value}";
        
    }
    
}
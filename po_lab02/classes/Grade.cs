namespace po_lab02.classes;

public class Grade
{
    private string _subjectName;
    private double _value;
    private DateTime _date;
    
    public string SubjectName { get => _subjectName; set => _subjectName=value; }

    public double Value {
        get => _value;
        set {
            if(value<2.0||value>5.0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Ocena musi być w przedziale od 2 do 5."
                );
            }
            else
            {
                _value = value;
            }
            
        }
    }
    public DateTime Date { get => _date; set => _date=value; }

    public  Grade(string subjectName, double value, DateTime date)
    {
        _subjectName=subjectName;
        _value=value;
        _date=date;
    }

    public Grade() : this(string.Empty, 0.0, DateTime.MinValue){}
    
    public override string ToString() {
        return $"Ocena: {_subjectName}/{_value}/{_date.ToShortDateString()}\n";
    }

}
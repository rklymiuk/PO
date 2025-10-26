namespace po_lab02.classes;

public class Player : Person
{
    private string _position;
    private string _club;
    private int _scoredGoals;
    public string Position { get => _position; set => _position=value; }
    public string Club { get => _club; set => _club=value; }
    
    public int ScoredGoals { get => _scoredGoals; set => _scoredGoals=value; }

    public Player() : base()
    {
        _position.DefaultIfEmpty();
        _club.DefaultIfEmpty();
        _scoredGoals = 0;
    }
    public Player(string firstName, string lastName, DateTime dateOfBirth, string position, string club, int scoredGoals) : base(firstName, lastName, dateOfBirth)
    {
        _position = position;
        _club = club;
        _scoredGoals = scoredGoals;
        
    }

    public override string ToString()
    {
        string s = base.ToString()  + $"Player {_position}/{_club}/{_scoredGoals}";
        return s;
    }

    public virtual void ScoreGoal(){}
}
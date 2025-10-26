namespace po_lab02.classes;

public class HandballPlayer :  Player
{
    public HandballPlayer():base() {}
    public HandballPlayer(string firstName, string lastName, DateTime dateOfBirth,string position,string club,int scoredGoals=0):base(firstName, lastName, dateOfBirth, position, club, scoredGoals) { }
    
    public override void ScoreGoal()
    {
        ScoredGoals += 4;
    }
}
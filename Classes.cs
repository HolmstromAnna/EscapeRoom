using System.Runtime.CompilerServices;

public class Question
{
    public string QuestionText;
    public string Answer;
    public string PathChoice;
    public Room NextRoom;   //hur sätter vi om till nästa rum? +1 och new?

    public Question(string questiontext, string answer, string pathChoice, Room nextRoom) 
    {
        QuestionText = questiontext;
        Answer = answer;
        PathChoice = pathChoice;
        NextRoom = nextRoom;
    }
    public virtual bool CheckAnswer(string userAnswer)
    {
         if(userAnswer == Answer)
            return true;
        else
            return false;
    }
}
/*
public class RedHerring
{
    public string Blabla;
    public string PathChoice;
    public Room NextRoom;
    public RedHerring(string blabla, string pathChoice, Room nextRoom) 
    {
        Blabla = blabla;
        PathChoice = pathChoice;
        NextRoom = nextRoom;
    }

}*/
public class Room
{
    public string Description;
    public List <Question> Questions;
    public Room (string description, List <Question> questions)
    {
        Description = description;
        Questions = questions;
    }
    public virtual bool CheckAnswer(string userAnswer)
    {
        return true;
    }
}
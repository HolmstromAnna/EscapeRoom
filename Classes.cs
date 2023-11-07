using System.Runtime.CompilerServices;

class Question
{
    public string QuestionText {get; set;}
    public string Answer {get; set;}
    public string PathChoice {get; set;}
    public Room NextRoom {get; set;}
    public Question(string questiontext, string answer, string pathChoice) 
    {
        QuestionText = questiontext;
        Answer = answer;
        PathChoice = pathChoice;
    }
    public virtual bool CheckAnswer(string userAnswer)
    {
         if(userAnswer == Answer)
            return true;
        else
            return false;
    }
}
class Room
{
    public string Description {get; set;}
    public List <Question> Questions {get; set;}
    public List <Question> PathChoices {get; set;}
    public Room (string description, List <Question> questions, List<Question> pathChoices)
    {
        Description = description;
        Questions = questions;
        PathChoices = pathChoices;
    }
    public virtual bool CheckAnswer(string userAnswer)
    {
        return true;
    }
}
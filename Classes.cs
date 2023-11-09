using System.Runtime.CompilerServices;

public abstract class Things    //ett bättre namn?
{
    public string Description;
    public string PathChoice;
    public Room NextRoom;
    public Things (string description, string pathChoice, Room nextRoom)
    {
        Description = description;
        PathChoice = pathChoice;
        NextRoom = nextRoom;
    }

    public abstract void Interact();
}

public class DeadEnd : Things
{
    public DeadEnd (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override void Interact()
    {
        Console.WriteLine(Description);
        Console.WriteLine("Här finns ingenting.");
        //NextRoom = currentRoom;       ??????
    }
}


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
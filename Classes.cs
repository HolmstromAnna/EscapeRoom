using System.Formats.Asn1;
using System.Net;
using System.Runtime.CompilerServices;

public abstract class Thing    //ett bättre namn?
{
    public string Description;
    public string PathChoice;
    public Room NextRoom;
    public Thing (string description, string pathChoice, Room nextRoom)
    {
        Description = description;
        PathChoice = pathChoice;
        NextRoom = nextRoom;
    }

    public abstract void Interact();
}

public class DeadEnd : Thing
{
    public DeadEnd (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override void Interact()
    {
        //Console.WriteLine(Description);
        
        Console.WriteLine("här finns ingenting.");
        //NextRoom = currentRoom;       ??????
    }
}
public class Question : Thing
{
    public string CorrectAnswer;

    public Question (string description, string correctAnswer, string pathChoice, Room nextRoom) :base(description, pathChoice, nextRoom)
    {
        CorrectAnswer = correctAnswer;
    }
    public override void Interact()
    {
        //Console.WriteLine(Description);
        Console.Write("Ditt val: ");
        string? userAns = Console.ReadLine();
        if(userAns == CorrectAnswer)
        {
            Console.WriteLine();
            Console.WriteLine("Rätt!");
            return;
            //Vi behöver komma till nästa rum också...
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Fel");
            //currentRoom = currentRoom;
        }
    }
}


public class Room
{
    public string RoomDescription;
    public List <Thing> Things;
    public Room (string roomDescription, List <Thing> things)
    {
        RoomDescription = roomDescription;
        Things = things;
    }
}
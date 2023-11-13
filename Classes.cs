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
    public abstract (Room, int playerLives) Interact(Room currentRoom, int playerLives);
}
public class DeadEnd : Thing
{
    public DeadEnd (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives)
    {        
        Console.WriteLine("här finns ingenting.");
        Console.WriteLine();
        Console.ReadLine();
        return (currentRoom, playerLives);
    }
}
public class BadLuck : Thing
{
    public BadLuck (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives)
    {        
        Console.WriteLine("Du förlorar ett liv...");
        playerLives--;
        Console.WriteLine($"Otur, du har nu bara {playerLives} liv kvar...");
        Console.WriteLine();
        Console.ReadLine();
        return (currentRoom, playerLives);
    }
}
public class Surprise : Thing
{
    public Surprise (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives)
    {        
        Console.WriteLine("Woho, du hittar ett liv!");
        if (playerLives == 5)
        {
            Console.WriteLine("Du kan bara ha fem liv");
        }
        else
        {
            playerLives++;
            Console.WriteLine($"Du har nu {playerLives} liv!");
        }
        Console.WriteLine();
        Console.ReadLine();
        return (currentRoom, playerLives);
    }
}
public class Question : Thing
{
    public string CorrectAnswer;

    public Question (string description, string correctAnswer, string pathChoice, Room nextRoom) :base(description, pathChoice, nextRoom)
    {
        CorrectAnswer = correctAnswer;
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives)
    {
        Console.Write("Ditt val: ");
        string? userAns = Console.ReadLine();
        if(userAns == CorrectAnswer)
        {
            Console.WriteLine();
            Console.WriteLine("Rätt!");
            return (NextRoom, playerLives);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Fel svar");
            if(playerLives == 1)
             {
                playerLives--;
                Console.WriteLine("GAME OVER!");
                Console.WriteLine();     
                return (currentRoom, playerLives);
             }
            playerLives--;
            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
            return (currentRoom, playerLives);
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
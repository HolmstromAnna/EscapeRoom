using System.Formats.Asn1;
using System.Net;
using System.Runtime.CompilerServices;
public abstract class Thing    //ett bättre namn?
{
    public string Description;
    public string PathChoice;
    public Room? NextRoom;
    public Thing (string description, string pathChoice, Room? nextRoom)
    {
        Description = description;
        PathChoice = pathChoice;
        NextRoom = nextRoom;
    }
    public abstract (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items);
}

public class DeadEnd : Thing
{
    public DeadEnd (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {        
        Console.Write("Här finns ingenting.");
        Console.WriteLine();
        Console.ReadLine();
        return (currentRoom, playerLives);
    }
}

public class BadLuck : Thing
{
    public BadLuck (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {    
        Console.ForegroundColor = ConsoleColor.Red;    
        Console.WriteLine("Du förlorar ett liv...");
        Console.ForegroundColor = ConsoleColor.White;
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
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {   
        Console.ForegroundColor = ConsoleColor.Blue;     
        Console.WriteLine("Wooho, du hittar ett liv!");
        Console.ForegroundColor = ConsoleColor.White; 
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
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {
        Console.Write("Ditt val: ");
        string? userAns = Console.ReadLine();
        if(userAns == CorrectAnswer)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rätt!");
            Console.ForegroundColor = ConsoleColor.White;
            return (NextRoom, playerLives);
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fel svar");
            Console.ForegroundColor = ConsoleColor.White;
            if(playerLives == 1)
             {
                playerLives--;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("GAME OVER!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();     
                return (currentRoom, playerLives);
             }
            playerLives--;
            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
            return (currentRoom, playerLives);
        }
    }
}

public class Backpack : Thing
{
    public string Item;
    
    public Backpack (string description, string pathChoice, Room nextRoom, string item) : base(description, pathChoice, nextRoom)
    {
        Item = item;
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {        
        Console.ReadKey();
        //Thread.Sleep(5000);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Woohoo! Du hittade: {Item}");
        Console.ForegroundColor = ConsoleColor.White;
        if (Items.Contains(Item))
        {
            Console.WriteLine($"Du har redan hittat föremålet som fanns här!");
        }
        else
        {
            Items.Add(Item);
            Console.WriteLine($"Tillagd i ryggäcken: {Item}.");
        }
        for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine(Items[i]);
            }
        Console.ReadKey();
        //Thread.Sleep(6000);
        Console.WriteLine();
        return (currentRoom, playerLives);
    }
}
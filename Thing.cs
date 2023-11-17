using System.Formats.Asn1;
using System.Net;
using System.Runtime.CompilerServices;
public abstract class Thing    //Basklass som hanterar rumsbeskrivning, vägval och nästa rum.
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

public class DeadEnd : Thing //Återvändsgränd och skickar tillbaka dig till samma rum.
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

public class BadLuck : Thing //Hanterar om du har otur och förlorar ett liv i rummen och ev. game over
{
    public BadLuck (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {   
        //Du förlorar ett liv. Har du då noll blir det game over
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Red;    
        Console.WriteLine("Du förlorar ett liv...");
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
        else
        {
            playerLives--;
            Console.WriteLine($"Otur, du har nu bara {playerLives} liv kvar...");
            Console.WriteLine();
            Console.ReadLine();
            return (currentRoom, playerLives);
        }
    }
}

public class Surprise : Thing //Hanterar om du hittar ett liv i rummen
{
    public Surprise (string description, string pathChoice, Room nextRoom) : base(description, pathChoice, nextRoom){
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {   
        //Kollar om du redan har maxantal liv, om inte får du ett.
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

public class Question : Thing //Hanterar Frågor och kontrollerar svar i rummen
{
    public string CorrectAnswer;
    public Question (string description, string correctAnswer, string pathChoice, Room nextRoom) :base(description, pathChoice, nextRoom)
    {
        CorrectAnswer = correctAnswer;
    }
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {
        //Kollar om du skriver in rätt alternativ.
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Ditt val: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? userAns = Console.ReadLine();

        if (userAns == "a" || userAns == "b" || userAns == "c" || userAns == "d")
        {
            if(userAns == CorrectAnswer) //Kontrollerar om det är rätt svar.
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Rätt!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                return (NextRoom!, playerLives);
            }
            else //Vid fel svar förloras ett poäng/ blir game over.
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
        else
        {
            Console.WriteLine("Välj ett utav alternativen!");
            return (currentRoom, playerLives);
        }
    }    
}

public class Backpack : Thing // Hanterar items i rummen och kontrollerar vad som händer när du hittar ett.
{
    public string Item;
    
    public Backpack (string description, string pathChoice, Room nextRoom, string item) : base(description, pathChoice, nextRoom)
    {
        Item = item;
    }
    
    public override (Room, int playerLives) Interact(Room currentRoom, int playerLives, List<string> Items)
    {   
        //Interact kollar om föremålet finns i ryggsäcken och om det inte gör det läggs det till.    
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Woohoo! Du hittade: {Item}");
        Console.ForegroundColor = ConsoleColor.White;

        if (Items.Contains(Item))
        {
            Console.WriteLine($"Du har tyvärr redan hittat föremålet som fanns här!");
        }
        else
        {
            Items.Add(Item);
            Console.WriteLine($"Föremålet är tillagt i din ryggäck");
        }
        Console.ReadKey();
        Console.WriteLine();
        return (currentRoom, playerLives);
    }
}
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {   
        bool isLooping = true;
        bool fromStart = true;

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Välkommen!\n\nHoppas du kan svara på lite frågor. Du har 5 liv, använd dom väl! \nDet finns olika utmaningar med flera rum i vardera att klara av. \nVarje rum har olika svårighetsgrad. \nDu kommer även stå inför olika val. Se till att välja rätt annars förlorar du. \nTryck enter för att börja.");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine();
        Console.ReadLine();

        while (fromStart)
        {
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Exit");
            string? input = Console.ReadLine(); // Spelaren väljer fråga

            int playerLives = 1;
            Room room1 = new Room("", new List<Thing>());
            Room room2 = new Room("", new List<Thing>());
            Room finalRoom = new Room("", new List<Thing>());
            Room currentRoom = room1;

            room1.RoomDescription = "        ‡        Du kliver in i rummet, där ser du en obäddad säng tvärs över rummet.      ‡ \n        ‡         Till höger ser du en kamin med en blodig handduk hängande på tork.       ‡ \n        ‡            Till vänster ser du ett skrivbord med en uppslagen karta.             ‡ \n        ‡ Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut... ‡ ";
            room1.Things.Add(new Question("Vilket var den vanligaste typen av mordvapen i Sverige 2022? \nA. Kniv \nB. Pilbåge \nC. Skjutvapen", "c", " Säng", room2));
            room1.Things.Add(new Question("Hur många år i snitt sitter en livstidsdömd person i fängelse i Sverige? \nA. 20 \nB. 16 \nC. 10", "b", " Kamin", room2));
            room1.Things.Add(new DeadEnd("Du ser en låda, du öppnar den, ", " Skrivbordet", room1));

            room2.RoomDescription = "        §        Du tar ett steg in i rummet, där ser du en säng, ett skrivbord och en TV som brusar med myrornas krig.       § \n        §    Under TV:n ser du ett gammalt supernintendo med två kontroller ikopplade och framför TV:n ligger en sackosäck.   § \n        §                    Dörren bakom dig stängs och låser sig. Nu behöver du hitta en annan väg ut...                    § ";
            room2.Things.Add(new Question("Vad heter Supermarios bror? \nA. Ludwig \nB. Pepparoni \nC. Luigi \nD. Bowser", "c", " Supernintendo", room1));
            room2.Things.Add(new Question("Vad har TV-spelsfiguren Pacman för färg? \nA. Grön \nB. Vit \nC. Röd \nD. Gul", "d", " Tv:n", null));
            room2.Things.Add(new Question("Vad heter hjälten i spelen Zelda? \nA. Link \nB. Law \nC. Mario \nD. Hero", "a", " Byrån", room1));
            room2.Things.Add(new BadLuck("Du går till skrivbordet och ser en låda, vill du öppna den?", " Skrivbord", room2));
            room2.Things.Add(new Surprise("Du går till en book, vill du öppna den?", " Bokhylla", room2));

            finalRoom.RoomDescription = "Grattis! Du har klarat av alla frågor och vunnit spelet!";

                switch (input)
                {
                    case "1":
                        int start = Environment.TickCount;
                        while (isLooping)
                        {
                            
                            if(currentRoom == null)
                            {
                                Console.WriteLine("Grattis, du vann!");
                                isLooping = false;
                                fromStart = false;
                            }
                            else if(playerLives == 0)
                            {
                                isLooping = false;          //Ska vi göra såhär eller tillbaka till Play/Exit??
                                fromStart = false;
                            }
                            else
                            {
                                Console.WriteLine(currentRoom.RoomDescription); //Skriver ut rumsbeskrivning

                            for (int i = 0; i < currentRoom.Things.Count; i++)
                                Console.WriteLine(i+1 + "." + currentRoom.Things[i].PathChoice); // Skriver ut vägval

                            int userChoice = int.Parse(Console.ReadLine());
                            
                            Console.WriteLine(currentRoom.Things[userChoice -1].Description); // Skriver ut rätt fråga / beskrivning(dead end)
                            (currentRoom, playerLives) = currentRoom.Things[userChoice -1].Interact(currentRoom, playerLives);  //Går in i Question.Interact och kollar om det är rätt eller fel
                            }
                            //Room.CheckFinalRoom(currentRoom, finalRoom, isLooping); //Vart ska denna ligga?
                        }
                        int total = Environment.TickCount - start;     
                        Console.WriteLine((total/1000) + " sekunder");
                        break;
                    case "2":
                        Console.WriteLine("Hejdå");
                        Console.WriteLine();
                        isLooping = false;
                        fromStart = false;
                        break;
                    default:
                        Console.WriteLine("Men kom igen! Välj en siffra...");
                        break;
                }
                //int total = Environment.TickCount - start;        WHERE DO YOU GO????
                //Console.WriteLine((total/1000) + " sekunder");
            }
        }
    }

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
        ConsoleColor[] consoleColors =(ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor)); 
        /*Console.WriteLine("List of available "+ "Console Colors:"); 
        foreach(var color in consoleColors) 
            Console.WriteLine(color);*/

        bool isLooping = true;
        bool fromStart = true;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("                                 Välkommen!\n\n     Hoppas du kan svara på lite frågor. Du har 5 liv, använd dom väl! \n      Det finns flera rum med olika utmaningar i vardera att klara av. \n                    Varje rum har olika svårighetsgrad. \nDu kommer även stå inför olika val. Se till att välja rätt annars förlorar du. \n                           Tryck enter för att börja.");
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        

        //Börjar med att skriva in sitt namn (Vad gör vi med namnet?) Namnet och tid hänger ihop
        //med samma index. Klass user/highscore
        //Användare med namn och tid (utökad item)
        //Måste vinna för att vara med på highscore-lista

        while (fromStart)
        {
            Console.WriteLine("1. Spela");
            Console.WriteLine("2. Highscore");
            Console.WriteLine("3. Avsluta");
            Console.Write($"Val nr: ");
            string? input = Console.ReadLine();     // Spelaren väljer fråga
            
            Console.WriteLine();

            int playerLives = 5;
            Room room1 = new Room("", new List<Thing>());
            Room room2 = new Room("", new List<Thing>());
            Room room3 = new Room("", new List<Thing>());
            Room room4 = new Room("", new List<Thing>());
            Room currentRoom = room1;
            string item = "Berlock";        //??

            
            room1.RoomDescription = "        --------------------------------------------------------------------------------------\n        ‡                 I rummet ser du en obäddad säng tvärs över rummet.                 ‡ \n        ‡          Till höger ser du en kamin med en blodig handduk hängande på tork.        ‡ \n        ‡             Till vänster ser du ett skrivbord med en uppslagen karta.              ‡ \n        ‡ Dörren bakom dig har slagit igen och låst sig. Du behöver hitta en annan väg ut... ‡ \n        --------------------------------------------------------------------------------------";
            
            room1.Things.Add(new Question("Vilket var den vanligaste typen av mordvapen i Sverige 2022? \nA. Kniv \nB. Pilbåge \nC. Skjutvapen", "c", " Lyft täcket på den obäddade sängen i hörnet", room2));
            room1.Things.Add(new Question("Hur många år i snitt sitter en livstidsdömd person i fängelse i Sverige? \nA. 20 \nB. 16 \nC. 10", "b", " Gå fram till kaminen och peta i elden", room2));
            room1.Things.Add(new DeadEnd("Du ser en låda, du öppnar den, ", " Ta en titt på vad som ligger på skrivbordet", room1));
            room1.Things.Add(new Backpack("Du går fram till en byrå med massa skräp i och ser något blänka till.", " Du ser ett smyckeskrin brevid sängen", room1, "Berlock"));

            
            room2.RoomDescription = "        ----------------------------------------------------------------------------------------\n        §         Du ser en säng, ett skrivbord och en TV som brusar med myrornas krig.        § \n        §       Under TV:n ser du ett gammalt supernintendo med två kontroller ikopplade.      § \n        §                           Framför TV:n ligger en sackosäck.                          § \n        §  Dörren bakom dig har slagit igen och låst sig. Du behöver hitta en annan väg ut...  § \n        ----------------------------------------------------------------------------------------";
            
            room2.Things.Add(new Question("Vad heter Supermarios bror? \nA. Ludwig \nB. Pepparoni \nC. Luigi \nD. Bowser", "c", " Gå fram och kika på Supernintendot.", null));
            room2.Things.Add(new Question("Vad har TV-spelsfiguren Pacman för färg? \nA. Grön \nB. Vit \nC. Röd \nD. Gul", "d", " Starta upp Tv:n.", room3));
            room2.Things.Add(new Question("Vad heter hjälten i spelen Zelda? \nA. Link \nB. Law \nC. Mario \nD. Hero", "a", " Leta igenom byrån.", room3));
            room2.Things.Add(new BadLuck("Du går till anslagstavlan och ser ett födelsedagskort...", " Gå fram till anslagstavlan över skrivbordet", room2));
            room2.Things.Add(new Surprise("Du fasstnar med blicken vid en book, vill du öppna den?", " Gå fram till bokhyllan och se vad det finns för böcker.", room2));
            room2.Things.Add(new Backpack("Du plockar upp den och känner direkt en våg av nostalgi flöda över dig.", " Plocka upp en av spelkontrollerna.", room2, "Supermario-klistermärke"));

            
            room3.RoomDescription = "        ----------------------------------------------------------------------------------------\n        ‡    Du kommer in i ett ganska mörkt rum, upplyst endast av några svaga ljuskällor.    ‡ \n        ‡    Väggarna är täckta med bokhyllor av mörkt trä fyllda med gamla dammiga böcker.    ‡ \n        ‡      Mitt i rummet står en märkligt placerad sekretär som ser ut att vara låst.      ‡ \n        ‡  Det gamla trägolvet knakar under dig när du tar ytterligare några steg in i rummet. ‡  \n        ‡           I ena hörnet står ett litet bord bredvid en sliten skinnfåtölj.            ‡ \n        ‡   Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut...   ‡ \n        ----------------------------------------------------------------------------------------";
            
            room3.Things.Add(new Question("Vad heter Portugals huvudstad? \nA. Barcelona \nB. Lissabon \nC. Ankara \nD. Paris", "b", " Sök igenom en av bokhyllorna till häger om dig.", room4));
            room3.Things.Add(new Question("Vilket år slutade andra världskriget? \nA. 1945 \nB. 1944 \nC. 1918 \nD. 1919", "a", " Gå fram till läshörnan med den slitna fåtöljen och det lilla bordet.", room4));
            room3.Things.Add(new Question("Vem uppfann glödlampan? \nA. Alfred Nobel \nB. Johan Petter Johansson \nC. H.P Lovecraft \nD. Thomas Edison", "d", " Kika närmare på sekretären.", room4));
            room3.Things.Add(new DeadEnd("Du kommer fram till papperskorgen, ", " Ta en titt i papperskorgen bredvid sekretären", room4));
            room3.Things.Add(new Backpack("Du hittar ett gammalt fotoalbum fyllt med foton av vad som ser ut att vara en familj nyss anlända till USA.", " Ta en titt i resten av bokyllorna", room3, "Fotoalbum"));
            room3.Things.Add(new BadLuck("Du snurrar på jordgloben och hör ett kras, globen faller till marken och går sönder...", " Inspektera jordgloben som står i hörnet.", room3));
            room3.Things.Add(new Backpack("När du öppnar locket ser du en skiftnyckel.", " Undersök den gamla kistan som står vid en av bokyllorna.", room3, "Skiftnyckel"));

            
            room4.RoomDescription = "        ------------------------------------------------------------------------------------------------------------------\n        ‡                        Ett svagt upplyst rum tonar fram med sammetsklädda stolar i rader                       ‡ \n        ‡   Väggarna är mörka med ljuddämpande material och tjocka gardiner hänger framför en upplyst duk längst fram.   ‡ \n        ‡                Ett starkt sken kommer från vad du bara antar är en projektor längst bak i rummet               ‡ \n        ‡                      Du hör ljudet knastra till och en nedräkning börjar ticka på filmduken                    ‡  \n        ‡                Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut...                ‡ \n        ------------------------------------------------------------------------------------------------------------------";
            
            room4.Things.Add(new Question("Vad heter skaparen bakom Star Wars-filmerna? \nA. J.R.R Tolkien \nB. Stephen King \nC. George Lukas \nD. George Michael", "c", " Titta klart på nedräkningen.", null));
            room4.Things.Add(new Question("Den amerikanska succé sitcom serien “Vänner” sände sitt sista avsnitt år 2004. Vilket år började serien att sändas? \nA. 1995 \nB. 1994 \nC. 1998 \nD. 1999", "b", " Gå in i projektorrummet och leta vid filmrullarna.", null));
            room4.Things.Add(new Question("Serien om Pippi Långstrump från 1969 spelades in på Gotland. Vad heter Pippis pappa? \nA. Kapten Melker Långstrump \nB. Kapten Anton Långstrump \nC. Kapten Emil Långstrump \nD. Kapten Efraim Långstrump", "d", " Böj dig ner och titta under en av stolarna.", null));
            room4.Things.Add(new Surprise("Du tittar ner och ruskar runt popcornen för att se om det ligger något i botten", " Du ser en halvfull popcornkartong", room4));
            room4.Things.Add(new Backpack("När du öppnar negativfodralet trillar inte en rulle ut utan det singlar ner massa gamla biobiljetter.", " Undersök en plåtlåda som det står KODAK på", room4, "En biobiljett"));


                switch (input)
                {
                    case "1":
                        int start = Environment.TickCount;
                        while (isLooping)
                        {
                            if(currentRoom == null)
                            {
                                Console.WriteLine("Grattis! Du har klarat av alla frågor och vunnit spelet!");
                                Highscore highscoreInstance = new Highscore("", 0, 0);
                                highscoreInstance.Add(start);
                                // Skriv ut hur många items man hittat 
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
                                Console.WriteLine();

                                for (int i = 0; i < currentRoom.Things.Count; i++)
                                    Console.WriteLine(i+1 + "." + currentRoom.Things[i].PathChoice); // Skriver ut vägval
                                
                                Console.WriteLine();
                                Console.Write("Vart vill du leta? ");
                                int userChoice = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                
                                Console.WriteLine(currentRoom.Things[userChoice -1].Description); // Skriver ut rätt fråga / beskrivning(dead end)
                                Console.WriteLine();
                                (currentRoom, playerLives) = currentRoom.Things[userChoice -1].Interact(currentRoom, playerLives, item);  //Går in i Question.Interact och kollar om det är rätt eller fel
                            }
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        Console.WriteLine("Hejdå");
                        Console.WriteLine();
                        isLooping = false;
                        fromStart = false;
                        break;
                    default:
                        Console.WriteLine("Men kom igen! Välj en siffra...");
                        break;
                }
            }
        }
    }

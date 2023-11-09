using System.Globalization;
using Microsoft.VisualBasic;
class Program
{
    static void Main(string[] args)
    {   
        
        int playerLives = 2;
        Room room1 = new Room("", new List<Question>());
        Room room2 = new Room("", new List<Question>());
        Room currentRoom = room1;
        room1.Description = "        ‡        Du kliver in i rummet, där ser du en obäddad säng tvärs över rummet.      ‡ \n        ‡         Till höger ser du en kamin med en blodig handduk hängande på tork.       ‡ \n        ‡            Till vänster ser du ett skrivbord med en uppslagen karta.             ‡ \n        ‡ Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut... ‡ ";
        room1.Questions.Add(new Question("Vilket var den vanligaste typen av mordvapen i Sverige 2022? \nA. Kniv \nB. Pilbåge \nC. Skjutvapen", "c", " Säng", currentRoom));
        room1.Questions.Add(new Question("Hur många år i snitt sitter en livstidsdömd person i fängelse i Sverige? \nA. 20 \nB. 16 \nC. 10", "b", " Kamin", room2));

        room2.Description = "        §        Du tar ett steg in i rummet, där ser du en säng, ett skrivbord och en TV som brusar med myrornas krig.       § \n        §    Under TV:n ser du ett gammalt supernintendo med två kontroller ikopplade och framför TV:n ligger en sackosäck.   § \n        §                    Dörren bakom dig stängs och låser sig. Nu behöver du hitta en annan väg ut...                    § ";
        room2.Questions.Add(new Question("Vad heter Supermarios bror? \nA. Ludwig \nB. Pepparoni \nC. Luigi \nD. Bowser", "c", " Supernintendo", room1));
        room2.Questions.Add(new Question("Vad har TV-spelsfiguren Pacman för färg? \nA. Grön \nB. Vit \nC. Röd \nD. Gul", "d", " Tv:n", room1));
        room2.Questions.Add(new Question("Vad heter hjälten i spelen Zelda? \nA. Link \nB. Law \nC. Mario \nD. Hero", "a", " Byrån", room1));
        room2.Questions.Add(new Question("Du går till skrivbordet och ser en låda, vill du öppna den? j/n?", "j", " Skrivbord", room2));
        
        bool isLooping = true;
        
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Exit");
        string? input = Console.ReadLine(); // Spelaren väljer fråga

        while (isLooping)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine(currentRoom.Description); //Skriver ut rumsbeskrivning
                    for (int i = 0; i < currentRoom.Questions.Count; i++)
                        Console.WriteLine(i+1 + "." + currentRoom.Questions[i].PathChoice); // Skriver ut vägval

                    int userChoice = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(currentRoom.Questions[userChoice -1].QuestionText); // Skriver ut rätt fråga

                    Console.Write("Ditt val: ");
                    string? userAns = Console.ReadLine();
                    if (currentRoom.Questions[userChoice -1].CheckAnswer(userAns.ToLower()) == true) // Kollar om input är korrekt.
                    { 
                        Console.WriteLine();
                        Console.WriteLine("Rätt!");
                        currentRoom = currentRoom.Questions[userChoice -1].NextRoom; // Går vidare till nästa rum
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fel");
                        if (playerLives == 1) //Har du inga liv kvar så är det gameover
                        {
                            Console.WriteLine("GAME OVER!");
                            return;
                        }
                        else
                        {
                            playerLives--;
                            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
                            Console.WriteLine();
                            break;
                        }
                    }
                case "2":
                    Console.WriteLine("Hejdå");
                    isLooping = false;
                    break;
                default:
                    Console.WriteLine("Men kom igen! Välj en siffra...");
                    break;
            }
            // gör nåt med currentRoom - Hur? KLART!
            // skriv ut en lista över alla subroom som går att gå till - lägg till egenskap under Question! KLART!
            // for(blabla) KLART!
            // låt användaren mata in vilket subrom av dessa som den vill gå till med hjälp av index KLART!
            // om användaren klarar detta subroom / frågan i subroom: KLART!
            // sätt om currentRoom till det rummet KLART!
            // Kristers beskrivning: Du går in i ett rum och får en beskrivning av alternativen. Vid varje
            // alternativ finns en fråga (till att börja med), svarar du rätt kommer du in i nästa rum.
            // Då blir currentRoom room2 etc. Sen börjar loopen om!
            // KEEP IT SIMPLE!!!!
        }
    }
}
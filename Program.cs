using System.Globalization;
using Microsoft.VisualBasic;
class Program
{
    public static int playerLives = 5;
    static void Main(string[] args)
    {   
        int playerLives = 5;
        Room room1 = new Room("", new List<Question>());
        Room room2 = new Room("", new List<Question>());
        room1.Description = "        ‡        Du kliver in i rummet, där ser du en obäddad säng tvärs över rummet.      ‡ \n        ‡         Till höger ser du en kamin med en blodig handduk hängande på tork.       ‡ \n        ‡            Till vänster ser du ett skrivbord med en uppslagen karta.             ‡ \n        ‡ Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut... ‡ ";
        room1.Questions.Add(new Question("Vilket var den vanligaste typen av mordvapen i Sverige 2022? \nA. Kniv \nB. Pilbåge \nC. Skjutvapen", "c", " Säng", room2));
        room1.Questions.Add(new Question("Hur många år i snitt sitter en livstidsdömd person i fängelse i Sverige? \nA. 20 \nB. 16 \nC. 10", "b", " Kamin", room2));

        room2.Description = "        §        Du tar ett steg in i rummet, där ser du en säng, ett skrivbord och en TV som brusar med myrornas krig.       § \n        §    Under TV:n ser du ett gammalt supernintendo med två kontroller ikopplade och framför TV:n ligger en sackosäck.   § \n        §                    Dörren bakom dig stängs och låser sig. Nu behöver du hitta en annan väg ut...                    § ";
        room2.Questions.Add(new Question("Vad heter Supermarios bror? \nA. Ludwig \nB. Pepparoni \nC. Luigi \nD. Bowser", "c", " Supernintendo", room1));
        room2.Questions.Add(new Question("Vad har TV-spelsfiguren Pacman för färg? \nA. Grön \nB. Vit \nC. Röd \nD. Gul", "d", "Tv:n", room1));
        room2.Questions.Add(new Question("Vad heter hjälten i spelen Zelda? \nA. Link \nB. Law \nC. Mario \nD. Hero", "a", "Byrån", room1));
        
        bool isLooping = true;
        Room currentRoom = room1;
        
        while (isLooping)
        {
            Console.WriteLine(currentRoom.Description);
            for (int i = 0; i < currentRoom.Questions.Count; i++)
                Console.WriteLine(i+1 + "." + currentRoom.Questions[i].PathChoice);

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine(currentRoom.Questions[0].QuestionText);
                    Console.Write("Ditt val: ");
                        string? userAns = Console.ReadLine();
                        if (currentRoom.Questions[0].CheckAnswer(userAns.ToLower()) == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Rätt!");
                            currentRoom = currentRoom.Questions[0].NextRoom;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Fel");
                            playerLives--;
                            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
                            Console.WriteLine();
                            break;
                        }
                default:
                    Console.WriteLine("Men kom igen! Svara 1, 2 eller 3!");
                    break;
            }
            // gör nåt med currentRoom - Hur?
            // skriv ut en lista över alla subroom som går att gå till - lägg till egenskap under Question!
            // for(blabla)
            // låt användaren mata in vilket subrom av dessa som den vill gå till med hjälp av index
            // om användaren klarar detta subroom / frågan i subroom:
            // sätt om currentRoom till det rummet
            // Kristers beskrivning: Du går in i ett rum och får en beskrivning av alternativen. Vid varje
            // alternativ finns en fråga (till att börja med), svarar du rätt kommer du in i nästa rum.
            // Då blir currentRoom room2 etc. Sen börjar loopen om!
            // KEEP IT SIMPLE!!!!
        }
    }
}
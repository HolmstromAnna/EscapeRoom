using System.Globalization;
using Microsoft.VisualBasic;
class Program
{
    public static int playerLives = 5;
    //static List <Question> questions = new List<Question>();
    //static List<Question> pathChoices = new List<Question>();
    
    static void Main(string[] args)
    {   
        int playerLives = 5;
        Room room1 = new Room("", new List<Question>(), new List<Question>());
        room1.Description = "        ‡        Du kliver in i rummet, där ser du en obäddad säng tvärs över rummet.      ‡ \n        ‡         Till höger ser du en kamin med en blodig handduk hängande på tork.       ‡ \n        ‡            Till vänster ser du ett skrivbord med en uppslagen karta.             ‡ \n        ‡ Dörren bakom dig slår igen och låser sig. Nu behöver du hitta en annan väg ut... ‡ ";
        room1.Questions.Add(new Question("Vilket var den vanligaste typen av mordvapen i Sverige 2022? \nA. Kniv \nB. Pilbåge \nC. Skjutvapen", "c", " Säng"));
        room1.Questions.Add(new Question("Hur många år i snitt sitter en livstidsdömd person i fängelse i Sverige? \nA. 20 \nB. 16 \nC. 10", "b", " Kamin"));

        bool isLooping = true;
        Room currentRoom = room1;

        Console.WriteLine(currentRoom.Description);
        while (isLooping)
        {
        
        for (int i = 0; i < currentRoom.Questions.Count; i++)
            Console.WriteLine((i+1) + "." + currentRoom.Questions[i].PathChoice);

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
                            //currentRoom = Question.nextRoom; 
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Fel");
                            playerLives--;
                            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
                            Console.WriteLine();
                            break;
                        }
                        Console.ReadLine();
                case "2":
                    Console.WriteLine(currentRoom.Questions[1].QuestionText);
                    Console.Write("Ditt val: ");
                        string? userAnsw = Console.ReadLine();
                        if (currentRoom.Questions[1].CheckAnswer(userAnsw.ToLower()) == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Rätt!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Fel");
                            playerLives--;
                            Console.WriteLine($"Du har nu {playerLives} liv kvar...");
                            Console.WriteLine();
                            break;
                        }
                        Console.ReadLine();
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
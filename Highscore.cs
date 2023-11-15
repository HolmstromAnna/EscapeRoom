public class Highscore
{
    public string UserName;
    public int FinalMinutes; 
    public int FinalSeconds;
    List <Highscore> Highscores;

    public Highscore(string userName, int minutes, int seconds)
    {
        UserName = userName;
        FinalMinutes = minutes;
        FinalSeconds = seconds;
        
        Highscores = new List<Highscore>(3);
    }
    public void Adds(int start)
    {
        int totalMillisec = Environment.TickCount - start; 
        int totalSeconds = totalMillisec / 1000;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        Console.WriteLine();
        Console.WriteLine($"Din tid: {minutes} minuter {seconds} sekunder"); 
        Console.Write("Skriv in ditt namn: ");
        UserName = Console.ReadLine();
        
        Highscore newHighscore = new Highscore(UserName, minutes, seconds);
        Highscores.Add(newHighscore);

        Highscores.Sort((x, y) =>
        {
            // Jämför först efter FinalMinutes
            int compareMinutes = x.FinalMinutes.CompareTo(y.FinalMinutes);
            if (compareMinutes != 0)
            {
                return compareMinutes;
            }

            // Om FinalMinutes är lika, jämför efter FinalSeconds
            return x.FinalSeconds.CompareTo(y.FinalSeconds);
        });
        if (Highscores.Count > 3)
        {
            Highscores.RemoveAt(3);
        }

        for (int i = 0; i < Highscores.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Användare: {Highscores[i].UserName}. Minuter: {Highscores[i].FinalMinutes}. Sekunder: {Highscores[i].FinalSeconds}");
            Console.WriteLine();
        }
        //Tillbaka till menyn
    }
    public void Print()
    {
        Highscore newHighscore = new Highscore("sandra", 1, 10);
        Highscores.Add(newHighscore);
        newHighscore = new Highscore("Anna", 0, 10);
        Highscores.Add(newHighscore);
        newHighscore = new Highscore("Louise", 2, 10);
        Highscores.Add(newHighscore);

        Highscores.Sort((x, y) =>
        {
            // Jämför först efter FinalMinutes
            int compareMinutes = x.FinalMinutes.CompareTo(y.FinalMinutes);
            if (compareMinutes != 0)
            {
                return compareMinutes;
            }

            // Om FinalMinutes är lika, jämför efter FinalSeconds
            return x.FinalSeconds.CompareTo(y.FinalSeconds);
        });
        //Tar bort så att det bara ligger tre i listan
        if (Highscores.Count > 3)
        {
            Highscores.RemoveAt(3);
        }
        //Skriver ut listan
        for (int i = 0; i < Highscores.Count; i++)
        {
            Console.WriteLine($"{i+1}:a plats: {Highscores[i].UserName}, Minuter: {Highscores[i].FinalMinutes}. Sekunder: {Highscores[i].FinalSeconds}");
            Console.WriteLine();
        }
    }
}
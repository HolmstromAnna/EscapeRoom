using System.Text.Json;
public class Highscore
{
    public string UserName;
    public int FinalMinutes; 
    public int FinalSeconds;
    List <Highscore> Highscores;

    public Highscore(string userName, int finalMinutes, int finalSeconds)
    {
        UserName = userName;
        FinalMinutes = finalMinutes;
        FinalSeconds = finalSeconds;
        Highscores = new List<Highscore>();
    }
    public void Adds(int start)
    {
        int totalMillisec = Environment.TickCount - start; 
        int totalSeconds = totalMillisec / 1000;
        FinalMinutes = totalSeconds / 60;
        FinalSeconds = totalSeconds % 60;

        Console.WriteLine();
        Console.WriteLine($"Tid: {FinalMinutes} minuter {FinalSeconds} sekunder"); 
        Console.Write("Skriv in ditt namn: ");
        UserName = Console.ReadLine();
        
        Highscore newScore = new Highscore(UserName, FinalMinutes, FinalSeconds);
        Highscores.Add(newScore);

       // string strJson = JsonSerializer.Serialize(Highscores, new JsonSerializerOptions { WriteIndented = true });
       // File.WriteAllText("highscores.json", strJson);

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
            Console.WriteLine($"{Highscores[i].UserName} Tid: {Highscores[i].FinalMinutes} minuter {Highscores[i].FinalSeconds} sekunder");
            Console.WriteLine();
        }
        //Tillbaka till menyn
    }
    public void Print()
    {
       // string strJson = File.ReadAllText("highscores.json");
       // List<Highscore> Highscores;
       // Highscores = JsonSerializer.Deserialize<List<Highscore>>(strJson);

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
            Console.WriteLine($"{i+1}:a plats: {Highscores[i].UserName}, Tid: {Highscores[i].FinalMinutes} minuter {Highscores[i].FinalSeconds} sekunder");
            Console.WriteLine();
        }
    }
}
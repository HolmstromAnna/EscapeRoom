using System.Text.Json;
public class Highscore
{
    public string UserName { get; set; } 
    public int FinalMinutes { get; set; }
    public int FinalSeconds { get; set; }

    public Highscore(string userName, int finalMinutes, int finalSeconds)
    {
        UserName = userName;
        FinalMinutes = finalMinutes;
        FinalSeconds = finalSeconds;
    }
}
public class HighscoreManager
{
    public List<Highscore> Highscores { get; set; } = new List<Highscore>();
    public void Adds(int start)
    {
        int totalMillisec = Environment.TickCount - start; 
        int totalSeconds = totalMillisec / 1000;
        int FinalMinutes = totalSeconds / 60;
        int FinalSeconds = totalSeconds % 60;

        Console.WriteLine();
        Console.WriteLine($"Tid: {FinalMinutes} minuter {FinalSeconds} sekunder"); 
        Console.Write("Skriv in ditt namn: ");
        string UserName = Console.ReadLine();
           
        Highscore newScore = new Highscore(UserName, FinalMinutes, FinalSeconds);
        Highscores.Add(newScore);
 
         // Läs in befintliga highscores från filen
        List<Highscore> existingHighscores = LoadHighscores();

        // Lägg till det nya highscore-objektet
        existingHighscores.Add(newScore);

        // Skriv hela listan tillbaka till filen
        SaveHighscores(existingHighscores);
    }
    
    private List<Highscore> LoadHighscores()
    {
        string strJson = File.ReadAllText("highscores.json");
        return JsonSerializer.Deserialize<List<Highscore>>(strJson) ?? new List<Highscore>();
    }

    private void SaveHighscores(List<Highscore> highscores)
    {
        string strJson = JsonSerializer.Serialize(highscores, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("highscores.json", strJson);
    }  

    public void Print()
    {
        string strJson = File.ReadAllText("highscores.json");
        Highscores = JsonSerializer.Deserialize<List<Highscore>>(strJson) ?? new List<Highscore>();

        Highscores = Highscores.OrderBy(h => h.FinalMinutes * 60 + h.FinalSeconds).ToList();
        Console.WriteLine("-------------Highscore-------------");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{Highscores[i].UserName} - Tid: {Highscores[i].FinalMinutes} minuter {Highscores[i].FinalSeconds} sekunder");
        }
    }
    
}
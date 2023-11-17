using System.Text.Json;
public class Highscore
{
    public string? UserName { get; set; } 
    public int FinalMinutes { get; set; }
    public int FinalSeconds { get; set; }

    public Highscore(string? userName, int finalMinutes, int finalSeconds)
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
        int totalMillisec = Environment.TickCount - start; //Räknar ut stopptid mot starttid för att få fram totaltid i  millisekunder.
        int totalSeconds = totalMillisec / 1000;          //Gör om millisekunder till sekunder
        int FinalMinutes = totalSeconds / 60;            //Räknar om sekunder till minuter
        int FinalSeconds = totalSeconds % 60;           //Kollar hur många sekunder som blir över

        Console.WriteLine();
        Console.WriteLine($"Tid: {FinalMinutes} minuter {FinalSeconds} sekunder"); 
        Console.Write("Skriv in ditt namn: ");
        string? UserName = Console.ReadLine();
           
        Highscore newScore = new Highscore(UserName, FinalMinutes, FinalSeconds);
        Highscores.Add(newScore);
 
        //Hämtar highscores från filen
        List<Highscore> existingHighscores = LoadHighscores();

        //Lägger till det nya highscoret i filen
        existingHighscores.Add(newScore);

        //Skriver tillbaka den nya listan till filen
        SaveHighscores(existingHighscores);
    }
    
    private List<Highscore> LoadHighscores() //Hämtar info från json
    {
        string strJson = File.ReadAllText("highscores.json");
        return JsonSerializer.Deserialize<List<Highscore>>(strJson) ?? new List<Highscore>();
    }

    private void SaveHighscores(List<Highscore> highscores) //Skriver över med ny info
    {
        string strJson = JsonSerializer.Serialize(highscores, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("highscores.json", strJson);
    }  

    public void Print() 
    {
        string strJson = File.ReadAllText("highscores.json");
        Highscores = JsonSerializer.Deserialize<List<Highscore>>(strJson) ?? new List<Highscore>();

        Highscores = Highscores.OrderBy(h => h.FinalMinutes * 60 + h.FinalSeconds).ToList(); //Minuter * 60 ger sekunder + resten av sekunderna. Listan sorteras i storleksordning efter det.
        Console.WriteLine("-----------------Highscore-----------------");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{i+1}:a {Highscores[i].UserName} - Tid: {Highscores[i].FinalMinutes} minuter {Highscores[i].FinalSeconds} sekunder");
        }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
    }
}
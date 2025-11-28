using System.Text.Json;
using BudgetTracker.Models;

namespace BudgetTracker.Data;

public static class FileStorage // static?
{
    private const string FilePath="Storage/TransactionRecord.json";

    public static void Save(List<Transaction> list)
    {
        try
        {
            var json=JsonSerializer.Serialize(list, new JsonSerializerOptions{ WriteIndented=true});
            
            var dir=Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(FilePath, json);   
            Console.WriteLine("Successfully Save the data to File!");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"""
            Failed to Save to File: {ex.Message},
            Please try again!
            """);
        }
    }

    public static List<Transaction> Load()
    {
        if(!File.Exists(FilePath))
            return new List<Transaction>();
        var json=File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
    }

}
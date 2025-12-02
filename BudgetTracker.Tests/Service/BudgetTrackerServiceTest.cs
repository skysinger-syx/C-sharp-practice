using BudgetTracker.Service;
using Xunit;
using BudgetTracker.Models;

namespace BudgetTracker.Tests.Service;

public class BudgetTrackerServiceTest
{
    [Fact]
    public void CheckAllTransactions_ShouldPrintAllItems()
    {
        // Arrange
        BudgetTrackerService.list = new List<Transaction>
        {
            new Transaction ("Food", 10, "Lunch", new DateTime(2024, 1, 1, 8, 0, 0) ),
            new Transaction ("Rent", 2000, "Monthly Rent", new DateTime(2025, 3, 24, 8, 0, 0) )
        };

        var stringWriter = new StringWriter();
        var originalOut = Console.Out;
        Console.SetOut(stringWriter);   

        // Act
        BudgetTrackerService.CheckAllTransactions();

        // Assert
        var output = stringWriter.ToString();
        
        Assert.Contains("Food 10 Lunch 1/1/2024 8:00:00 AM", output);
        Assert.Contains("Rent 2000 Monthly Rent 3/24/2025 8:00:00 AM", output);

        BudgetTrackerService.list.Clear();
        Console.SetOut(originalOut);
    }
}
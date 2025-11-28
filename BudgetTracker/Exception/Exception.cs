namespace BudgetTracker.Exceptions;

public class BudgetTrackerException : Exception
{
    public BudgetTrackerException(string message): base(message)
    {
        Console.WriteLine("This is a Budget Tracker Exception!");
    }
}
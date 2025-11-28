// See https://aka.ms/new-console-template for more information

using BudgetTracker.Service;


class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to use personal budget management tool!\n");
        while (true)
        {
            BudgetTrackerService.ShowMenu();
            var choice=Console.ReadLine()?.Trim();
            switch (choice)
            {
                case "1": BudgetTrackerService.AddTransaction(); break;
                case "2": BudgetTrackerService.CheckAllTransactions(); break;
                case "3": BudgetTrackerService.ShowSummary(); break;
                case "4": BudgetTrackerService.SaveToFile(); break;
                case "5": BudgetTrackerService.LoadToSystem(); break;
                case "0": return;
                default: Console.WriteLine("Doesn't exist this choice, please choose again!"); break;
            }
        }
    }
}


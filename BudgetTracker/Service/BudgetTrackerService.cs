using BudgetTracker.Data;
using BudgetTracker.Models;
using BudgetTracker.Exceptions;

namespace BudgetTracker.Service;
public static class BudgetTrackerService
{
    public static List<Transaction> list=new List<Transaction>();
    public static void ShowMenu()
    {
        var menu="""
        -----------------------------
        1: add a transaction to system
        2: check all transactions in system
        3: check total income, total expense and balance
        4: save transactions from system to file
        5: load transactions from file to system 
        0: exit the system
        -----------------------------
        
        """;
        Console.WriteLine(menu);
    }

    public static void AddTransaction()
    {
        try
        {
            Console.WriteLine("Please input the string type (income/expense):");
            var type=Console.ReadLine()?.Trim();
            if(type!="income" && type != "expense")
            {
                throw new BudgetTrackerException($"type={type}, Bad input type!");
            }            

            Console.WriteLine("Please input the Amount:");
            var amount=Console.ReadLine()?.Trim();
            decimal value;
            if(!decimal.TryParse(amount, out value))
            {
                throw new BudgetTrackerException($"amount={value}, Bad input amount!");
            }

            Console.WriteLine("Please input the Message(note):");
            var message=Console.ReadLine()?.Trim();
            Transaction x=new Transaction(
                Type: type,
                Amount: value,
                Message: message,
                Timestamp: DateTime.Now
            );
            list.Add(x);
            Console.WriteLine("Transaction successfully been added to system!");
        }
        catch (BudgetTrackerException ex)
        {
            Console.WriteLine($"""
            Exception: {ex.Message},
            Please try again!
            """);
        }


    }

    public static void CheckAllTransactions()
    {
        foreach(var transaction in list)
        {
            Console.WriteLine($"{transaction.Type} {transaction.Amount} {transaction.Message} {transaction.Timestamp}");
        }
    }

    public static void ShowSummary()
    {
        decimal totalIncome=0m,totalExpense=0m;
        foreach(var transaction in list)
        {
            if (transaction.Type == "income")
            {
                totalIncome+=transaction.Amount;
            }
            else
            {
                totalExpense+=transaction.Amount;
            }
        }
        Console.WriteLine($"Total Income: {totalIncome}, Total Expense; {totalExpense}, Balance: {totalIncome-totalExpense}\n");
    }
    public static void SaveToFile()
    {
        FileStorage.Save(list);
    }

    public static void LoadToSystem()
    {
        List<Transaction> templist=FileStorage.Load();
        for(int i = templist.Count - 1; i >= 0; i--)
        {
            list.Insert(0, templist[i]);
        }
        Console.WriteLine("Successfully Loaded all transactions from file to System!\n");
    }
}
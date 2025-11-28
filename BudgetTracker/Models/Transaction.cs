namespace BudgetTracker.Models;

public record Transaction(
    string Type,   // income/expense
    decimal Amount, 
    string? Message,
    DateTime Timestamp
);
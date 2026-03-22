public class Transaction
{
    public string Type { get; } // Deposit, Withdraw, Transfer
    public decimal Amount { get; }
    public string? SourceAccountNumber { get; } // Only for transfers
    public string? TargetAccountNumber { get; } // Only for transfers

    public Transaction(string type, decimal amount, string? sourceAccountNumber = null, string? targetAccountNumber = null)
    {
        Type = type;
        Amount = amount;
        SourceAccountNumber = sourceAccountNumber;
        TargetAccountNumber = targetAccountNumber;
    }

    public override string ToString()
    {
        if (Type == "Transfer")
        {
            return $"Transfer {Amount} from {SourceAccountNumber} to {TargetAccountNumber}";
        }
        else if (Type == "Deposit")
        {
            return $"Deposit {Amount}";
        }
        else if (Type == "Withdraw")
        {
            return $"Withdraw {Amount}";
        }
        return $"{Type} {Amount}";
    }
}
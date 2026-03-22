using System;
using System.Collections.Generic;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; private set; }
    private List<Transaction> _transactions = new();
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public BankAccount(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        Balance += amount;
        _transactions.Add(new Transaction("Deposit", amount));
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        if (Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        Balance -= amount;
        _transactions.Add(new Transaction("Withdraw", amount)); 
    }
    public void Transfer(BankAccount targetAccount, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }
        if (Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        this.Withdraw(amount);
        targetAccount.Deposit(amount);

        //Record Transaction
        var transaction = new Transaction("Transfer", amount, this.AccountNumber, targetAccount.AccountNumber);
        _transactions.Add(transaction);
        targetAccount._transactions.Add(transaction);
    }    
}
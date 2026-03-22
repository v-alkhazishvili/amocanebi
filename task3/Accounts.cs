using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;

public class Accounts
{
    private Dictionary<string, BankAccount> _accounts = new();
    //indexer
    public BankAccount this[string accountNumber]
    {
        get => _accounts.TryGetValue(accountNumber  , out var acc) ? acc : null;
        set => _accounts[accountNumber] = value;
    }     
    // public void WriteJson()
    // {
    //     string json = System.Text.Json.JsonSerializer.Serialize(_accounts);
    //     File.WriteAllText("accounts.json", json);        
    // }
    public void AddAccount(BankAccount account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account));

        if (_accounts.ContainsKey(account.AccountNumber))
            throw new InvalidOperationException("Account already exists");

        _accounts.Add(account.AccountNumber, account);
        //WriteJson();
    }
        public bool RemoveAccount(string accountNumber)
    {   
        bool removed = _accounts.Remove(accountNumber);
        // if (removed) 
        // {
        //     WriteJson();
        // }
        return removed;
    }

    public bool TryGetAccount(string accountNumber, out BankAccount account)
    {
        return _accounts.TryGetValue(accountNumber, out account);
    }
    public IEnumerable<BankAccount> GetAllAccounts()
    {
        return _accounts.Values;
    }
    public IReadOnlyList<Transaction> GetTransactions(string accountNumber)
    {
        if (!_accounts.TryGetValue(accountNumber, out var account))
        {   
            throw new ArgumentException("Account not found");
        }
        return account.Transactions;
    }
    public string GetTransactionsString(string accountNumber)
    {
        var transactions = this.GetTransactions(accountNumber);
        if (transactions.Count == 0)
        {
            return "No transactions found.";
        }
        return string.Join("\n", transactions);
    }
}
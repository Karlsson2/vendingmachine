namespace VendingMachinev1;

public class Bank
{
    public List<Account> Accounts { get; }

    public Bank()
    {
        Accounts = new List<Account>(); 
    }

    public bool DoesAccountExist(Account account)
    {
        return Accounts.Any(acc => acc.Equals(account));
    }
}
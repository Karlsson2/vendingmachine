namespace VendingMachinev1;

public class Bank
{
    public List<Account> Accounts { get; }

    public Bank()
    {
        Accounts = new List<Account>(); 
    }
}
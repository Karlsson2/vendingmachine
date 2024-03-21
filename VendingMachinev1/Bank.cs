namespace VendingMachinev1;
//this class ended up being kinda useless, didnt need the "authentication" of wheather an account existed or not
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
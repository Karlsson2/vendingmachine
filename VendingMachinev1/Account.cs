namespace VendingMachinev1;

public class Account
{
    private int _balance;
    private string _accountnr;

    public Account( int balance, string accountnr)
    {
        _balance = balance;
        _accountnr = accountnr;
    }

    public int CheckBalance()
    {
        return _balance;
    }

    public bool DeductFromBalance(int cost)
    {
        if (CheckBalance() >= cost)
        {
            _balance -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }
}
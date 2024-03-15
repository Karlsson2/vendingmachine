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

    public void CheckBalance()
    {
    }

    public void DeductFromBalance()
    {
    }
}
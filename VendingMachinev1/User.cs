namespace VendingMachinev1;

public class User
{
    public string Name { get; set; }
    public Account Account{ get; }
    public Inventory Inventory { get; }

    public User(string name, Account account, Inventory inventory)
    {
        Name = name;
        Account = account;
        Inventory = inventory;
    }
    
}
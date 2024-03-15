namespace VendingMachinev1;

public class Inventory
{
    public List<Product> UserProducts { get; }

    public void AddToInventory(Product product)
    {
        UserProducts.Add(product);
    }
    public void RemoveFromInventory(Product product)
    {
        UserProducts.Remove(product);
    }
}
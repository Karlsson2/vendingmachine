namespace VendingMachinev1;

public class Inventory
{
    public List<Product> UserProducts { get; }

    public Inventory()
    {
        UserProducts = new List<Product>(); 
    }

    public void AddToInventory(Product product)
    {
        UserProducts.Add(product);
    }
    public void RemoveFromInventory(Product product)
    {
        UserProducts.Remove(product);
    }

    public int GetTotalofInventory()
    {
        var total = 0;
        foreach (var Product in UserProducts)
        {
            total += Product.Price;
        }
        return total;
    }

    public void DisplayInventory()
    {
        foreach (var product in UserProducts)
        {
            Console.WriteLine(product.Name);
        }
    }

}
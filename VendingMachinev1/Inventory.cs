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
    public void RemoveFromInventory(int index)
    {
        if (index >= 0 && index < UserProducts.Count)
        {
            UserProducts.RemoveAt(index);
        }
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
        var counter = 1;
        foreach (var product in UserProducts)
        {
            Console.WriteLine($"{counter}. {product.Name}");
            counter++;
        }
    }

    public void EmptyInventory()
    {
      UserProducts.Clear();  
    }

}
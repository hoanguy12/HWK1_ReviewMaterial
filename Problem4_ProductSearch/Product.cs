public class Product
{
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool InStock { get; set; }

    public Product(
        string productName,
        string category,
        double price,
        bool inStock)
    {
        ProductName = productName;
        Category = category;
        Price = price;
        InStock = inStock;
    }
}
List<Product> products = new List<Product>
{
    new Product("Laptop", "Electronics", 899.99, true),
    new Product("Keyboard", "Electronics", 49.99, true),
    new Product("Mouse", "Electronics", 29.99, false),
    new Product("Monitor", "Electronics", 249.99, true),
    new Product("Desk Chair", "Furniture", 179.99, true),
    new Product("Desk", "Furniture", 249.99, false),
    new Product("Coffee Maker", "Kitchen", 79.99, true),
    new Product("Blender", "Kitchen", 59.99, true),
    new Product("Running Shoes", "Clothing", 89.99, true),
    new Product("Jacket", "Clothing", 119.99, false)
};

bool isRunning = true;

Console.WriteLine("PRODUCT SEARCH AND FILTER");
Console.WriteLine("-------------------------");

while (isRunning)
{
    DisplayMenu();

    Console.Write("Select an option (1-6): ");
    string input = Console.ReadLine() ?? "";

    if (!int.TryParse(input, out int menuChoice))
    {
        Console.WriteLine("Please enter a valid number.");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine();

    switch (menuChoice)
    {
        case 1:
            Console.WriteLine("ALL PRODUCTS");
            DisplayProducts(products);
            break;

        case 2:
            Console.Write("Enter a product name to search for: ");
            string searchTerm = Console.ReadLine() ?? "";
            SearchProducts(products, searchTerm);
            break;

        case 3:
            Console.Write("Enter a category: ");
            string category = Console.ReadLine() ?? "";
            FilterByCategory(products, category);
            break;

        case 4:
            Console.Write("Enter the maximum price: $");
            string priceInput = Console.ReadLine() ?? "";

            if (double.TryParse(priceInput, out double maximumPrice)
                && maximumPrice >= 0)
            {
                FilterByPrice(products, maximumPrice);
            }
            else
            {
                Console.WriteLine("Please enter a valid maximum price.");
            }

            break;

        case 5:
            ShowInStockProducts(products);
            break;

        case 6:
            isRunning = false;
            Console.WriteLine("Thank you for using the product search.");
            break;

        default:
            Console.WriteLine("Please select an option from 1 through 6.");
            break;
    }

    Console.WriteLine();
}

static void DisplayMenu()
{
    Console.WriteLine("1 - View all products");
    Console.WriteLine("2 - Search products by name");
    Console.WriteLine("3 - Filter products by category");
    Console.WriteLine("4 - Filter products by maximum price");
    Console.WriteLine("5 - Show only products currently in stock");
    Console.WriteLine("6 - Exit");
    Console.WriteLine();
}

static void DisplayProducts(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("No matching products were found.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine(
        $"{"Product",-20} {"Category",-15} {"Price",-12} {"In Stock"}");
    Console.WriteLine(
        "------------------------------------------------------------");

    foreach (Product product in products)
    {
        string stockStatus = product.InStock ? "Yes" : "No";

        Console.WriteLine(
            $"{product.ProductName,-20} " +
            $"{product.Category,-15} " +
            $"{product.Price,-12:C} " +
            $"{stockStatus}");
    }
}

static void SearchProducts(
    List<Product> products,
    string searchTerm)
{
    List<Product> matchingProducts = new List<Product>();

    foreach (Product product in products)
    {
        if (product.ProductName.Contains(
            searchTerm,
            StringComparison.OrdinalIgnoreCase))
        {
            matchingProducts.Add(product);
        }
    }

    Console.WriteLine($"SEARCH RESULTS FOR \"{searchTerm}\"");
    DisplayProducts(matchingProducts);
}

static void FilterByCategory(
    List<Product> products,
    string category)
{
    List<Product> matchingProducts = new List<Product>();

    foreach (Product product in products)
    {
        if (product.Category.Equals(
            category,
            StringComparison.OrdinalIgnoreCase))
        {
            matchingProducts.Add(product);
        }
    }

    Console.WriteLine($"PRODUCTS IN {category.ToUpper()}");
    DisplayProducts(matchingProducts);
}

static void FilterByPrice(
    List<Product> products,
    double maximumPrice)
{
    List<Product> matchingProducts = new List<Product>();

    foreach (Product product in products)
    {
        if (product.Price <= maximumPrice)
        {
            matchingProducts.Add(product);
        }
    }

    Console.WriteLine($"PRODUCTS COSTING {maximumPrice:C} OR LESS");
    DisplayProducts(matchingProducts);
}

static void ShowInStockProducts(List<Product> products)
{
    List<Product> matchingProducts = new List<Product>();

    foreach (Product product in products)
    {
        if (product.InStock)
        {
            matchingProducts.Add(product);
        }
    }
    
    Console.WriteLine("PRODUCTS CURRENTLY IN STOCK");
    DisplayProducts(matchingProducts);
}
//elvis hoang
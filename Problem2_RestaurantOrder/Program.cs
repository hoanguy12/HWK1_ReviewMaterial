List<string> orderedItems = new List<string>();

Console.WriteLine("RESTAURANT ORDER");
Console.WriteLine("----------------");

bool isOrdering = true;

while (isOrdering)
{
    DisplayMenu();

    Console.Write("Select an item (0-5): ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int selection))
    {
        Console.WriteLine("Invalid selection. Please enter a number.");
        Console.WriteLine();
        continue;
    }

    if (selection == 0)
    {
        isOrdering = false;
    }
    else if (AddItem(orderedItems, selection))
    {
        Console.WriteLine("Item added to your order.");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Invalid menu selection.");
        Console.WriteLine();
    }
}

double subtotal = CalculateSubtotal(orderedItems);
double finalTotal = CalculateFinalTotal(
    subtotal,
    out double discount,
    out double tax);

Console.WriteLine();
Console.WriteLine("ORDER SUMMARY");
Console.WriteLine("----------------");

if (orderedItems.Count == 0)
{
    Console.WriteLine("No items were ordered.");
}
else
{
    foreach (string item in orderedItems)
    {
        Console.WriteLine($"{item,-20} {GetItemPrice(item):C}");
    }
}

Console.WriteLine("----------------");
Console.WriteLine($"Subtotal:          {subtotal:C}");
Console.WriteLine($"Discount:         -{discount:C}");
Console.WriteLine($"Tax:               {tax:C}");
Console.WriteLine($"Final total:       {finalTotal:C}");

static void DisplayMenu()
{
    Console.WriteLine("MENU");
    Console.WriteLine("1 - Burger             $10.99");
    Console.WriteLine("2 - Chicken Sandwich    $9.99");
    Console.WriteLine("3 - Salad               $8.49");
    Console.WriteLine("4 - Fries               $3.49");
    Console.WriteLine("5 - Drink               $2.49");
    Console.WriteLine("0 - Finish Order");
    Console.WriteLine();
}

static bool AddItem(List<string> orderedItems, int selection)
{
    if (selection == 1)
    {
        orderedItems.Add("Burger");
    }
    else if (selection == 2)
    {
        orderedItems.Add("Chicken Sandwich");
    }
    else if (selection == 3)
    {
        orderedItems.Add("Salad");
    }
    else if (selection == 4)
    {
        orderedItems.Add("Fries");
    }
    else if (selection == 5)
    {
        orderedItems.Add("Drink");
    }
    else
    {
        return false;
    }

    return true;
}

static double CalculateSubtotal(List<string> orderedItems)
{
    double subtotal = 0;

    foreach (string item in orderedItems)
    {
        subtotal += GetItemPrice(item);
    }

    return subtotal;
}

static double CalculateFinalTotal(
    double subtotal,
    out double discount,
    out double tax)
{
    if (subtotal >= 30)
    {
        discount = subtotal * 0.10;
    }
    else
    {
        discount = 0;
    }

    double discountedSubtotal = subtotal - discount;
    tax = discountedSubtotal * 0.085;

    return discountedSubtotal + tax;
}

static double GetItemPrice(string item)
{
    if (item == "Burger")
    {
        return 10.99;
    }
    else if (item == "Chicken Sandwich")
    {
        return 9.99;
    }
    else if (item == "Salad")
    {
        return 8.49;
    }
    else if (item == "Fries")
    {
        return 3.49;
    }
    else if (item == "Drink")
    {
        return 2.49;
    }
    else
    {
        return 0;
    }
}
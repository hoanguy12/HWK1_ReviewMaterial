Console.WriteLine("SHIPPING CALCULATOR");
Console.WriteLine("-------------------");

double orderSubtotal;

Console.Write("Enter the order subtotal: $");

while (!double.TryParse(Console.ReadLine(), out orderSubtotal)
       || orderSubtotal <= 0)
{
    Console.Write("Invalid amount. Enter a subtotal greater than $0: $");
}

string rewardsInput;

do
{
    Console.Write("Are you a rewards member? (Y/N): ");
    rewardsInput = Console.ReadLine().Trim().ToUpper();

    if (rewardsInput != "Y" && rewardsInput != "N")
    {
        Console.WriteLine("Please enter Y or N.");
    }

} while (rewardsInput != "Y" && rewardsInput != "N");

bool isRewardsMember = rewardsInput == "Y";

Console.WriteLine();
Console.WriteLine("Shipping Methods");
Console.WriteLine("1 - Standard ($5.99)");
Console.WriteLine("2 - Two-Day ($12.99)");
Console.WriteLine("3 - Overnight ($24.99)");

int shippingMethod;

Console.Write("Select a shipping method (1-3): ");

while (!int.TryParse(Console.ReadLine(), out shippingMethod)
       || shippingMethod < 1
       || shippingMethod > 3)
{
    Console.Write("Invalid selection. Enter 1, 2, or 3: ");
}

double shippingCharge = CalculateShipping(
    orderSubtotal,
    shippingMethod,
    isRewardsMember);

double finalTotal = orderSubtotal + shippingCharge;

string shippingMethodName = GetShippingMethodName(shippingMethod);

Console.WriteLine();
Console.WriteLine("ORDER SUMMARY");
Console.WriteLine("-------------------");
Console.WriteLine($"Order subtotal:  {orderSubtotal:C}");
Console.WriteLine($"Shipping method: {shippingMethodName}");
Console.WriteLine($"Shipping charge: {shippingCharge:C}");
Console.WriteLine($"Final total:     {finalTotal:C}");

static double CalculateShipping(
    double orderSubtotal,
    int shippingMethod,
    bool isRewardsMember)
{
    if (orderSubtotal <= 0)
    {
        throw new ArgumentException(
            "The order subtotal must be greater than zero.");
    }

    double shippingCharge;

    if (shippingMethod == 1)
    {
        shippingCharge = 5.99;
    }
    else if (shippingMethod == 2)
    {
        shippingCharge = 12.99;
    }
    else if (shippingMethod == 3)
    {
        shippingCharge = 24.99;
    }
    else
    {
        throw new ArgumentException(
            "The shipping method must be 1, 2, or 3.");
    }

    if (shippingMethod == 1 && orderSubtotal >= 75)
    {
        shippingCharge = 0;
    }

    if (isRewardsMember &&
        (shippingMethod == 2 || shippingMethod == 3))
    {
        shippingCharge = shippingCharge * 0.80;
    }

    return shippingCharge;
}

static string GetShippingMethodName(int shippingMethod)
{
    if (shippingMethod == 1)
    {
        return "Standard";
    }
    else if (shippingMethod == 2)
    {
        return "Two-Day";
    }
    else
    {
        return "Overnight";
    }
}
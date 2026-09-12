List<string> validationErrors = new List<string>();

Console.WriteLine("ACCOUNT REGISTRATION");
Console.WriteLine("--------------------");

Console.Write("First name: ");
string firstName = Console.ReadLine() ?? "";

Console.Write("Last name: ");
string lastName = Console.ReadLine() ?? "";

Console.Write("Email address: ");
string email = Console.ReadLine() ?? "";

Console.Write("Password: ");
string password = Console.ReadLine() ?? "";

Console.Write("Confirm password: ");
string confirmPassword = Console.ReadLine() ?? "";

Console.Write("Age: ");
string ageInput = Console.ReadLine() ?? "";

if (string.IsNullOrWhiteSpace(firstName))
{
    validationErrors.Add("First name cannot be blank.");
}

if (string.IsNullOrWhiteSpace(lastName))
{
    validationErrors.Add("Last name cannot be blank.");
}

if (!IsValidEmail(email))
{
    validationErrors.Add(
        "Email must contain @, contain a period, and be at least 6 characters long.");
}

if (!IsValidPassword(password))
{
    if (password.Length < 8)
    {
        validationErrors.Add(
            "Password must be at least 8 characters long.");
    }

    if (!ContainsUppercase(password))
    {
        validationErrors.Add(
            "Password must contain an uppercase letter.");
    }

    if (!ContainsNumber(password))
    {
        validationErrors.Add(
            "Password must contain a number.");
    }
}

if (password != confirmPassword)
{
    validationErrors.Add("Passwords do not match.");
}

if (!int.TryParse(ageInput, out int age))
{
    validationErrors.Add("Age must be a valid number.");
}
else if (!IsValidAge(age))
{
    validationErrors.Add("You must be at least 18 years old.");
}

Console.WriteLine();

if (validationErrors.Count == 0)
{
    Console.WriteLine("Account Successfully Created!");
    Console.WriteLine();
    Console.WriteLine($"Welcome, {firstName} {lastName}!");
}
else
{
    Console.WriteLine("Registration Failed");
    Console.WriteLine();

    foreach (string error in validationErrors)
    {
        Console.WriteLine($"- {error}");
    }
}

static bool IsValidEmail(string email)
{
    return email.Length >= 6
        && email.Contains("@")
        && email.Contains(".");
}

static bool IsValidPassword(string password)
{
    return password.Length >= 8
        && ContainsUppercase(password)
        && ContainsNumber(password);
}

static bool IsValidAge(int age)
{
    return age >= 18;
}

static bool ContainsUppercase(string password)
{
    foreach (char character in password)
    {
        if (char.IsUpper(character))
        {
            return true;
        }
    }

    return false;
}

static bool ContainsNumber(string password)
{
    foreach (char character in password)
    {
        if (char.IsDigit(character))
        {
            return true;
        }
    }

    return false;
}
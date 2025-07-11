// Continuously ask user to enter a password and check if it is valid or not.
while (true)
{
    Console.Write("Enter password: ");
    string? passwordInput = Console.ReadLine();

    if (passwordInput == null)
        continue;
    
    PasswordValidator validator = new PasswordValidator(passwordInput);

    string text = validator.IsValid() ? "Password is valid." : "Invalid password";
    Console.WriteLine(text);
}

public class PasswordValidator(string password)
{
    private readonly string _password = password;

    public bool IsValid()
    {
        // Check length.
        if (_password.Length < 6)
            return false;
        if (_password.Length > 13)
            return false;

        // Check characters.
        int uppercaseCount = 0;
        int lowercaseCount = 0;
        int numberCount = 0;

        foreach(char c in _password)
        {
            if (char.IsUpper(c))
                uppercaseCount++;

            if (char.IsLower(c))
                lowercaseCount++;

            if (char.IsDigit(c))
                numberCount++;

            if (c == 'T')
                return false;

            if (c == '&')
                return false;   
        }

        if (uppercaseCount == 0 ||  lowercaseCount == 0 || numberCount == 0)
            return false;

        return true;
    }


}
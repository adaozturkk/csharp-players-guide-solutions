// Get initial password from user.
Console.Write("Enter a starting passcode: ");
string? startingPasscode = Console.ReadLine();

Console.WriteLine();

Door door = new Door(startingPasscode);

// Until user wants to exit program, display menu and do preferred action.
int option = 0;

while (option != 6)
{
    Console.WriteLine($"Door is {door.DoorStatus}. Select the operation you want to do from menu (1 to 6).");
    Console.WriteLine("1. Close");
    Console.WriteLine("2. Open");
    Console.WriteLine("3. Lock");
    Console.WriteLine("4. Unlock");
    Console.WriteLine("5. Change passcode");
    Console.WriteLine("6. Exit");

    string? optionInput = Console.ReadLine()?.Trim();
    int.TryParse(optionInput, out option);

    Console.WriteLine();

    switch (option)
    {
        case 1:
            door.Close();
            break;
        case 2:
            door.Open();
            break;
        case 3:
            door.Lock();
            break;
        case 4:
            Console.Write("Write passcode to unlock door: ");
            string? passcodeInput = Console.ReadLine()?.Trim();

            if (passcodeInput != null)
                door.Unlock(passcodeInput);
            break;
        case 5:
            Console.Write("First, write current passcode: ");
            string? currentPasscode = Console.ReadLine()?.Trim();

            Console.Write("Now, write new passcode: ");
            string? newPasscode = Console.ReadLine()?.Trim();

            if ((currentPasscode != null) && (newPasscode != null))
                door.ChangePasscode(currentPasscode, newPasscode);
            break;
    }
}


class Door(string passcode)
{
    private string Passcode = passcode;
    public Status DoorStatus { get; private set; } = Status.Closed;

    // Perform actions only if required conditions are met for each method.
    public void Close()
    {
        if (DoorStatus == Status.Open)
        {
            DoorStatus = Status.Closed;
            Console.WriteLine("Door closed!");
        }
        else
            Console.WriteLine("Door cannot be closed.");
    }

    public void Open()
    {
        if (DoorStatus == Status.Closed)
        {
            DoorStatus = Status.Open;
            Console.WriteLine("Door opened!");
        }
        else
            Console.WriteLine("Door cannot be opened.");
            
    }

    public void Lock()
    {
        if (DoorStatus == Status.Closed)
        {
            DoorStatus = Status.Locked;
            Console.WriteLine("Door locked!");
        }
        else
            Console.WriteLine("Door cannot be locked.");
            
    }

    public void Unlock(string inputPasscode)
    {
        if (DoorStatus == Status.Locked && CheckPasscode(inputPasscode))
        {
            DoorStatus = Status.Closed;
            Console.WriteLine("Door unlocked!");
        }
        else
            Console.WriteLine("Wrong passcode. Door cannot be unlocked.");
    }

    public void ChangePasscode(string currentPasscode, string newPasscode)
    {
        if (CheckPasscode(currentPasscode))
        {
            Passcode = newPasscode;
            Console.WriteLine("Passcode changed successfully.");
        }
        else
            Console.WriteLine("Passcode could not be changed. Make sure you entered current passcode right.");
    }

    public bool CheckPasscode(string inputPasscode)
    {
        return inputPasscode == Passcode;
    }
}

enum Status
{
    Locked,
    Open,
    Closed
}
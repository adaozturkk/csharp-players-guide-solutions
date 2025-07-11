State currentState = State.Locked;

// Continuously ask user what to do and changes state according to that only if it is applicable.
while (true)
{
    Console.Write($"The chest is {currentState.ToString().ToLower()}. What do you want to do? ");
    string? userInput = Console.ReadLine();

    if (userInput == "unlock" && currentState == State.Locked)
        currentState = State.Closed;
    if (userInput == "open" && currentState == State.Closed)
        currentState = State.Open;
    if (userInput == "lock" && currentState == State.Closed)
        currentState = State.Locked;
    if (userInput == "close" && currentState == State.Open)
        currentState = State.Closed;
}

// Enumeration for tracking chest's state.
enum State
{
    Open,
    Closed,
    Locked
}
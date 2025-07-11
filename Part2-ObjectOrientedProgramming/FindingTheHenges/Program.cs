// For all henges, get information through tuples and display a triangle in console
// according to positions and descriptions.
Henge[] henges = [Henge.Tekhelet, Henge.Mauveine, Henge.Amaranth, Henge.Jasmine, Henge.Keppel, Henge.Bice];
DisplayHenges(henges);

void DisplayHenges(Henge[] henges)
{
    foreach (Henge henge in henges)
    {
        (int X, int Y, string Color) = GetInformation(henge);
        Console.SetCursorPosition(X, Y);
        Console.Write(Color);
    }
}

// Assign x coordinate, y coordinate, and description based on henge.
(int, int, string) GetInformation(Henge henge)
{
    return henge switch
    {
        Henge.Tekhelet => (0b1000, 0b0000, "\e[38;2;89;12;131mT"),
        Henge.Mauveine => (0b1011, 0b0011, "\e[38;2;143;48;161mM"),
        Henge.Amaranth => (0b0000, 0b0111, "\e[38;2;240;24;79mA"),
        Henge.Jasmine => (0b0011, 0b0011, "\e[38;2;246;215;141mJ"),
        Henge.Keppel => (0b0111, 0b0111, "\e[38;2;70;179;165mK"),
        Henge.Bice => (0b1110, 0b0111, "\e[38;2;46;109;146mB"),
    };
}

// Enumeration for Henge types.
enum Henge
{
    Tekhelet,
    Mauveine,
    Amaranth,
    Jasmine,
    Keppel,
    Bice
}
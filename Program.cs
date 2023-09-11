int currentLocation = 1;

while (true)
{
    Console.WriteLine("You are currently at Location " + currentLocation);
    Console.WriteLine("Available Locations:");
    Console.WriteLine("1. Home");
    Console.WriteLine("2. Park");
    Console.WriteLine("3. Store");
    Console.WriteLine("4. Quit");

    Console.WriteLine("Enter the number of your desired location: ");

    int choice;
    if (int.Convert.ToInt32(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("You are already at Home!");
                break;
            case 2:
                Console.WriteLine("You have traveled to the Park.");
                currentLocation = 2;
                break;
            case 3:
                Console.WriteLine("You have traveled to the Store.");
                currentLocation = 3;
                break;
            case 4:
                Console.WriteLine("Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice. Please enter a valid location number.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }

    Console.WriteLine();
}

public class Program
{
    public static void Main()
    {
        Player player = new Player(World.Locations[1]);
        Console.WriteLine("Current location: " + player.Location.Name);
        Console.WriteLine(player.Location.Compass());

        while (player.Location.Name != "Goal")
        {
            Console.Write("Enter a direction (N/E/S/W): ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length == 1)
                {
                    char direction = input[0];
                    bool moved = player.TryMoveTo(player.Location.GetLocationAt(direction.ToString()));

                    if (!moved)
                    {
                        Console.WriteLine("Invalid direction or no location in that direction.");
                    }
                    else
                    {
                        Console.WriteLine("Current location: " + player.Location.Name);
                        Console.WriteLine(player.Location.Compass());
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a single direction (N/E/S/W).");
                }
            }
            else
            {
                Console.WriteLine("Input is empty. Please enter a valid input.");
            }
        }

        Console.WriteLine("You have arrived at the goal!");
    }
}
public class Program
{
    public static void Main()
    {
        Player player = new Player(World.Locations[0]);
        Console.WriteLine("Current location: " + player.Location.Name);
        Console.WriteLine(player.Location.Compass());

        bool wonGame = false;

        while (player.Location.Name != "Goal")
        {
            Console.Write("Enter a direction (N/E/S/W) or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("You left the game.");
                    break;
                }
                else if (input.Length == 1)
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
                    Console.WriteLine("Invalid input. Enter a single direction (N/E/S/W) or 'quit' to exit.");
                }
            }
            else
            {
                Console.WriteLine("Input is empty. Please enter a valid input.");
            }
        }

        if (player.Location.Name == "Goal")
        {
            Console.WriteLine("Congratulations! You have won the game!");
            wonGame = true;
        }

        if (!wonGame)
        {
            Console.WriteLine("Game over. You did not reach the goal.");
        }
    }
}

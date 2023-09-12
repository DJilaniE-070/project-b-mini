public class Program
{
    public static void Main()
    {
        Quest quest_1 = World.QuestByID(1);
        Quest quest_2 = World.QuestByID(2);

        //hier moet de intro van game story home
        Player player = new Player(World.Locations[0]);
        Console.WriteLine("Current location: " + player.Location.Name);
        Console.WriteLine(player.Location.Compass());

        bool wonGame = false;

        while (wonGame == false)
        {
            Console.Write("Enter a direction (N/E/S/W) or type 'quit' to exit: ");
            string input = Console.ReadLine();
            string direction = input.ToUpper();


            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("You left the game.");
                    break;
                }
                //de statement om te voorkomen dat als je quest 1 and quest 2 niet af heb dan je niet verder komt bij de Guard Post
                if (player.Location.Name == "Guard post" && direction == "E")
                {
                    if (quest_1.Cleared == false && quest_2.Cleared == false)
                    {
                        Console.WriteLine("You cannot go to the Bridge until you have completed both Quest 1 and Quest 2.");
                        continue; //skip verder en begin loop opnieuw. als je steeds op e typt
                    }
                 }

                else if (input.Length == 1)
                {

                    bool moved = player.TryMoveTo(player.Location.GetLocationAt(direction));

                    if (!moved)
                    {
                        Console.WriteLine("Invalid direction or no location in that direction.");
                    }
                    else
                    {
                        // wat is beter story boven compass beneden of na elk input compass boven en story binnen
                        // in de switch kun je in elk case een while loop zetten voor elk quest

                        Console.WriteLine("Current location: " + player.Location.Name);
                        Console.WriteLine(player.Location.Compass());
                        switch (player.Location.Name)
                        {
                        case "Home":
                            Console.WriteLine("write story home");
                            break;
                        case "Town square":
                            Console.WriteLine("write story Town square");
                            break;
                        case "Alchemist's hut":
                            Console.WriteLine("write story A H");
                            break;
                        case "Alchemist's garden":
                            Console.WriteLine("write story A G");
                            // hier de minigames voor quest in A G                            
                            while (true)
                            {
                                break;
                            }
                            break;
                        case "Farmhouse":
                            Console.WriteLine("write story F H");
                            break;
                        case "Farmer's field":
                            Console.WriteLine("write story F F");
                            break;
                        case "Guard post":

                        case "Bridge":
                           
                            Console.WriteLine("write story B");
                            break;

                        case "Forest":
                            //hier if quest 1 quest 2 and quest 3 is true then wongame = true
                            Console.WriteLine("Congratulations! You have won the game!");
                            wonGame = true;
                            break;
                            }
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

        if (wonGame == true)
        {
            Console.WriteLine("Game over. You did not reach the goal.");
        }
    }
}

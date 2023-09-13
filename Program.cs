public class Program
{
    public void EnterQuest(Monster monster , Player Player)
    {
        Player player = Player;
        Random random = new Random();
        
        Console.WriteLine($"You see a {monster.Name}!");
        while (monster.CurrentHitPoints > 0 && player.CurrentHitPoints > 0)
        {
            Console.WriteLine($"Player health: {player.CurrentHitPoints}");
            Console.WriteLine($"Monster health: {monster.CurrentHitPoints}");
            Console.WriteLine("Type attack to attack!");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "ATTACK")
            {
                Console.WriteLine($"You swing with your {player.CurrentWeapon.Name} and hit the the monster!");
                int player_dmg = random.Next(1, player.CurrentWeapon.MaxDMG);
                int monster_dmg = random.Next(1, monster.MaxDMG);
                monster.CurrentHitPoints -= player_dmg;
                Console.WriteLine($"You did {player_dmg} damage!");
                Console.WriteLine("The monster attacks you!");
                Console.WriteLine($"The monster did {monster_dmg} damage!");

                player.CurrentHitPoints -= monster_dmg ;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
        if (player.CurrentHitPoints <= 0)
        {
            Console.WriteLine("You died!");
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else if (monster.CurrentHitPoints <= 0)
        {
            Console.WriteLine("You killed the monster!");
            player.CurrentHitPoints = player.MaximumHitPoints;
            Choose_Sword(player);
            Console.WriteLine("Current location: " + player.Location.Name);
            Console.WriteLine(player.Location.Compass());
            }
    }

    public static void Choose_Sword(Player player)
    {   
        Weapon club = World.WeaponByID(2);
        int club_id = club.ID;
        if (player.CurrentWeapon.ID != club_id)
            {
            Console.WriteLine("You get a reward for killing the monster \ndo you want to change your old trusty rusty sword to the nice shiny club\nType Y/N\n");
            string choose_weapon = Console.ReadLine();
            if (choose_weapon.ToUpper() == "Y")
            {
            player.CurrentWeapon = club;
            Console.WriteLine("You've picked up the nice looking shiny club\n");
            }
            else if(choose_weapon.ToUpper() == "N")
            {
            Console.WriteLine("You've keep your old trusty rusty sword\n");
            }
            else
            {
            Console.WriteLine("Input error\n");
            }
            }
    }

    public static void Main()
    {
        
        Quest quest_1 = World.QuestByID(1);
        Quest quest_2 = World.QuestByID(2);
        Quest quest_3 = World.QuestByID(3);
        Monster rat = World.MonsterByID(1);
        Monster snake = World.MonsterByID(2);
        Monster spider = World.MonsterByID(3);

        Program program = new Program();
        Player player = new Player(World.Locations[0]);
        //hier moet de intro van game story home
        Console.WriteLine("          _______  _______  _______ ");
        Console.WriteLine("|\\     /|(  ____ )(  ____ )(  ___  )");
        Console.WriteLine("| )   ( || (    \\/| (    )|| (   ) |");
        Console.WriteLine("| (___) || (__    | (____)|| |   | |");
        Console.WriteLine("|  ___  ||  __)   |     __)| |   | |");
        Console.WriteLine("| (   ) || (      | (\\ (   | |   | |");
        Console.WriteLine("| )   ( || (____/\\| ) \\ \\__| (___) |");
        Console.WriteLine("|/     \\|(_______/|/   \\__/(_______)");

        Console.WriteLine("\nYour town is being infected by a disease that comes from spiders\ngo and kill those spiders if you want to impress your crush and become the towns hero. \n");
        Console.WriteLine("Current location: " + player.Location.Name);
        Console.WriteLine(player.Location.Compass());

        bool wonGame = false;

        while (wonGame == false)
        {
            Console.Write("\nEnter a direction (N/E/S/W) or type 'quit' to exit: ");
            string input = Console.ReadLine();
            string direction = input.ToUpper();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("You left the game.");
                    break;
                }
                if (player.Location.Name == "Guard post" && direction == "E" && quest_1.Cleared == false && quest_2.Cleared == false)
                    {
                        Console.WriteLine("You cannot go pass me to the Bridge until you have slain the rats and snakes in the North and West. \n Show me your worthy to slay the Giant spider");
                        continue; // Skip the movement handling if quests are not completed.
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
                            Console.WriteLine("You are home");
                            break;
                        case "Town square":
                            Console.WriteLine("The Town is infested with spiders everyone left the town ");
                            break;
                        case "Alchemist's hut":
                            if (quest_1.Cleared == false)
                            {
                                Console.WriteLine("\nGoodday son can you help me with my rat problem\n");
                                quest_1.showAvailableQuests(quest_1);
                                Console.WriteLine(player.Location.Compass());

                            }
                            else
                            {
                            Console.WriteLine("\nThanks you son for helping me");
                            }
                            break;
                        case "Alchemist's garden":
                            // hier de minigames voor quest in A G
                            if (quest_1.Cleared == false)
                            {
                            program.EnterQuest(rat,player); 
                            quest_1.Cleared = true; 
                            }
                            else
                            {
                            Console.WriteLine("There is nothing here except dead rats");
                            }                    
                            break;
                        case "Farmhouse":
                            if (quest_2.Cleared == false)
                            {
                            Console.WriteLine("Goodday son can you help me with my snake problem\n");
                            quest_2.showAvailableQuests(quest_2);
                            Console.WriteLine(player.Location.Compass());
                            }
                            else
                            {
                            Console.WriteLine("Thanks son for killing of those snakes");    
                            }
                            break;
                        case "Farmer's field":
                            if (quest_2.Cleared == false)
                            {
                            program.EnterQuest(snake, player);
                            quest_2.Cleared = true;
                            }
                            else
                            {
                            Console.WriteLine("There is nothing here except dead snakes");
                            }
                            break;
                        case "Guard post":
                            Console.WriteLine("In the forest past this post is the Giant spiders nest");
                            break;
                        case "Bridge":
                            Console.WriteLine("You are very shaky but if you defeat the spiders you are THE HERO of the town");
                            quest_3.showAvailableQuests(quest_3);
                            Console.WriteLine(player.Location.Compass());
                            break;
                        case "Forest":
                            program.EnterQuest(spider, player);
                            quest_3.Cleared = true;
                            Console.WriteLine("Congratulations! You have won the game!");
                            if (quest_1.Cleared == true && quest_2.Cleared == true && quest_3.Cleared == true)
                            {
                            wonGame = true;
                            }
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

        if (wonGame == false)
        {
            Console.WriteLine("Game over. You did not reach the goal.");
        }
    }
}

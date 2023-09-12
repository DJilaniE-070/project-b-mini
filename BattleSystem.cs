class BattleSystem
    {
        public int playerHealth { get; set; }
        public int enemyHealth { get; set; }

        public void Battle(int playerHealth, int enemyHealth)
        {
            this.playerHealth = playerHealth;
            this.enemyHealth = enemyHealth;
        }

        public void battle()
        {
            Console.WriteLine("A wild enemy appears!");
            while (playerHealth > 0)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Attack\n2. Dodge\n3. Heal");
                string userChoice = Console.ReadLine();
                Console.Clear();
                bool dodgeNextMove = false;
                switch (userChoice)
                {
                    case "1":
                        attack();
                        break;
                    case "2":
                        dodgeNextMove = dodge();
                        break;
                    case "3":
                        heal();
                        break;
                    default:
                        Console.WriteLine("You chose to do nothing for reason!");
                        break;
                }

                if (enemyHealth <= 0)
                {
                    Console.WriteLine("Enemy killed!");
                    break;
                }
                else
                {
                    Console.WriteLine("The enemy has " + enemyHealth + " health left.");
                }
                if (!dodgeNextMove)
                {
                    enemyAttack();
                }
                Console.WriteLine("You have " + playerHealth + " health left.");
            }
            if (playerHealth <= 0)
            {
                Console.WriteLine("You Died!");
            }
        }


        public void attack()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 4);
            if (chance == 1)
            {
                Console.WriteLine("You missed!");
            }
            else if (chance == 2)
            {
                Console.WriteLine("Critical hit!");
                enemyHealth -= 20;
            }
            else
            {
                Console.WriteLine("You hit the enemy!");
                enemyHealth -= 10;
            }


        }

        public bool dodge()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 3);
            if (chance == 1)
            {
                Console.WriteLine("You dodged the enemy attack!");
                return true;
            }
            else
            {
                Console.WriteLine("Dodge failed!");
                return false;
            }

        }

        public void heal()
        {
            Console.WriteLine("You healed yourself for 10 health!");
            playerHealth += 10;


        }

        public void enemyAttack()
        {
            Random rand = new Random();
            int chance = rand.Next(1, 4);
            if (chance == 1)
            {
                Console.WriteLine("The enemy missed!");
            }
            else if (chance == 2)
            {
                Console.WriteLine("Critical hit!");
                playerHealth -= 20;
            }
            else
            {
                Console.WriteLine("The enemy hit you!");
                playerHealth -= 10;
            }
}
}
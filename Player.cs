class Player
{
    public int CurrentHitPoints = 15;

    public int Potions = 0;
    
    public Location Location;

    public int CurrentWeapon;

    public int MaximumHitPoints = 15; 

    public string Name;

    public Player(string id, int Weapon, int MaxHP, Location location )
    {
        this.Name = id;
        this.CurrentWeapon = Weapon;
        this.MaximumHitPoints = MaxHP;
        this.Location = location;
    }

    public void Potion()
    {   
        if (this.Potions > 0)
        {
            this.CurrentHitPoints += 5;
            if(CurrentHitPoints > 15)
            {
                CurrentHitPoints = MaximumHitPoints;
            }
        }
        else
        {
         Console.WriteLine("You have no potions to use");
        }
    }

    public void ResetHP()
    {
        this.CurrentHitPoints = MaximumHitPoints;
    }

    //if quest bool is true then resethp
}
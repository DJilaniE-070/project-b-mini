using System.Globalization;

class Player
{
    public int CurrentHitPoints = 15;

    public int Potions = 0;
    
    public Location Location;

    public Weapon CurrentWeapon;

    public int MaximumHitPoints = 15; 

    public string Name;

    public Player(Location location )
    {
        this.Location = location;
    }
    public bool TryMoveTo(Location newLocation)
    {
        if (newLocation != null)
        {
            Location = newLocation;
            return true;
        }
        return false;
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
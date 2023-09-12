public class Monster
{
    public int CurrentHitPoints;

    public int ID;

    public int MaxDMG;

    public int MaximumHitPoints;

    public string Name;

    public Monster(int id, string name, int maxdmg, int maxhp, int currenthp)
    {
        this.ID = id;
        this.Name = name;
        this.MaxDMG = maxdmg;
        this.MaximumHitPoints = maxhp;
        this.CurrentHitPoints = currenthp;
    }
}
public class Quest
{
    public string Description;

    public int ID;

    public string Name;

    public bool Cleared = false;
    public Quest(int id ,string name ,string Description)
    {
        this.ID = id;
        this.Name = name;
        this.Description = Description;
    }

}
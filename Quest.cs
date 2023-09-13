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
    public void showAvailableQuests(Quest quest)
    {
            Console.WriteLine("Available quests:");
            Console.WriteLine("---Quest Title---");
            Console.WriteLine("---" + quest.Name + "---");
            Console.WriteLine("---Quest Description---");
            Console.WriteLine(quest.Description);
            Console.WriteLine("--------");
    }
    public void showMonster(Monster monster)
    {
            Console.WriteLine("The following monster is living here:");
            Console.WriteLine("You see a " + monster.Name);
    }


}


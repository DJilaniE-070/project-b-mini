class Location
{
    public int ID;

    public string Name;

    public string Description;

    public bool Changethis;

    public bool Changethis2;

    public Location (int id, string name, string Description, bool Changethis, bool Changethis2)
    {
        this.ID = id;
        this.Name = name;
        this.Description = Description;
        this.Changethis = Changethis;
        this.Changethis2 = Changethis2;
    }

    public static void QuestAvailableHere(int id)
    {

    }
}
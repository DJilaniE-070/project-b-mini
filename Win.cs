class Win
{
    public bool Quest1;
    public bool Quest2;
    public bool Quest3;

    public Win(bool quest1, bool quest2, bool quest3)
    {
        Quest1 = quest1;
        Quest2 = quest2;
        Quest3 = quest3;
    }

    public bool Condition()
    {
        if (Quest1 && Quest2 && Quest3)
        {
            Console.WriteLine("Game cleared");
            return true;
        }
        else
        {
            return false;
        }
    }
}

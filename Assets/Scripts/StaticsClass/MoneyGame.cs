public static class MoneyGame
{
    private static int _money = 500;

    public static int Money => _money;

    public static void AddMoney(int money)
    {
        if (money >= 0)
            _money += money;
    }

    public static bool CanReduceMoney(int money)
    {
        if (money <= _money)
        {
            _money -= money;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void ResetMoney() => _money = 0;
}

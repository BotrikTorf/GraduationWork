public class Wallet
{
    private int _money;

    public Wallet(int money) => _money = money;

    public int Money => _money;

    public void AddMoney(int money)
    {
        if (money >= 0)
            _money += money;
    }

    public bool CanReduceMoney(int money)
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
}

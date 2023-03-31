public class HouseEnemies : House
{
    private void Start()
    {
        MaxHealth = 1000;
        Health = MaxHealth;
        IsPositive = false;
        Money = 200;
    }

    public override void AccrueMoney() => MoneyGame.AddMoney(Money);
}

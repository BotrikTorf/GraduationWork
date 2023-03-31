public class HouseUnits : House
{
    private void Start()
    {
        MaxHealth = 1000;
        Health = MaxHealth;
        IsPositive = true;
        Money = 100;
    }

    public override void AccrueMoney() => MoneyGame.AddMoney(Money);
}

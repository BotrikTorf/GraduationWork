using UnityEngine;

public abstract class God : MonoBehaviour
{
    private protected int _damage;
    private protected float _rechargeTime;

    public int Damage { get; private set; }
    public float RechargeTime { get; private set; }
    public int RecycleTimeFactor { get; private set; } = 0;
    public int SpellPower { get; private set; } = 0;
    public int MaxValue => 10;

    public void IncreaseDamage()
    {
        if (SpellPower <= MaxValue)
            SpellPower++;

        Damage = _damage + _damage * (SpellPower / MaxValue);
    }

    public void ReduceTime()
    {
        if (RecycleTimeFactor <= MaxValue)
            RecycleTimeFactor++;

        RechargeTime = _rechargeTime - _rechargeTime * (RecycleTimeFactor / MaxValue) * 0.5f;
    }
}

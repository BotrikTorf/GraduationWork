using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;

public abstract class House : MonoBehaviour
{
    private protected int MaxHealth;
    private protected int Health;

    public event UnityAction<int, int> HealthChanged;

    public bool IsPositive { get; private protected set; }
    public int Money { get; private protected set; }

    public abstract void AccrueMoney();

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        if (Health > 0)
        {
            HealthChanged?.Invoke(Health, MaxHealth);
        }
        else
        {
            AccrueMoney();
            MenuScene.Load();
        }
    }
}

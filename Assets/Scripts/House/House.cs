using UnityEngine;
using UnityEngine.Events;

public abstract class House : MonoBehaviour
{
    private protected bool IsPositive;
    private protected int MaxHealth;
    private protected int Health;

    public event UnityAction<int, int> HealthChanged;

    public bool IsPositiveHouse => IsPositive;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        HealthChanged?.Invoke(Health, MaxHealth);
    }
}

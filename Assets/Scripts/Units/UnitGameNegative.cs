using UnityEngine;
using UnityEngine.Events;

public abstract class UnitGameNegative : UnitGame
{
    [SerializeField] private protected int _remuneration;
    private protected Vector3 Direction => Vector3.left;

    public static event UnityAction<int> Died;

    protected override bool CheckTarget(GameObject target) =>
        target == null || 
        target.TryGetComponent(out UnitGameNegative _) || 
        target.TryGetComponent(out HouseEnemies _);

    protected override void OnDestroyUnit()
    {
        if (Health <= 0)
        {
            Died?.Invoke(_remuneration);
            Destroy(gameObject);
        }
    }

    public override void TakeShot(GameObject target)
    {
        if (target.TryGetComponent(out UnitGame enemy))
            enemy.TakeDamage(Damage);

        if (target.TryGetComponent(out House house))
            house.TakeDamage(Damage);
    }
}

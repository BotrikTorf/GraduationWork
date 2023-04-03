using UnityEngine;

public abstract class UnitGamePositive : UnitGame
{
    private protected Vector3 Direction => Vector3.right;

    public Sprite Icon { get; private protected set; }

    protected override bool CheckTarget(GameObject target) =>
        target == null || 
        target.TryGetComponent(out HouseUnits _) || 
        target.TryGetComponent(out UnitGamePositive _);

    protected override void OnDestroyUnit()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}

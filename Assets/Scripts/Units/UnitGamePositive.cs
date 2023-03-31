using UnityEngine;

public abstract class UnitGamePositive : UnitGame
{
    private protected Vector3 Direction => Vector3.right;

    public Sprite Icon { get; private protected set; }


    protected override bool CheckTarget(GameObject target)
    {
        if (target == null)
        {
            return true;
        }
        else if (target.TryGetComponent(out HouseUnits _))
        {
            return true;
        }
        else if (target.TryGetComponent(out UnitGamePositive _))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override void OnDestroyUnit()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
}

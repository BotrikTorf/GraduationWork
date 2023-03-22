using UnityEngine;

public abstract class UnitGamePositive : UnitGame
{
    public Vector3 Direction => Vector3.right;

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
}

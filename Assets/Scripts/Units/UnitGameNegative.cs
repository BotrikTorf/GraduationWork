using UnityEngine;

public abstract class UnitGameNegative : UnitGame
{
    [SerializeField] private protected int _remuneration;
    private protected Vector3 Direction => Vector3.left;

    protected override bool CheckTarget(GameObject target)
    {
        if (target == null)
        {
            return true;
        }
        else if (target.TryGetComponent(out UnitGameNegative _))
        {
            return true;
        }
        else if (target.TryGetComponent(out HouseEnemies _))
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
        {
            TextMoney.Instance.AddMoney(_remuneration);
            Destroy(gameObject);
        }
    }
}

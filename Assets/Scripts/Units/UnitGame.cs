using UnityEngine;
using UnityEngine.Events;

public abstract class UnitGame : MonoBehaviour
{
    [SerializeField] private protected PointTargetEnemy _pointTarget;
    [field: SerializeField] public HeroSO HeroSo { get; private protected set; }

    private protected StateMachine StateMachinePlayer;
    private protected StateMove StateMovePlayer;
    private protected StateAttack StateAttackPlayer;
    private protected float Speed;
    private protected int Damage;
    private protected int MaxHealth;
    private protected int Armor;
    private protected int Health;
    private protected bool IsPositive;

    public event UnityAction<int, int> HealthChanged;

    public Animator Animator { get; private protected set; }
    public string Name { get; private protected set; }

    public GameObject Target { get; private set; }

    public bool IsPositivePlayer => IsPositive;

    public abstract void Move();

    protected abstract int OnDamaged(int damage);
    protected abstract void OnDestroyUnit();

    protected abstract bool CheckTarget(GameObject tarsget);

    public abstract void TakeShot(GameObject target);

    private void OnEnable() => _pointTarget.TransfedTarget += OnPointTarget;

    private void OnDisable() => _pointTarget.TransfedTarget -= OnPointTarget;

    public void TakeDamage(int damage)
    {
        Health = Mathf.Clamp(Health - OnDamaged(damage), 0, MaxHealth);
        HealthChanged?.Invoke(Health, MaxHealth);
        OnDestroyUnit();
    }

    private void OnPointTarget(GameObject target)
    {
        if (CheckTarget(target))
        {
            StateMachinePlayer.ChangesSate(StateMovePlayer);
        }
        else
        {
            Target = target;
            StateMachinePlayer.ChangesSate(StateAttackPlayer);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public abstract class UnitGame : MonoBehaviour
{
    [SerializeField] private protected PointTargetEnemy _pointTarget;

    private protected Animator AnimatorPlayer;
    private protected StateMachine StateMachinePlayer;
    private protected StateMove StateMovePlayer;
    private protected StateAttack StateAttackPlayer;
    private protected float Speed;
    private protected string NamePlayer;
    private protected int DamagePlayer;
    private protected int MaxHealth;
    private protected int Armor;
    private protected int Health;
    private protected bool IsPositive;

    public event UnityAction<int, int> HealthChanged;

    public Animator Animator => AnimatorPlayer;
    public string Name => NamePlayer;

    public GameObject Target { get; private set; }

    public int Damage => DamagePlayer;

    public float SpeedPlayer => Speed;

    public bool IsPositivePlayer => IsPositive;

    public abstract void Move();

    protected abstract int OnDamaged(int damage);

    protected abstract bool CheckTarget(GameObject tarsget);

    public abstract void TakeShot(GameObject target);

    private void OnEnable() => _pointTarget.TransferTarget += OnPointTarget;

    private void OnDisable() => _pointTarget.TransferTarget -= OnPointTarget;

    public void TakeDamage(int damage)
    {
        Health = Mathf.Clamp(Health - OnDamaged(damage), 0, MaxHealth);
        HealthChanged?.Invoke(Health, MaxHealth);

        if (Health <= 0)
            Destroy(gameObject);
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

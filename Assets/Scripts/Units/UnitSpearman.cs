using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitSpearman : UnitGamePositive
{
    [SerializeField] private UnitSO _unitSo;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        NamePlayer = _unitSo.Name;
        DamagePlayer = _unitSo.Damage;
        MaxHealth = _unitSo.Health;
        Armor = _unitSo.Armor;
        Speed = 1;
        Health = MaxHealth;
        IsPositive = true;
        AnimatorPlayer = GetComponent<Animator>();
        StateMachinePlayer = new StateMachine();
        StateMovePlayer = new StateMove(this);
        StateAttackPlayer = new StateAttack(this);
        StateMachinePlayer.Initialize(StateMovePlayer);
        _pointTarget.gameObject.transform.position =
            new Vector3(_pointTarget.gameObject.transform.position.x + Random.Range(-_rangeSpread, _rangeSpread),
                _pointTarget.gameObject.transform.position.y,
                _pointTarget.gameObject.transform.position.z);
    }

    private void Update() => StateMachinePlayer.CurrentStates.LogicUpdate();

    public override void Move() => transform.Translate(Direction * Speed * Time.deltaTime, Space.World);

    protected override int OnDamaged(int damage) => damage - Armor > 0 ? damage - Armor : 0;

    public override void TakeShot(GameObject target)
    {
        if (target.TryGetComponent(out UnitGame enemy))
            enemy.TakeDamage(DamagePlayer);

        if (target.TryGetComponent(out House house))
            house.TakeDamage(DamagePlayer);
    }
}

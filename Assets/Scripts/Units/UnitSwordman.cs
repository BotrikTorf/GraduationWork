using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UnitSwordman : UnitGamePositive
{
    [SerializeField] private UnitSO _unitSo;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        Name = _unitSo.Name;
        Damage = _unitSo.Damage;
        MaxHealth = _unitSo.Health;
        Armor = _unitSo.Armor;
        Speed = 1;
        Health = MaxHealth;
        IsPositive = true;
        Animator = GetComponent<Animator>();
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
            enemy.TakeDamage(Damage);

        if (target.TryGetComponent(out House house))
            house.TakeDamage(Damage);
    }
}

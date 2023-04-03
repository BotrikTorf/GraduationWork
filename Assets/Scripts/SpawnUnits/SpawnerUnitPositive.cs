using System.Collections.Generic;
using UnityEngine;

public class SpawnerUnitPositive : MonoBehaviour
{
    [SerializeField] private List<ButtonSummon> _buttonsSummon;
    [SerializeField] private List<Transform> _pointsSpawn;
    [SerializeField] private ButtonSpawnHero _buttonSpawnHero;
    [SerializeField] private TextMoney _textMoney;

    private Wallet _wallet;

    private void Start()
    {
        _wallet = new Wallet(400);
        _textMoney.ChangesText(_wallet.Money);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _buttonsSummon.Count; i++)
            _buttonsSummon[i].SummonUnit += OnSpawnUnit;

        _buttonSpawnHero.SummonUnit += OnSpawnUnit;
        UnitGameNegative.Died += OnTopAccount;
        SpawnerUnitNegative.Created += OnTopAccount;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonsSummon.Count; i++)
            _buttonsSummon[i].SummonUnit -= OnSpawnUnit;

        _buttonSpawnHero.SummonUnit -= OnSpawnUnit;
        UnitGameNegative.Died -= OnTopAccount;
        SpawnerUnitNegative.Created -= OnTopAccount;
    }

    private void OnSpawnUnit(UnitGamePositive unit) => Instantiate(unit.gameObject, _pointsSpawn[Random.Range(0, _pointsSpawn.Count)]);

    private void OnTopAccount(int money)
    {
        _wallet.AddMoney(money);
        _textMoney.ChangesText(_wallet.Money);
    }


    public bool CanCreateUnit(int money)
    {
        if (_wallet.CanReduceMoney(money))
        {
            _textMoney.ChangesText(_wallet.Money);
            return true;
        }
        else
        {
            return false;
        }
    }
}

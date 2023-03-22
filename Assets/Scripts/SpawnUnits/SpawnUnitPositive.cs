using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitPositive : MonoBehaviour
{
    [SerializeField] private List<ButtonSummon> _buttonsSummon;
    [SerializeField] private List<Transform> _pointsSpawn;

    private void OnEnable()
    {
        for (int i = 0; i < _buttonsSummon.Count; i++)
        {
            _buttonsSummon[i].SummonUnit += OnSpawnUnit;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonsSummon.Count; i++)
        {
            _buttonsSummon[i].SummonUnit -= OnSpawnUnit;
        }
    }

    private void OnSpawnUnit(UnitGamePositive unit)
    {
        Instantiate(unit.gameObject, _pointsSpawn[Random.Range(0, _pointsSpawn.Count)]);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerUnitNegative : MonoBehaviour
{
    [SerializeField] private List<Transform> _pointsSpawn;
    [SerializeField] private List<UnitGameNegative> _unitsNegatives;

    private float _timeSpawn = 1;
    private float _minTimeSpawn = 1;
    private float _maxTimeSpawn = 30;
    private float _timePassed = 0;
    private int _moneySpawn = 20;

    public static event UnityAction<int> Created;

    private void Update()
    {
        if (_timePassed >= _timeSpawn)
        {
            SpawnUnit();
            _timeSpawn = Random.Range(_minTimeSpawn, _maxTimeSpawn);
            _timePassed = 0;
        }

        _timePassed += Time.deltaTime;
    }

    private void SpawnUnit()
    {
        Created?.Invoke(_moneySpawn);
        Instantiate(_unitsNegatives[Random.Range(0, _unitsNegatives.Count)].gameObject,
            _pointsSpawn[Random.Range(0, _pointsSpawn.Count)]);
    }
}

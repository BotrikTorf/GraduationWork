using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointTargetEnemy : MonoBehaviour
{
    [SerializeField] private UnitGame _unit;

    private GameObject _target;
    private List<GameObject> _enemy;

    public event UnityAction<GameObject> TransferTarget;

    private void Start() => _enemy = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(_unit.name);

        if (collider.TryGetComponent(out UnitGame player))
        {
            if (_unit.IsPositivePlayer != player.IsPositivePlayer)
            {
                AddList(player.gameObject);
            }
        }

        if (collider.TryGetComponent(out House house))
        {
            if (_unit.IsPositivePlayer != house.IsPositiveHouse)
            {
                AddList(house.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (_enemy.Contains(collider.gameObject))
        {
            if (_target == collider.gameObject)
            {
                if (_enemy.Remove(_target))
                {
                    if (_enemy.Count == 0)
                    {
                        TransferTarget?.Invoke(null);
                    }
                    else
                    {
                        if (_enemy[0].TryGetComponent(out House _))
                        {
                            GameObject temp = _enemy[0];
                            _enemy.RemoveAt(0);
                            _enemy.Add(temp);
                            _target = _enemy[0];
                        }
                        else
                        {
                            _target = _enemy[0];
                        }

                        TransferTarget?.Invoke(_target);
                    }
                }
            }
            else
            {
                _enemy.Remove(collider.gameObject);
            }
        }
    }

    private void AddList(GameObject enemy)
    {
        if (_enemy.Count == 0)
        {
            _target = enemy;
            TransferTarget?.Invoke(_target);
            _enemy.Add(enemy);
        }
        else if (!_target.TryGetComponent(out UnitGame player))
        {
            _target = enemy;
            TransferTarget?.Invoke(_target);
            GameObject temp = _enemy[0];
            _enemy[0] = enemy;
            _enemy.Add(temp);
        }
        else
        {
            _enemy.Add(enemy);
        }
    }
}
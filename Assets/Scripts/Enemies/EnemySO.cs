using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "EnemySO", order = 52)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _initialDamage;
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _armor;

    public string Name => _name;
    public int Damage => _initialDamage;
    public int Health => _initialHealth;
    public int Armor => _armor;

}

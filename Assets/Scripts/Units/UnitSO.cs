using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "UnitSO", order = 52)]
public class UnitSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _spriteStartUnit;
    [SerializeField] private Sprite _spriteEndUnit;
    [SerializeField] private Sprite[] _spritesImprovementLevel;
    [SerializeField] private int _initialDamage;
    [SerializeField] private int _initialHealth;
    [SerializeField] private int _armor;

    private int _improvementLevel;

    public string Name => _name;
    public int ImprovementLevel => PlayerPrefs.HasKey($"{_name}ImprovementLevel")
        ? PlayerPrefs.GetInt($"{_name}ImprovementLevel")
        : -1;
    public Sprite SpriteStartUnit => _spriteStartUnit;
    public Sprite SpriteEndUnit => _spriteEndUnit;
    public Sprite[] SpritesImprovementLevel => _spritesImprovementLevel;
    public int MaxImprovement => _spritesImprovementLevel.Length;

    public int Damage => (int)(_initialDamage + _initialDamage * ((float)(_improvementLevel + 1) / MaxImprovement));
    public int Health => (int)(_initialHealth + _initialHealth * ((float)(_improvementLevel + 1) / MaxImprovement));
    public int Armor => _armor;

    private void Awake() => _improvementLevel = ImprovementLevel;

    public void UpgradeUnit()
    {
        if (_improvementLevel < MaxImprovement - 1)
        {
            _improvementLevel++;
            PlayerPrefs.SetInt($"{_name}ImprovementLevel", _improvementLevel);
        }
    }
}

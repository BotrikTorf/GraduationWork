using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewHero", menuName = "Hero", order = 52)]
public class HeroSO : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private int _health;
    [SerializeField] private int _armor;

    private int _speedRatio;
    private int _damageRatio;
    private int _healthFactor;
    private int _armorFactor;

    public string Name => _name;
    public Sprite Image => _image;
    public Sprite Icon => _icon;
    public int Damage => _damage + (int)(_damage * ((float)_damageRatio / MaxValue));
    public float SpeedAttack => _speedAttack - _speedAttack * ((float)_speedRatio / MaxValue) * 0.5f;
    public int Health => _health + (int)(_health * ((float)_healthFactor / MaxValue));
    public int Armor => _armor + (int)(_armor * ((float)_armorFactor / MaxValue));
    public int SpeedRatio => PlayerPrefs.HasKey($"{_name}SpeedRatio")
        ? PlayerPrefs.GetInt($"{_name}SpeedRatio")
        : 0;
    public int DamageRatio => PlayerPrefs.HasKey($"{_name}DamageRatio")
        ? PlayerPrefs.GetInt($"{_name}DamageRatio")
        : 0;
    public int HealthFactor => PlayerPrefs.HasKey($"{_name}HealthFactor")
        ? PlayerPrefs.GetInt($"{_name}HealthFactor")
        : 0;
    public int ArmorFactor => PlayerPrefs.HasKey($"{_name}ArmorFactor")
        ? PlayerPrefs.GetInt($"{_name}ArmorFactor")
        : 0;
    public int MaxValue => 10;

    private void Awake()
    {
        _speedRatio = SpeedRatio;
        _damageRatio = DamageRatio;
        _healthFactor = HealthFactor;
        _armorFactor = ArmorFactor;
    }

    public void IncreaseSpeedRatio()
    {
        if (_speedRatio < MaxValue)
            _speedRatio++;

        PlayerPrefs.SetInt($"{_name}SpeedRatio", _speedRatio);
    }

    public void IncreaseDamageRatio()
    {
        if (_damageRatio < MaxValue)
            _damageRatio++;

        PlayerPrefs.SetInt($"{_name}DamageRatio", _damageRatio);
    }

    public void IncreaseHealthFactor()
    {
        if (_healthFactor < MaxValue)
            _healthFactor++;

        PlayerPrefs.SetInt($"{_name}HealthFactor", _healthFactor);
    }

    public void IncreaseArmorFactor()
    {
        if (_armorFactor < MaxValue)
            _armorFactor++;

        PlayerPrefs.SetInt($"{_name}ArmorFactor", _armorFactor);
    }
}

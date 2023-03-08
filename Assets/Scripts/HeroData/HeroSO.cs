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
    public int Damage { get; private set; }
    public float SpeedAttack { get; private set; }
    public int Health { get; private set; }
    public int Armor { get; private set; }
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
        SpeedAttack = _speedAttack - _speedAttack * ((float)_speedRatio / MaxValue);
        Damage = _damage + (int)(_damage * ((float)_damageRatio / MaxValue));
        Health = _health + (int)(_health * ((float)_healthFactor / MaxValue));
        Armor = _armor + (int)(_armor * ((float)_armorFactor / MaxValue));
    }

    public void IncreaseSpeedRatio()
    {
        _speedRatio = SpeedRatio;

        if (_speedRatio < MaxValue)
            _speedRatio++;

        SpeedAttack = _speedAttack - _speedAttack * ((float)_speedRatio / MaxValue) * 0.5f;
        PlayerPrefs.SetInt($"{_name}SpeedRatio", _speedRatio);
    }

    public void IncreaseDamageRatio()
    {
        _damageRatio = DamageRatio;

        if (_damageRatio < MaxValue)
            _damageRatio++;

        Damage = _damage + (int)(_damage * ((float)_damageRatio / MaxValue));
        PlayerPrefs.SetInt($"{_name}DamageRatio", _damageRatio);
    }

    public void IncreaseHealthFactor()
    {
        _healthFactor = HealthFactor;

        if (_healthFactor < MaxValue)
            _healthFactor++;

        Health = _health + (int)(_health * ((float)_healthFactor / MaxValue));
        PlayerPrefs.SetInt($"{_name}HealthFactor", _healthFactor);
    }

    public void IncreaseArmorFactor()
    {
        _armorFactor = ArmorFactor;

        if (_armorFactor < MaxValue)
            _armorFactor++;

        Armor = _armor + (int)(_armor * ((float)_armorFactor / MaxValue));
        PlayerPrefs.SetInt($"{_name}ArmorFactor", _armorFactor);
    }
}

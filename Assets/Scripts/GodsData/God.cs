using UnityEngine;

[CreateAssetMenu(fileName = "NewGod", menuName = "God", order = 52)]
public class God : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;
    [SerializeField] private float _rechargeTime;
    [SerializeField] private Sprite _image;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite __spellIcon;

    private int _recycleTimeFactor;
    private int _spellPower;

    public string Name => _name;
    public Sprite Image => _image;
    public Sprite Icon => _icon;
    public Sprite SpellIcon => __spellIcon;

    public int RecycleTimeFactor => PlayerPrefs.HasKey($"{_name}RecycleTimeFactor")
        ? PlayerPrefs.GetInt($"{_name}RecycleTimeFactor")
        : 0;
    public int SpellPower => PlayerPrefs.HasKey($"{_name}SpellPower")
        ? PlayerPrefs.GetInt($"{_name}SpellPower")
        : 0;
    public int Damage { get; private set; }
    public float RechargeTime { get; private set; }
    public int MaxValue => 10;

    private void Awake()
    {
        Damage = _damage + (int)(_damage * ((float)_spellPower / MaxValue));
        RechargeTime = _rechargeTime - _rechargeTime * (_recycleTimeFactor / MaxValue) * 0.5f;
    }

    public void IncreaseDamage()
    {
        _spellPower = SpellPower;

        if (_spellPower < MaxValue)
            _spellPower++;

        Damage = _damage + (int)(_damage * ((float)_spellPower / MaxValue));
        PlayerPrefs.SetInt($"{_name}SpellPower", _spellPower);
    }

    public void ReduceTime()
    {
        _recycleTimeFactor = RecycleTimeFactor;

        if (_recycleTimeFactor < MaxValue)
            _recycleTimeFactor++;

        RechargeTime = _rechargeTime - _rechargeTime * (_recycleTimeFactor / MaxValue) * 0.5f;
        PlayerPrefs.SetInt($"{_name}RecycleTimeFactor", _recycleTimeFactor);
    }
}

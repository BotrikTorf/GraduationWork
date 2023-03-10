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
    public int Damage => _damage + (int)(_damage * ((float)_spellPower / MaxValue));
    public float RechargeTime => _rechargeTime - _rechargeTime * (_recycleTimeFactor / MaxValue) * 0.5f;
    public int MaxValue => 10;

    private void Awake()
    {
        _spellPower = SpellPower;
        _recycleTimeFactor = RecycleTimeFactor;
    }

    public void IncreaseDamage()
    {
        if (_spellPower < MaxValue)
            _spellPower++;

        PlayerPrefs.SetInt($"{_name}SpellPower", _spellPower);
    }

    public void ReduceTime()
    {
        if (_recycleTimeFactor < MaxValue)
            _recycleTimeFactor++;

        PlayerPrefs.SetInt($"{_name}RecycleTimeFactor", _recycleTimeFactor);
    }
}

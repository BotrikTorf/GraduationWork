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
    [SerializeField] private int _recycleTimeFactor;
    [SerializeField] private int _spellPower;

    public string Name => _name;
    public Sprite Image => _image;
    public Sprite Icon => _icon;
    public Sprite SpellIcon => __spellIcon;
    public int RecycleTimeFactor => PlayerPrefs.GetInt($"{_name} RecycleTimeFactor");
    public int SpellPower => PlayerPrefs.GetInt($"{_name} SpellPower");
    public int Damage { get; private set; }
    public float RechargeTime { get; private set; }

    public int MaxValue => 10;

    public void IncreaseDamage()
    {
        if (_spellPower <= MaxValue)
            _spellPower++;

        Damage = _damage + _damage * (_spellPower / MaxValue);

        PlayerPrefs.SetInt($"{_name} SpellPower", _spellPower);
    }

    public void ReduceTime()
    {
        if (_recycleTimeFactor <= MaxValue)
            _recycleTimeFactor++;

        RechargeTime = _rechargeTime - _rechargeTime * (_recycleTimeFactor / MaxValue) * 0.5f;

        PlayerPrefs.SetInt($"{_name} RecycleTimeFactor", _recycleTimeFactor);
    }
}

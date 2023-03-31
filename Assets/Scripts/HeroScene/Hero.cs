using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class Hero : MonoBehaviour
{
    [SerializeField] private HeroSO _heroSO;
    [SerializeField] private UnitGamePositive _unitHero;

    private Sprite _spriteHero;

    public HeroSO HeroSO => _heroSO;
    public string Name { get; private set; }
    public UnitGamePositive UnitHero => _unitHero;

    private void Awake()
    {
        _spriteHero = GetComponent<Sprite>();
        _spriteHero = _heroSO.Image;
        Name = _heroSO.Name;
    }
}

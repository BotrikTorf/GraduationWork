using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class Hero : MonoBehaviour
{
    [SerializeField] private HeroSO _heroSO;
    private Sprite _spriteHero;


    public string Name { get; private set; }

    public HeroSO HeroSO => _heroSO;

    private void Awake()
    {
        _spriteHero = GetComponent<Sprite>();
        _spriteHero = _heroSO.Image;
        Name = _heroSO.Name;
    }
}

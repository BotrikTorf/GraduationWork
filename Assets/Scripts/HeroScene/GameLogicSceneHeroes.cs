using UnityEngine;
using UnityEngine.UI;

public class GameLogicSceneHeroes : MonoBehaviour
{
    [SerializeField] private PanelHero _panelHero;
    [SerializeField] private Button _buttonImprovementAttackPower;
    [SerializeField] private Button _buttonImprovementAttackSpeed;
    [SerializeField] private Button _buttonImprovementArmor;
    [SerializeField] private Button _buttonImprovementHealth;
    [SerializeField] private Slider _sliderAttackPower;
    [SerializeField] private Slider _sliderAttackSpeed;
    [SerializeField] private Slider _sliderArmor;
    [SerializeField] private Slider _SliderHealth;

    private HeroSO _hero;

    private void OnEnable()
    {
        _panelHero.SubstitutionHero += OnSubstitutionHero;
        _buttonImprovementAttackPower.onClick.AddListener(OnButtonClickAttackPower);
        _buttonImprovementAttackSpeed.onClick.AddListener(OnButtonClickAttackSpeed);
        _buttonImprovementArmor.onClick.AddListener(OnButtonClickArmor);
        _buttonImprovementHealth.onClick.AddListener(OnButtonClickHealth);
    }

    private void OnDisable()
    {
        _panelHero.SubstitutionHero -= OnSubstitutionHero;
        _buttonImprovementAttackPower.onClick.RemoveListener(OnButtonClickAttackPower);
        _buttonImprovementAttackSpeed.onClick.RemoveListener(OnButtonClickAttackSpeed);
        _buttonImprovementArmor.onClick.RemoveListener(OnButtonClickArmor);
        _buttonImprovementHealth.onClick.RemoveListener(OnButtonClickHealth);
    }

    private void Start() => ChangeSlider();

    private void OnSubstitutionHero(HeroSO heroSo)
    {
        _hero = heroSo;
        ChangeSlider();
    }

    private void OnButtonClickAttackPower()
    {
        _hero.IncreaseDamageRatio();
        ChangeSlider();
    }

    private void OnButtonClickAttackSpeed()
    {
        _hero.IncreaseSpeedRatio();
        ChangeSlider();
    }

    private void OnButtonClickArmor()
    {
        _hero.IncreaseArmorFactor();
        ChangeSlider();
    }

    private void OnButtonClickHealth()
    {
        _hero.IncreaseHealthFactor();
        ChangeSlider();
    }


    private void ChangeSlider()
    {
        _sliderAttackPower.value = (float)_hero.DamageRatio / _hero.MaxValue;
        _sliderAttackSpeed.value = (float)_hero.SpeedRatio / _hero.MaxValue;
        _sliderArmor.value = (float)_hero.ArmorFactor / _hero.MaxValue;
        _SliderHealth.value = (float)_hero.HealthFactor / _hero.MaxValue;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private TMP_Text _upgradeAttackPower;
    [SerializeField] private TMP_Text _upgradeAttackSpeed;
    [SerializeField] private TMP_Text _upgradeArmor;
    [SerializeField] private TMP_Text _upgradeHealth;
    [SerializeField] private TMP_Text _amountMoney;


    private HeroSO _hero;
    private int _initialUpgradeCost = 100;

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
        if (MoneyGame.CanReduceMoney(_hero.DamageRatio * _initialUpgradeCost + _initialUpgradeCost))
        {
            _hero.IncreaseDamageRatio();
            ChangeSlider();
        }
    }

    private void OnButtonClickAttackSpeed()
    {
        if (MoneyGame.CanReduceMoney(_hero.SpeedRatio * _initialUpgradeCost + _initialUpgradeCost))
        {
            _hero.IncreaseSpeedRatio();
            ChangeSlider();
        }
    }

    private void OnButtonClickArmor()
    {
        if (MoneyGame.CanReduceMoney(_hero.ArmorFactor * _initialUpgradeCost + _initialUpgradeCost))
        {
            _hero.IncreaseArmorFactor();
            ChangeSlider();
        }
    }

    private void OnButtonClickHealth()
    {
        if (MoneyGame.CanReduceMoney(_hero.HealthFactor * _initialUpgradeCost + _initialUpgradeCost))
        {
            _hero.IncreaseHealthFactor();
            ChangeSlider();
        }
    }

    private void ChangeSlider()
    {
        _sliderAttackPower.value = (float)_hero.DamageRatio / _hero.MaxValue;
        _sliderAttackSpeed.value = (float)_hero.SpeedRatio / _hero.MaxValue;
        _sliderArmor.value = (float)_hero.ArmorFactor / _hero.MaxValue;
        _SliderHealth.value = (float)_hero.HealthFactor / _hero.MaxValue;
        _upgradeAttackPower.text = (_hero.DamageRatio * _initialUpgradeCost + _initialUpgradeCost).ToString();
        _upgradeAttackSpeed.text = (_hero.SpeedRatio * _initialUpgradeCost + _initialUpgradeCost).ToString();
        _upgradeArmor.text = (_hero.ArmorFactor * _initialUpgradeCost + _initialUpgradeCost).ToString();
        _upgradeHealth.text = (_hero.HealthFactor * _initialUpgradeCost + _initialUpgradeCost).ToString();
        _amountMoney.text = MoneyGame.Money.ToString();
    }
}

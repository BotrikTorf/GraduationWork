using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class ButtonPanelMenuScene : MonoBehaviour
{
    [SerializeField] private Button _buttonHero;
    [SerializeField] private Button _buttonUpgrades;

    private void OnEnable()
    {
        _buttonHero.onClick.AddListener(OnButtonHeroClick);
        _buttonUpgrades.onClick.AddListener(OnButtonUpgradesClick);
    }


    private void OnDisable()
    {
        _buttonHero.onClick.RemoveListener(OnButtonHeroClick);
        _buttonUpgrades.onClick.RemoveListener(OnButtonUpgradesClick);
    }

    private void OnButtonHeroClick() => HeroScene.Load();

    private void OnButtonUpgradesClick() => UpgradesScene.Load();
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] private Button _buttonGods;
    [SerializeField] private Button _buttonHero;
    [SerializeField] private Button _buttonUpgrades;
    private void OnEnable()
    {
        _buttonGods.onClick.AddListener(OnButtonGodsClick);
        _buttonHero.onClick.AddListener(OnButtonHeroClick);
        _buttonUpgrades.onClick.AddListener(OnButtonUpgradesClick);
    }


    private void OnDisable()
    {
        _buttonGods.onClick.RemoveListener(OnButtonGodsClick);
        _buttonHero.onClick.RemoveListener(OnButtonHeroClick);
        _buttonUpgrades.onClick.RemoveListener(OnButtonUpgradesClick);
    }

    private void OnButtonGodsClick() => SceneManager.LoadScene("GodsScene");

    private void OnButtonHeroClick() => SceneManager.LoadScene("HeroScene");

    private void OnButtonUpgradesClick() => SceneManager.LoadScene("UpgradesScene");
}

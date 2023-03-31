using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(Button))]
public class ButtonExitMenu : MonoBehaviour
{
    [SerializeField] private HouseUnits _houseUnits;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        MenuScene.Load();
        Time.timeScale = 1;
    }
}

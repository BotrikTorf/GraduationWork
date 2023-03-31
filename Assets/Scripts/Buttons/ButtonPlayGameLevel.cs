using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPlayGameLevel : MonoBehaviour
{
    [SerializeField] private GameObject _panelPauseGame;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        Time.timeScale = 1;
        _panelPauseGame.SetActive(false);
    }
}

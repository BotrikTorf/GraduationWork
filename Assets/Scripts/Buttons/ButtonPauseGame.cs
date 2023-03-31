using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _panelPauseGame;

    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        _panelPauseGame.SetActive(true);
        Time.timeScale = 0;
    }
}

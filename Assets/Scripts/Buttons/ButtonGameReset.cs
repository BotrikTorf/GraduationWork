
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonGameReset : MonoBehaviour
{
    private Button _buttonGameReset;
    private void Awake() => _buttonGameReset = GetComponent<Button>();

    private void OnEnable() => _buttonGameReset.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _buttonGameReset.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick() => PlayerPrefs.DeleteAll();
}

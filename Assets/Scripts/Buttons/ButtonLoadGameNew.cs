using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

[RequireComponent(typeof(Button))]
public class ButtonLoadGameNew : MonoBehaviour
{
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick() => LevelScene.Load();
}

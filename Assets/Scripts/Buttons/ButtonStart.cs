using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ButtonStart : MonoBehaviour
{
    [Range(0f, 1f)] public float Range = 1;
    private Image _image;
    private Button _button;

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);


    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void Start() => _image.alphaHitTestMinimumThreshold = Range;

    private void OnButtonClick() => SceneManager.LoadScene("MenuScene");
}

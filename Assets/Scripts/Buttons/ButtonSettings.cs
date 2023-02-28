using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonSettings : MonoBehaviour
{
    private Image _image;

    private void Awake() => _image = GetComponent<Image>();

    void Start() => _image.alphaHitTestMinimumThreshold = 1f;
}

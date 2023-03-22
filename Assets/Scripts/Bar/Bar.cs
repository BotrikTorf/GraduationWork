using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider SliderBar;

    public abstract void OnSetActive();

    public void OnValueChanged(int value, int maxValue)
    {
        OnSetActive();
        SliderBar.value = (float)value / maxValue;
    }
}

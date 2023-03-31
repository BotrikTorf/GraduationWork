using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public abstract class ButtonSummon : MonoBehaviour
{
    [SerializeField] private protected TMP_Text _text;
    [SerializeField] private protected UnitGamePositive UnitGame;

    private protected Button ButtonComponent;
    private protected Image ImageButton;
    private protected int CallCost;

    public event UnityAction<UnitGamePositive> SummonUnit;

    protected abstract bool CanSummonedUnit();

    private void OnEnable() => ButtonComponent.onClick.AddListener(OnButtonClick);

    private void OnDisable() => ButtonComponent.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        if (CanSummonedUnit())
            SummonUnit?.Invoke(UnitGame);
    }
}

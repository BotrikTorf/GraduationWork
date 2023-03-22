using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public abstract class ButtonSummon : MonoBehaviour
{
    [SerializeField] private protected TMP_Text _text;
    [SerializeField] private protected UnitGamePositive UnitGame;

    private protected Button Button;
    private protected int CallCost;

    public event UnityAction<UnitGamePositive> SummonUnit;

    protected abstract bool CanSummonedUnit();

    private void OnEnable() => Button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => Button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        if (CanSummonedUnit())
            SummonUnit?.Invoke(UnitGame);
    }
}

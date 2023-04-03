using System.Collections;
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
    [SerializeField] private protected SpawnerUnitPositive _spawnerUnitPositive;

    private protected Button ButtonComponent;
    private protected Image ImageButton;
    private protected int CallCost;

    private float _lerpDuration = 2.5f;

    public event UnityAction<UnitGamePositive> SummonUnit;

    private void OnEnable() => ButtonComponent.onClick.AddListener(OnButtonClick);

    private void OnDisable() => ButtonComponent.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        if (CanSummonedUnit())
            SummonUnit?.Invoke(UnitGame);
    }

    private bool CanSummonedUnit()
    {
        if (_spawnerUnitPositive.CanCreateUnit(CallCost))
        {
            StartCoroutine(Filing());
            return true;
        }

        return false;
    }

    private  IEnumerator Filing()
    {
        ButtonComponent.interactable = false;
        float elepsed = 0;

        while (elepsed < _lerpDuration)
        {
            ImageButton.fillAmount = elepsed / _lerpDuration;
            elepsed += Time.deltaTime;
            yield return null;
        }

        ImageButton.fillAmount = 1;
        ButtonComponent.interactable = true;
    }
}

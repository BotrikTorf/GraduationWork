using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSummonSpearman : ButtonSummon
{
    private float _lerpDuration = 2f;

    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        ImageButton = GetComponent<Image>();
    }

    private void Start()
    {
        CallCost = 150;
        _text.text = CallCost.ToString();
    }

    protected override bool CanSummonedUnit()
    {
        if (TextMoney.Instance.TakesMoney(CallCost))
        {
            StartCoroutine(Filing(_lerpDuration));
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Filing(float duration)
    {
        ButtonComponent.interactable = false;
        float elepsed = 0;

        while (elepsed < duration)
        {
            ImageButton.fillAmount = elepsed / duration;
            elepsed += Time.deltaTime;
            yield return null;
        }

        ImageButton.fillAmount = 1;
        ButtonComponent.interactable = true;
    }
}

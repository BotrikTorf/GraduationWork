using UnityEngine;
using UnityEngine.UI;

public class ButtonSummonSpearman : ButtonSummon
{
    private void Awake() => Button = GetComponent<Button>();

    private void Start()
    {
        CallCost = 150;
        _text.text = CallCost.ToString();
    }

    protected override bool CanSummonedUnit()
    {
        Debug.Log("Призвали копейщика");
        return true;
    }
}

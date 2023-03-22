using UnityEngine;
using UnityEngine.UI;

public class ButtonSummonSwordman : ButtonSummon
{
    private void Awake() => Button = GetComponent<Button>();

    private void Start()
    {
        CallCost = 100;
        _text.text = CallCost.ToString();
    }

    protected override bool CanSummonedUnit()
    {
        Debug.Log("Призвали мечника");
        return true;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonSummonArcher : ButtonSummon
{
    private void Awake() => Button = GetComponent<Button>();

    private void Start()
    {
        CallCost = 50;
        _text.text = CallCost.ToString();
    }

    protected override bool CanSummonedUnit()
    {
        Debug.Log("Призвали лучника");
        return true;
    }
}

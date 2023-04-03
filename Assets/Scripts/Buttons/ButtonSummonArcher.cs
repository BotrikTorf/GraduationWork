using UnityEngine.UI;

public class ButtonSummonArcher : ButtonSummon
{
    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        ImageButton = GetComponent<Image>();
        CallCost = 50;
        _text.text = CallCost.ToString();
    }
}

using UnityEngine.UI;

public class ButtonSummonSwordman : ButtonSummon
{
    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        ImageButton = GetComponent<Image>();
        CallCost = 100;
        _text.text = CallCost.ToString();
    }
}

using UnityEngine.UI;

public class ButtonSummonSpearman : ButtonSummon
{
    private void Awake()
    {
        ButtonComponent = GetComponent<Button>();
        ImageButton = GetComponent<Image>();
        CallCost = 150;
        _text.text = CallCost.ToString();
    }
}

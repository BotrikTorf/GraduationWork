using UnityEngine;
using TMPro;

public class TextMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ChangesText(int money) => _text.text = money.ToString();
}

using UnityEngine;
using TMPro;

public class TextMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public static TextMoney Instance;

    private int _money = 400;

    private void Awake() => Instance = this;

    private void Start() => ChangesText();

    public void AddMoney(int money)
    {
        _money += money;
        ChangesText();
    }

    public bool TakesMoney(int money)
    {
        if (_money >= money)
        {
            _money -= money;
            ChangesText();
            return true;
        }
        else
        {
            return false;
        }
    } 

    private void ChangesText() => _text.text = _money.ToString();
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ButtonSpawnHero : MonoBehaviour
{
    [SerializeField] private UnitGamePositive _defaultHero;
    [SerializeField] private TMP_Text _text;

    private UnitGamePositive _activeUnit;
    private int _callCost = 250;
    private Button _button;
    private float _lerpDuration = 2.5f;
    private Image _icon;

    public event UnityAction<UnitGamePositive> SummonUnit;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _icon = GetComponent<Image>();
        _activeUnit = ActiveHeroSave.GetActiveHero();
        _text.text = _callCost.ToString();

        if (_activeUnit == null)
            _activeUnit = _defaultHero;

        _icon.sprite = _activeUnit.HeroSo.Icon;
    }

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        if (TextMoney.Instance.TakesMoney(_callCost))
        {
            StartCoroutine(Filing(_lerpDuration));
            SummonUnit?.Invoke(_activeUnit);
        }
    }

    private IEnumerator Filing(float duration)
    {
        _button.interactable = false;
        float elepsed = 0;

        while (elepsed < duration)
        {
            _icon.fillAmount = elepsed / duration;
            elepsed += Time.deltaTime;
            yield return null;
        }

        _icon.fillAmount = 1;
        _button.interactable = true;
    }
}

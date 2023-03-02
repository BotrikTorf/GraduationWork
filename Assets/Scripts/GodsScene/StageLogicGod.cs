using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLogicGod : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gods;
    [SerializeField] private Button _buttonArrowBack;
    [SerializeField] private Button _buttonArrowForward;
    [SerializeField] private Button _buttonImprovementSpell;
    [SerializeField] private Button _buttonImprovementTime;
    [SerializeField] private Slider _sliderSpell;
    [SerializeField] private Slider _sliderTime;

    private God _god;
    private GameObject _activeGod;
    private int _numberGod;

    private void Awake()
    {
        if (_activeGod == null)
        {
            for (int i = 0; i < _gods.Count; i++)
                _gods[i].SetActive(false);

            _numberGod = 0;
            _activeGod = _gods[_numberGod];

            if (_activeGod.TryGetComponent(out God god))
                _god = god;
        }
    }

    private void OnEnable()
    {
        _buttonArrowBack.onClick.AddListener(OnButtonClickBack);
        _buttonArrowForward.onClick.AddListener(OnButtonClickForward);
        _buttonImprovementSpell.onClick.AddListener(OnButtonClickImprovementSpell);
        _buttonImprovementTime.onClick.AddListener(OnButtonClickImprovementTime);
    }


    private void OnDisable()
    {
        _buttonArrowBack.onClick.RemoveListener(OnButtonClickBack);
        _buttonArrowForward.onClick.RemoveListener(OnButtonClickForward);
        _buttonImprovementSpell.onClick.RemoveListener(OnButtonClickImprovementSpell);
        _buttonImprovementTime.onClick.RemoveListener(OnButtonClickImprovementTime);
    }

    private void Start() => ChangesGod(_numberGod);

    private void OnButtonClickBack()
    {
        _numberGod--;

        if (_numberGod < 0)
            _numberGod = _gods.Count - 1;

        ChangesGod(_numberGod);
    }

    private void OnButtonClickForward()
    {
        _numberGod++;

        if (_numberGod > _gods.Count - 1)
            _numberGod = 0;

        ChangesGod(_numberGod);
    }

    private void OnButtonClickImprovementSpell()
    {
        _god.IncreaseDamage();
        ChangeSlider();
    }

    private void OnButtonClickImprovementTime()
    {
        _god.ReduceTime();
        ChangeSlider();
    }

    private void ChangesGod(int number)
    {
        _activeGod.SetActive(false);

        if (number >= 0 && number < _gods.Count)
        {
            _activeGod = _gods[number];

            if (_activeGod.TryGetComponent(out God god))
                _god = god;

            _activeGod.SetActive(true);
            ChangeSlider();
        }

        Debug.Log(_god);
    }

    private void ChangeSlider()
    {
        _sliderSpell.value = (float)_god.SpellPower / _god.MaxValue;
        _sliderTime.value = (float)_god.RecycleTimeFactor / _god.MaxValue;
    }
}

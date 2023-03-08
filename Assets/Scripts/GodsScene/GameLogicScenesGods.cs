using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicScenesGods : MonoBehaviour
{
    [SerializeField] private List<God> _gods;
    [SerializeField] private Button _buttonArrowBack;
    [SerializeField] private Button _buttonArrowForward;
    [SerializeField] private Button _buttonImprovementSpell;
    [SerializeField] private Button _buttonImprovementTime;
    [SerializeField] private Button _buttonGoToMenu;
    [SerializeField] private Slider _sliderSpell;
    [SerializeField] private Slider _sliderTime;
    [SerializeField] private TMP_Text _nameGod;
    [SerializeField] private Image _imageGod;

    private int _numberGod;

    private void Awake()
    {
        _numberGod = 0;

        for (int i = 0; i < _gods.Count; i++)
            if (PlayerPrefs.HasKey("ActiveGod"))
                if (_gods[i].Name == PlayerPrefs.GetString("ActiveGod"))
                    _numberGod = i;

        ChangesGod();
    }

    private void OnEnable()
    {
        _buttonArrowBack.onClick.AddListener(OnButtonClickBack);
        _buttonArrowForward.onClick.AddListener(OnButtonClickForward);
        _buttonImprovementSpell.onClick.AddListener(OnButtonClickImprovementSpell);
        _buttonImprovementTime.onClick.AddListener(OnButtonClickImprovementTime);
        _buttonGoToMenu.onClick.AddListener(OnButtonClickGoToMenu);
    }


    private void OnDisable()
    {
        _buttonArrowBack.onClick.RemoveListener(OnButtonClickBack);
        _buttonArrowForward.onClick.RemoveListener(OnButtonClickForward);
        _buttonImprovementSpell.onClick.RemoveListener(OnButtonClickImprovementSpell);
        _buttonImprovementTime.onClick.RemoveListener(OnButtonClickImprovementTime);
        _buttonGoToMenu.onClick.RemoveListener(OnButtonClickGoToMenu);
    }

    private void OnButtonClickBack()
    {
        _numberGod--;

        if (_numberGod < 0)
            _numberGod = _gods.Count - 1;

        ChangesGod();
    }

    private void OnButtonClickForward()
    {
        _numberGod++;

        if (_numberGod > _gods.Count - 1)
            _numberGod = 0;

        ChangesGod();
    }

    private void OnButtonClickImprovementSpell()
    {
        _gods[_numberGod].IncreaseDamage();
        ChangeSlider();
    }

    private void OnButtonClickImprovementTime()
    {
        _gods[_numberGod].ReduceTime();
        ChangeSlider();
    }

    private void OnButtonClickGoToMenu()
    {
        PlayerPrefs.SetString("ActiveGod", _gods[_numberGod].Name);
        SceneManager.LoadScene("MenuScene");
    }

    private void ChangesGod()
    {
        _nameGod.text = _gods[_numberGod].Name;
        _imageGod.sprite = _gods[_numberGod].Image;
        ChangeSlider();
    }

    private void ChangeSlider()
    {
        _sliderSpell.value = (float)_gods[_numberGod].SpellPower / _gods[_numberGod].MaxValue;
        _sliderTime.value = (float)_gods[_numberGod].RecycleTimeFactor / _gods[_numberGod].MaxValue;
    }
}

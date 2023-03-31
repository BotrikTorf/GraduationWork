using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogicSceneUpgrades : MonoBehaviour

{
    [SerializeField] private UnitSO _unitSwordsman;
    [SerializeField] private UnitSO _unitSpearman;
    [SerializeField] private UnitSO _unitArcher;
    [SerializeField] private Button _buttonUpgradeSwordsman;
    [SerializeField] private Button _buttonUpgradeSpearman;
    [SerializeField] private Button _buttonUpgradeArcher;
    [SerializeField] private Image _imageSwordsman;
    [SerializeField] private Image _imageSpearman;
    [SerializeField] private Image _imageArcher;
    [SerializeField] private Image[] _imagesUpgradeSwordsman;
    [SerializeField] private Image[] _imagesUpgradeSpearman;
    [SerializeField] private Image[] _imagesUpgradeArcher;
    [SerializeField] private TMP_Text _textTotalMoney;
    [SerializeField] private TMP_Text _textUpgradeCostSwordsman;
    [SerializeField] private TMP_Text _textUpgradeCostSpearman;
    [SerializeField] private TMP_Text _textUpgradeCostArcher;

    private int _initialUpgradeCost = 75;

    private void Awake()
    {
        DrawPictures(_unitSwordsman, _imagesUpgradeSwordsman, _imageSwordsman);
        DrawPictures(_unitSpearman, _imagesUpgradeSpearman, _imageSpearman);
        DrawPictures(_unitArcher, _imagesUpgradeArcher, _imageArcher);
        _textTotalMoney.text = MoneyGame.Money.ToString();
        _textUpgradeCostArcher.text = (_unitArcher.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();
        _textUpgradeCostSpearman.text = (_unitSpearman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();
        _textUpgradeCostSwordsman.text = (_unitSwordsman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();
    }

    private void OnEnable()
    {
        _buttonUpgradeSwordsman.onClick.AddListener(OnButtonClickUpgradeSwordsman);
        _buttonUpgradeSpearman.onClick.AddListener(OnButtonClickUpgradeSpearman);
        _buttonUpgradeArcher.onClick.AddListener(OnButtonClickUpgradeArcher);
    }

    private void OnDisable()
    {
        _buttonUpgradeSwordsman.onClick.RemoveListener(OnButtonClickUpgradeSwordsman);
        _buttonUpgradeSpearman.onClick.RemoveListener(OnButtonClickUpgradeSpearman);
        _buttonUpgradeArcher.onClick.RemoveListener(OnButtonClickUpgradeArcher);
    }

    private void OnButtonClickUpgradeSwordsman()
    {
        if (MoneyGame.CanReduceMoney(_unitSwordsman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2))
        {
            _unitSwordsman.UpgradeUnit();
            DrawPictures(_unitSwordsman, _imagesUpgradeSwordsman, _imageSwordsman);
            _textUpgradeCostSwordsman.text = (_unitSwordsman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();
        }
    }

    private void OnButtonClickUpgradeSpearman()
    {
        if (MoneyGame.CanReduceMoney(_unitSpearman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2))
        {
            _unitSpearman.UpgradeUnit();
            DrawPictures(_unitSpearman, _imagesUpgradeSpearman, _imageSpearman);
            _textUpgradeCostSpearman.text = (_unitSpearman.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();
        }
    }

    private void OnButtonClickUpgradeArcher()
    {
        if (MoneyGame.CanReduceMoney(_unitArcher.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2))
        {
            _unitArcher.UpgradeUnit();
            DrawPictures(_unitArcher, _imagesUpgradeArcher, _imageArcher);
            _textUpgradeCostArcher.text = (_unitArcher.ImprovementLevel * _initialUpgradeCost + _initialUpgradeCost * 2).ToString();

        }
    }

    private void DrawPictures(UnitSO unit, Image[] images, Image unitImage)
    {
        unitImage.sprite = unit.ImprovementLevel < unit.MaxImprovement - 1
            ? unit.SpriteStartUnit
            : unit.SpriteEndUnit;

        if (unit.ImprovementLevel >= 0)
            for (int i = 0; i <= unit.ImprovementLevel; i++)
            {
                images[i].gameObject.SetActive(true);
                images[i].sprite = unit.SpritesImprovementLevel[i];
            }

        _textTotalMoney.text = MoneyGame.Money.ToString();
    }
}

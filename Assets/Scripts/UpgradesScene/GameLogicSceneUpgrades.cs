using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
        DrawPictures(_unitSwordsman, _imagesUpgradeSwordsman, _imageSwordsman);
        DrawPictures(_unitSpearman, _imagesUpgradeSpearman, _imageSpearman);
        DrawPictures(_unitArcher, _imagesUpgradeArcher, _imageArcher);
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
        _unitSwordsman.UpgradeUnit();
        DrawPictures(_unitSwordsman, _imagesUpgradeSwordsman, _imageSwordsman);
    }

    private void OnButtonClickUpgradeSpearman()
    {
        _unitSpearman.UpgradeUnit();
        DrawPictures(_unitSpearman, _imagesUpgradeSpearman, _imageSpearman);
    }

    private void OnButtonClickUpgradeArcher()
    {
        _unitArcher.UpgradeUnit();
        DrawPictures(_unitArcher, _imagesUpgradeArcher, _imageArcher);
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
    }
}

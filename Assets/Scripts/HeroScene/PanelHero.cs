using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PanelHero : MonoBehaviour
{
    [SerializeField] private Button _buttonSelectRightHero;
    [SerializeField] private Button _buttonSelectLeftHero;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private List<Hero> _heroes;

    private Hero tempHero;

    public event UnityAction<HeroSO> SubstitutionHero;

    private void Awake()
    {
        _name.text = _heroes[1].Name;
        SubstitutionHero?.Invoke(_heroes[1].HeroSO);
        ActiveHeroSave.SetActiveHero(_heroes[1].UnitHero);
    }

    private void OnEnable()
    {
        _buttonSelectLeftHero.onClick.AddListener(OnButtonClickSelectLeftHero);
        _buttonSelectRightHero.onClick.AddListener(OnButtonClickSelectRightHero);
    }

    private void OnDisable()
    {
        _buttonSelectLeftHero.onClick.RemoveListener(OnButtonClickSelectLeftHero);
        _buttonSelectRightHero.onClick.RemoveListener(OnButtonClickSelectRightHero);
    }

    private void OnButtonClickSelectLeftHero()
    {
        InstallButtonSetActive(false);
        StartCoroutine(
            ChangesPlaces(_heroes[1].gameObject, 
                _heroes[0].gameObject));
        tempHero = _heroes[0];
        _heroes[0] = _heroes[1];
        _heroes[1] = tempHero;
        _name.text = _heroes[1].Name;
        SubstitutionHero?.Invoke(_heroes[1].HeroSO);
        ActiveHeroSave.SetActiveHero(_heroes[1].UnitHero);
    }

    private void OnButtonClickSelectRightHero()
    {
        InstallButtonSetActive(false);
         StartCoroutine(
            ChangesPlaces(_heroes[1].gameObject, 
                _heroes[2].gameObject));
        tempHero = _heroes[2];
        _heroes[2] = _heroes[1];
        _heroes[1] = tempHero;
        _name.text = _heroes[1].Name;
        SubstitutionHero?.Invoke(_heroes[1].HeroSO);
        ActiveHeroSave.SetActiveHero(_heroes[1].UnitHero);
    }

    private IEnumerator ChangesPlaces(GameObject heroShrinkable, GameObject heroExpandable)
    {
        Vector2 startPosition = heroShrinkable.transform.position;
        Vector2 endPosition = heroExpandable.transform.position;
        Vector2 startScale = heroShrinkable.transform.localScale;
        Vector2 endScale = heroExpandable.transform.localScale;
        float deltaPosition = 0;

        while (deltaPosition <= 1)
        {
            heroShrinkable.transform.position = Vector3.Lerp(startPosition, endPosition, deltaPosition);
            heroExpandable.transform.position = Vector3.Lerp(endPosition, startPosition, deltaPosition);
            heroShrinkable.transform.localScale = Vector3.Lerp(startScale, endScale, deltaPosition);
            heroExpandable.transform.localScale = Vector3.Lerp(endScale, startScale, deltaPosition);
            deltaPosition += Time.deltaTime;
            yield return null;
        }

        heroExpandable.transform.position = startPosition;
        heroShrinkable.transform.position = endPosition;
        heroExpandable.transform.localScale = startScale;
        heroShrinkable.transform.localScale = endScale;
        InstallButtonSetActive(true);
    }

    private void InstallButtonSetActive(bool value)
    {
        _buttonSelectLeftHero.gameObject.SetActive(value);
        _buttonSelectRightHero.gameObject.SetActive(value);
    }
}

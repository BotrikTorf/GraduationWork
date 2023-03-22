using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private UnitGame _unitGame;

    private void OnEnable() => _unitGame.HealthChanged += OnValueChanged;

    private void OnDisable() => _unitGame.HealthChanged -= OnValueChanged;

    private void Start()
    {
        SliderBar.gameObject.SetActive(false);
        SliderBar.value = 1;
    }

    public override void OnSetActive() => SliderBar.gameObject.SetActive(true);

}

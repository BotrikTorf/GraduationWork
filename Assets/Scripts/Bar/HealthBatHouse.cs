using UnityEngine;

public class HealthBatHouse : Bar
{
    [SerializeField] private House _house;

    private void OnEnable() => _house.HealthChanged += OnValueChanged;

    private void OnDisable() => _house.HealthChanged -= OnValueChanged;

    private void Start()
    {
        SliderBar.gameObject.SetActive(false);
        SliderBar.value = 1;
    }

    public override void OnSetActive() => SliderBar.gameObject.SetActive(true);
}

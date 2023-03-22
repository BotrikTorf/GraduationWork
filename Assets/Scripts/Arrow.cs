using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform _transform;
    private float _speed = 5f;
    private float _liftingHeight = 2f;

    private void Start() => _transform = transform;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out UnitGameNegative _) || collider.TryGetComponent(out HouseEnemies _))
            Destroy(gameObject);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime,
        transform.position.y + _liftingHeight * Mathf.Sin(transform.rotation.z * Mathf.PI / 180),
        _transform.position.z);
    }
}

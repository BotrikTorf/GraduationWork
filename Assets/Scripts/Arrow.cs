using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float _speed = 5f;
    private float _timeExistence = 0.8f;

    private void Start() => Destroy(gameObject, _timeExistence);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out UnitGameNegative _) || collider.TryGetComponent(out HouseEnemies _))
            Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + _speed * Time.deltaTime,
        transform.position.y + Mathf.Sin(transform.rotation.z * Mathf.PI / 180),
        transform.position.z);
    }
}

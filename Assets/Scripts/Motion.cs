using UnityEngine;

public class Motion : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _amplitude = 1.0f;
    private Vector3 _startPosition;

    [SerializeField] private float _rotationSpeed = 10f;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * _speed) * _amplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}

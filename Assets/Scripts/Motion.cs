using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speed = 1.0f;
    public float amplitude = 1.0f;
    Vector3 startPosition;

    public float rotationSpeed = 10f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

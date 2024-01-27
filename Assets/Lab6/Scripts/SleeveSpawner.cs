using System.Collections;
using UnityEngine;

namespace Assets.Lab6.Scripts
{
    public class SleeveSpawner : MonoBehaviour
    {
        [SerializeField] private float _rangeSpawn = 0.0f;
        [SerializeField] private float _force = 0.0f;

        [SerializeField] private GameObject _sleeve;

        public void SpawnSleeve()
        {
            var objectToSpawn = _sleeve;

            var spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);

            var spawnedObjectRigidbody = spawnedObject.GetComponent<Rigidbody>();
            spawnedObjectRigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
            spawnedObjectRigidbody.AddTorque(transform.forward * _force, ForceMode.Impulse);
        }
    }
}
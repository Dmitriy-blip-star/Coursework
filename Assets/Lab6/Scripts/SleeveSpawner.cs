using System.Collections;
using UnityEngine;

namespace Assets.Lab6.Scripts
{
    public class SleeveSpawner : MonoBehaviour
    {
        public float rangeSpawn = 0.0f;
        public float force = 0.0f;

        public GameObject sleeve;

        public void SpawnSleeve()
        {
            var objectToSpawn = sleeve;

            var spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
            //spawnedObject.transform.position = new Vector3(transform.position.x + Random.Range(-rangeSpawn, rangeSpawn), transform.position.y, transform.position.z);

            var spawnedObjectRigidbody = spawnedObject.GetComponent<Rigidbody>();
            spawnedObjectRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
            spawnedObjectRigidbody.AddTorque(transform.forward * force, ForceMode.Impulse);
        }
    }
}
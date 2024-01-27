using UnityEngine;

namespace Assets.Scripts
{
    public class Item : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Movement>())
            {
                other.GetComponent<Movement>().PickupItem();
                Destroy(gameObject);
            }
        }
    }
}
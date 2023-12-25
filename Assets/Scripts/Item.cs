using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Item : MonoBehaviour
    {
    //    [SerializeField] Controll c;

    //    public void Collecting()
    //    {
    //        Destroy(gameObject);
    //    }

    //    private void OnMouseDown()
    //    {
    //        c.PickUpItem();
    //    }

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
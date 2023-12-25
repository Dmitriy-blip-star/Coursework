using UnityEngine;

namespace Assets.Lab6.Scripts
{
    public class Gun : MonoBehaviour
    {
        public int damage = 10;
        public float range = 1000f;

        public float fireRate = 10;
        public float nextShot = 0;

        public Camera cam;
        public GameObject flash;
        public ParticleSystem onHit;

        public SleeveSpawner sleeveSpawner;

        private void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextShot)
            {
                flash.SetActive(true);
                nextShot = Time.time + 1 / fireRate;
                Shoot();
                sleeveSpawner.SpawnSleeve();
            }

            if (Input.GetMouseButtonUp(0))
            {
                flash.SetActive(false);
            }
        }

        private void Shoot()
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("Target"))
                {
                    Enemy e = hit.transform.GetComponent<Enemy>();
                    e.Hit(damage);
                }
                ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
                hitEffect.Play();
                Destroy(hitEffect.gameObject, 1f);
            }
        }
    }
}
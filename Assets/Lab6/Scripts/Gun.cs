using UnityEngine;

namespace Assets.Lab6.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private int _damage = 10;

        [SerializeField] private float _fireRate = 10;
        [SerializeField] private float _nextShot = 0;

        [SerializeField] private Camera _cam;
        [SerializeField] private GameObject _flash;
        [SerializeField] private ParticleSystem _onHit;

        [SerializeField] private SleeveSpawner _sleeveSpawner;

        private void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= _nextShot)
            {
                _flash.SetActive(true);
                _nextShot = Time.time + 1 / _fireRate;
                Shoot();
                _sleeveSpawner.SpawnSleeve();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _flash.SetActive(false);
            }
        }

        private void Shoot()
        {
            RaycastHit hit;
            if(Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit))
            {
                if (hit.transform.CompareTag("Target"))
                {
                    //Enemy e = hit.transform.GetComponent<Enemy>();
                    //e.Hit(damage);
                    hit.transform.GetComponent<Enemy>().Hit(_damage);
                }
                ParticleSystem hitEffect = Instantiate(_onHit, hit.point, Quaternion.LookRotation(hit.normal));
                hitEffect.Play();
                Destroy(hitEffect.gameObject, 1f);
            }
        }
    }
}
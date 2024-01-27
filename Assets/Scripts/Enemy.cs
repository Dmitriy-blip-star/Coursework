using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _detectedRadius = 10;
    [SerializeField] private LayerMask _playerLayer;
    private int _ind = 0;
    [SerializeField] private float _atkRadius = 1;
    private Animator _anim;

    private NavMeshAgent _agent;

    [SerializeField] private int _damage = 10;
    [SerializeField] private int _maxHealth = 30;
    private int _health;

    public static int Deaths { get; private set; }

    [SerializeField] private ParticleSystem _explotion;

    private void Start()
    {
        _health = _maxHealth;
        _agent= GetComponent<NavMeshAgent>();
        _agent.SetDestination(_waypoints[_ind].position);
        _anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, _waypoints[_ind].position) < 1.5f)
        {
            _ind++;
            if (_ind >= _waypoints.Length)
            {
                _ind = 0;
            }
            _agent.SetDestination(_waypoints[_ind].position);
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, _detectedRadius, _playerLayer);

        if (_agent.velocity.magnitude > 0.1f)
        {
            _anim.SetInteger("state", 1);
        }

        if (cols.Length > 0)
        {
            if (Vector3.Distance(transform.position, cols[0].transform.position) <= _atkRadius)
            {
                _agent.SetDestination(transform.position);
                _anim.SetInteger("state", 2);
            }
            else
            {
                _agent.SetDestination(cols[0].transform.position);
            }
        }
        else
        {
            _agent.SetDestination(_waypoints[_ind].position);
        }

    }

    public void Hit(int damage)
    {
        _health -= damage;
        print($"Enemy health: {_health}");
        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Deaths++;
        ParticleSystem exp = Instantiate(_explotion, transform.position, transform.rotation);
        exp.Play();
        Destroy(exp, 1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            other.GetComponent<Movement>().TakeDamage(_damage);
        }
    }
}

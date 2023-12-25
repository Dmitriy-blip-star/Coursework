using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float detectedRadius = 10;
    public LayerMask playerLayer;
    int ind = 0;
    public float atkRadius = 1;
    Animator anim;

    NavMeshAgent agent;

    public int damage = 10;
    public int maxHealth = 30;
    int health;

    public static int deaths;

    public ParticleSystem explotion;

    private void Start()
    {
        health = maxHealth;
        agent= GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[ind].position);
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[ind].position) < 1.5f)
        {
            ind++;
            if (ind >= waypoints.Length)
            {
                ind = 0;
            }
            agent.SetDestination(waypoints[ind].position);
        }

        Collider[] cols = Physics.OverlapSphere(transform.position, detectedRadius, playerLayer);

        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetInteger("state", 1);
        }

        if (cols.Length > 0)
        {
            if (Vector3.Distance(transform.position, cols[0].transform.position) <= atkRadius)
            {
                agent.SetDestination(transform.position);
                anim.SetInteger("state", 2);
            }
            else
            {
                agent.SetDestination(cols[0].transform.position);
            }
        }
        else
        {
            agent.SetDestination(waypoints[ind].position);
        }

    }

    public void Hit(int damage)
    {
        health -= damage;
        print($"Enemy health: {health}");
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        deaths++;
        ParticleSystem exp = Instantiate(explotion, transform.position, transform.rotation);
        exp.Play();
        Destroy(exp, 1f);
        Destroy(gameObject);
    }

    public void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectedRadius, playerLayer);
        if (cols.Length > 0)
        {
            Controll c = cols[0].transform.GetComponent<Controll>();
            if (c != null)
            {
                c.TakeDamage();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            other.GetComponent<Movement>().TakeDamage(damage);
        }
    }
}

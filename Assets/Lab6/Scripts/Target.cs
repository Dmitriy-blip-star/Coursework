using UnityEngine;

public class Target : MonoBehaviour
{
    float hp = 10;
    public ParticleSystem explotion;
    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        ParticleSystem exp = Instantiate(explotion, transform.position, transform.rotation);
        exp.Play();
        Destroy(exp, 1f);
        Destroy(gameObject);
    }
}

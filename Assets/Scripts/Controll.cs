using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controll : MonoBehaviour
{
    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    Animator anim;
    bool dead = false;
    public float detectedRadius = 1;
    public LayerMask itemLayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (dead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000f, ground))
                {
                    agent.SetDestination(hit.point);
                }
            }

            if (agent.velocity.magnitude > 0.1f)
            {
                anim.SetInteger("state", 1);
            }
            else
            {
                anim.SetInteger("state", 0);
            }

        }
    }

    public void TakeDamage()
    {
        dead = true;
        agent.SetDestination(transform.position);
        anim.SetInteger("state", 3);
        Destroy(gameObject, 2);
    }

    public void PickUpItem()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectedRadius, itemLayer);
        if (cols.Length > 0)
        {
            Item i = cols[0].transform.GetComponent<Item>();
            if (i != null)
            {
               // i.Collecting();
            }
        }
    }
}

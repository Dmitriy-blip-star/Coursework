using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalScript : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    public float speed = 0;
    public float speedRun = 4;

    bool isGround = true;
    public float rayDistance = 0.7f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        isGround = Physics.Raycast(transform.position, -Vector3.up, rayDistance);

        if (Input.GetAxis("Vertical") > 0)
        {
            //Vector3 v;
            animator.SetInteger("State", 1);
            //v = transform.forward * speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetInteger("State", 2);
                //v = transform.forward * speedRun;
            }
            //rb.velocity = v;
        }
        else if (Input.GetAxis("Vertical") <= 0)
        {
            animator.SetInteger("State", 0);
        }
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transform.Rotate(Vector3.up, 90 * Time.deltaTime, Space.Self);
        //}
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transform.Rotate(Vector3.up, -90 * Time.deltaTime, Space.Self);
        //}
    }
    }

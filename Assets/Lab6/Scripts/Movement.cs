using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [Range(50, 200)]
    public float walkSpeed = 100;
    [Range(100, 500)]
    public float runSpeed = 200;
    private float mSpeed = 100f;

    public GameObject failPanel;
    public GameObject winPanel;
    public GameObject nextLvlPanel;

    public int maxHealth = 100;
    public static int health;

    public Camera cam;
    public float baseFOV = 75;
    public float sprintFOV = 90;
    public float speedChangeFOV = 2f;
    public float curentFOV;

    Animator anim;
    Rigidbody rb;

    public static int items;
    public static int itemsForWin = 1;

    void Start()
    {
        health = maxHealth;
        anim= GetComponent<Animator>();
        curentFOV = baseFOV;
        rb = GetComponent<Rigidbody>();
        items = 0;
        Time.timeScale = 1;
    }
    void FixedUpdate()
    {
        bool sprint = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        if (sprint == true && zMove > 0)
        {
            mSpeed = runSpeed;
            curentFOV += speedChangeFOV * Time.deltaTime;
            curentFOV = Mathf.Clamp(curentFOV, baseFOV, sprintFOV);
            cam.fieldOfView = curentFOV;           
        }
        else
        {
            mSpeed = walkSpeed;
            curentFOV -= speedChangeFOV * Time.deltaTime;
            curentFOV = Mathf.Clamp(curentFOV, baseFOV, sprintFOV);
            cam.fieldOfView = curentFOV;
        }

        if (rb.velocity.x > 0.1f || rb.velocity.z > 0.1f)
        {
            anim.SetInteger("state", 1);
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        Vector3 dir = new Vector3(xMove, 0, zMove);
        dir.Normalize();
        
        Vector3 v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
        v.y = rb.velocity.y;
        rb.velocity = v;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            failPanel.SetActive(true);
            itemsForWin = 1;
            Time.timeScale = 0;
        }
    }

    public void PickupItem()
    {
        items++;
        if (items == 2)
        {
            Cursor.lockState = CursorLockMode.None;
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(items == itemsForWin)
        {
            itemsForWin *= 2;
            Cursor.lockState = CursorLockMode.None;
            nextLvlPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

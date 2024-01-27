using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(50, 200)]
    [SerializeField] private float _walkSpeed = 100;
    [Range(100, 500)]
    [SerializeField] private float _runSpeed = 200;
    private float _mSpeed = 100f;

    [SerializeField] private GameObject _failPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _nextLvlPanel;

    [SerializeField] private int MaxHealth = 100;
    public static int Health { get; private set; }

    [SerializeField] private Camera _cam;
    [SerializeField] private float _baseFOV = 75;
    [SerializeField] private float _sprintFOV = 90;
    [SerializeField] private float speedChangeFOV = 2f;
    private float _curentFOV;

    private Animator _anim;
    private Rigidbody _rb;

    public static int Items { get; private set; }
    public static int ItemsForWin { get; private set; } = 10;

    void Start()
    {
        
        Health = MaxHealth;
        _anim= GetComponent<Animator>();
        _curentFOV = _baseFOV;
        _rb = GetComponent<Rigidbody>();
        Items = 0;
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        bool sprint = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        if (sprint && zMove > 0)
        {
            _mSpeed = _runSpeed;
            _curentFOV += speedChangeFOV * Time.deltaTime;
            _curentFOV = Mathf.Clamp(_curentFOV, _baseFOV, _sprintFOV);
            _cam.fieldOfView = _curentFOV;           
        }
        else
        {
            _mSpeed = _walkSpeed;
            _curentFOV -= speedChangeFOV * Time.deltaTime;
            _curentFOV = Mathf.Clamp(_curentFOV, _baseFOV, _sprintFOV);
            _cam.fieldOfView = _curentFOV;
        }

        if (_rb.velocity.x > 0.1f || _rb.velocity.z > 0.1f)
        {
            _anim.SetInteger("state", 1);
        }
        else
        {
            _anim.SetInteger("state", 0);
        }

        Vector3 dir = new Vector3(xMove, 0, zMove);
        dir.Normalize();
        
        Vector3 v = transform.TransformDirection(dir) * _mSpeed * Time.fixedDeltaTime;
        v.y = _rb.velocity.y;
        _rb.velocity = v;

        
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            _failPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PickupItem()
    {
        Items++;
        if (Items == 20)
        {
            Cursor.lockState = CursorLockMode.None;
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Items == ItemsForWin)
        {
            ItemsForWin *= 2;
            Cursor.lockState = CursorLockMode.None;
            _nextLvlPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

using UnityEngine;

    public class Looking : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _cam;
    [Range(50f, 1000f)]
    [SerializeField] private float _xSens = 70f;
    [Range(50f, 1000f)]
    [SerializeField] private float _ySens = 70f;
    private Quaternion _center;
    void Start()
    {
        _center = _cam.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _ySens * Time.deltaTime;
        Quaternion yRot = _cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);
        
        if (Quaternion.Angle(_center, yRot) < 90f)
            _cam.localRotation = yRot; 
                                      
        float mouseX = Input.GetAxis("Mouse X") * _xSens * Time.deltaTime;
        Quaternion xRot = _player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);
        _player.localRotation = xRot;

    }
}
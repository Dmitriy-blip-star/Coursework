using UnityEngine;

    public class Looking : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    [Range(50f, 1000f)]
    public float xSens = 70f;
    [Range(50f, 1000f)]
    public float ySens = 70f;
    Quaternion center;
    void Start()
    {
        center = cam.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);
        
        if (Quaternion.Angle(center, yRot) < 90f)
            cam.localRotation = yRot; 
                                      
        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);
        player.localRotation = xRot;

    }
}
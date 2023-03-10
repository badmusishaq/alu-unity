using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isInverted;
    //-----Privates variables-----\\
    private Vector3 offset;

    //-----Publics variables-----\\
    [Header("Variables")]
    public Transform player;

    [Space]
    [Header("Position")]
    public float camPosX;
    public float camPosY;
    public float camPosZ;

    [Space]
    [Header("Rotation")]
    public float camRotationX;
    public float camRotationY;
    public float camRotationZ;

    [Space]
    [Range(0f, 10f)]
    public float turnSpeed;

    //-----Privates functions-----\\
    private void Start()
    {
        offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
    }


    private void LateUpdate()
    {
        if (!PauseMenu.GameIsPause)
        {
            if (isInverted)
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
            else
                offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }
    }
}

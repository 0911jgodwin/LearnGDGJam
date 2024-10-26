using UnityEngine;

public class FolCam : MonoBehaviour
{
    private float camX;
    void LateUpdate()
    {
        camX = Camera.main.transform.position.x;
        transform.position = new Vector3(camX, transform.position.y, transform.position.z);
    }
}

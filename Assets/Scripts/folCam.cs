using UnityEngine;

public class folCam : MonoBehaviour
{
    private float camx;

    void LateUpdate()
    {
        camx = Camera.main.transform.position.x;

        transform.position = new Vector3(camx, transform.position.y, transform.position.z);
    }

}

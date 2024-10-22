using Unity.Cinemachine;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject _virtualCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _virtualCamera.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _virtualCamera.SetActive(false);
        }
    }
}

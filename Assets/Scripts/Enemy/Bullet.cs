using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 moveDirection;
    private float moveSpeed;
    private Rigidbody2D _rb;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    private void Start()
    {
        moveSpeed = 10f;
    }

    private void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
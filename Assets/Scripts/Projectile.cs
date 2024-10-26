using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float lifetime = 3f;
    [SerializeField] Vector3 direction = Vector3.zero;

    public void SetDirection(Vector3 _direction)
    {
        direction = _direction;
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        lifetime -= Time.deltaTime;
        if ( lifetime <= 0 )
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("MainCamera") && !collision.CompareTag("Player") && !collision.CompareTag("Passthrough"))
        {
            if (collision.CompareTag("Enemy"))
                collision.gameObject.GetComponent<Health>().Damage(1f);
            Destroy(gameObject);
        }
    }
}

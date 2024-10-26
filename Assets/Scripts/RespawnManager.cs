using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour 
{
    private Vector2 spawnPosition;
    private Rigidbody2D _rb;
    public float playerHealth = 3f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spawnPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        } else if (collision.CompareTag("Respawn"))
        {
            SetSpawnPoint(collision.transform.position);
        }
    }

    private void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    public void SetSpawnPoint(Vector2 newSpawn)
    {
        spawnPosition = newSpawn;
    }

    public void Damage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0f)
            Die();
    }

    IEnumerator Respawn(float duration)
    {
        _rb.simulated = false;
        _rb.linearVelocity = Vector2.zero;
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = spawnPosition;
        yield return new WaitForSeconds(duration);
        _rb.simulated = true;
        transform.localScale = new Vector3(1, 1, 1);
        playerHealth = 3f;
    }
}

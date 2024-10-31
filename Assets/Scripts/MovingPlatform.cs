using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float TravelTime = 3f;
    [SerializeField] float WaitTime = 2f;
    [SerializeField] Vector2 EndPosition = Vector2.zero;
    [SerializeField] bool StartWaiting = false;
    private Vector2 StartPosition = Vector2.zero;
    private float t = 0f;
    private float something = 0f;
    private BoxCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private bool startsMoving;
    private bool isWaiting;

    private void Awake()
    {
        isWaiting = !StartWaiting;
        StartPosition = transform.position;
    }

    private void Update()
    {
        if (something <= 0f && isWaiting)
        {
            isWaiting = false;
            something = TravelTime;
            t = 0f;
        }
        else if (something <= 0f && !isWaiting) 
        {
            isWaiting = true;
            something = WaitTime;
            Vector2 temp = EndPosition;
            EndPosition = StartPosition;
            StartPosition = temp;
        }

        if (something > 0f && !isWaiting)
        {
            t += Time.deltaTime / TravelTime;
            Movement();
        }
                
        something -= Time.deltaTime;
    }

    private void Movement()
    {
        transform.position = Vector2.Lerp(StartPosition, EndPosition, t);
    }
}

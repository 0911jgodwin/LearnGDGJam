using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    [SerializeField] float StateTiming = 3f;
    private float something = 0f;
    private BoxCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private bool startsEnabled;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        startsEnabled = _collider.enabled;
    }

    private void OnEnable()
    {
        
        _collider.enabled = startsEnabled;
    }

    private void Update()
    {
        if (something <= 0f)
            ToggleState();
        something -= Time.deltaTime;
    }

    private void ToggleState()
    {
        if (_collider.enabled)
        {
            _collider.enabled = false;
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _collider.enabled = true;
            _spriteRenderer.color = Color.white;
        }

        something = StateTiming;
    }
}

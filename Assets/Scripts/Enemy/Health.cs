using UnityEngine;

public class Health : MonoBehaviour
{
    private float totalHealth = 1f;

    public void SetHealth(float value)
    {
        totalHealth = value;
    }

    public void Damage(float value)
    {
        totalHealth -= value;

        if (totalHealth < 0f)
            DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

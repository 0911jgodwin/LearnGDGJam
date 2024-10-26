using Learn.PlayerController;
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float angle = 0f;
    private Vector2 bulletMoveDirection;
    private Transform shield;
    private bool SpiralFiring = false;
    private bool WaveFiring = true;
    private bool BurstFiring = false;
    private float currentFireLockout = 0f;
    public float patternLockout = 4f;
    private bool patternFinished = false;
    private bool patternInProgress = false;
    private int nextPattern = 3;

    // Update is called once per frame
    void Start()
    {
        shield = transform.GetChild(0);
        GetComponent<Health>().SetHealth(100f);
    }

    private void Update()
    {
        currentFireLockout -= Time.deltaTime;
        patternLockout -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        shield.eulerAngles = new Vector3(0, 0, shield.eulerAngles.z + 0.5f);
        if (patternFinished)
            EndPattern();

        if (patternLockout > 0f)
            return;
            
        if (SpiralFiring && currentFireLockout <= 0f)
        {
            currentFireLockout = 0.2f;
            SpiralFire();
        }

        if (BurstFiring && currentFireLockout <= 0f)
        {
            currentFireLockout = 0.5f;
            BurstFire();
        }

        if (WaveFiring && currentFireLockout <= 0f)
        {
            currentFireLockout = 0.2f;
            WaveFire();
        }
    }

    private void EndPattern()
    {
        SpiralFiring = false;
        WaveFiring = false;
        BurstFiring = false;

        angle = 0f;
        int randomPattern;
        do
        {
            randomPattern = Random.Range(1, 4);
        } while (nextPattern == randomPattern);

        nextPattern = randomPattern;
        patternLockout = Random.Range(3, 6);

        switch (nextPattern)
        {
                case 1:
                    SpiralFiring = true;
                    break;
                case 2:
                    BurstFiring = true;
                    break;
                case 3:
                    WaveFiring = true;
                    break;
        }
        patternFinished = false;
    }
    private void SpiralFire()
    {
        for (int i = 0; i <= 1; i++)
        {
            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            bul.transform.eulerAngles = new Vector3(0, 0, (angle+180*i));
            bul.SetActive(true);
        }

        angle += 10f;

        if (angle >= 360f)
            patternFinished = true;
    }

    private void BurstFire()
    {
        for (int i = 0; i <= 1; i++)
        {
            for (int k = -60; k <= 30; k+=30)
            {
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
                bul.transform.eulerAngles = new Vector3(0, 0, (angle + k + (180 * i)));
                bul.SetActive(true);
            }
        }

        angle += 90f;

        if (angle >= 540f)
            patternFinished = true;
    }

    private void WaveFire()
    {
        for (int i = -1; i <= 1; i+=2)
        {
            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            bul.transform.eulerAngles = new Vector3(0, 0, (0 + angle * i));
            bul.SetActive(true);
        }

        angle += 10f;

        if (angle >= 540)
            patternFinished = true;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    public List<GameObject> gameObjectsToEnable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            foreach (GameObject obj in gameObjectsToEnable)
            {
                obj.SetActive(true);
            }
        }
    }
}
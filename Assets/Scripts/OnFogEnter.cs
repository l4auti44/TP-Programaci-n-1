using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFogEnter : MonoBehaviour
{
    private bool isInFog = false;
    private float durationToDeath = 5.1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered fog area");
            isInFog = true;
            EventManager.Game.OnFogEnter?.Invoke(true);
        }
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().OnFog();
            Debug.Log("Enemy entered fog area");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited fog area");
            isInFog = false;
            EventManager.Game.OnFogEnter?.Invoke(false);
        }
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().OffFog();
            Debug.Log("Enemy exited fog area");
        }
    }

    void Update()
    {
        if (isInFog)
        {
            durationToDeath -= Time.deltaTime;
            if (durationToDeath <= 0f)
            {
                Debug.Log("Player has died in the fog");
                EventManager.Game.OnPlayerDead?.Invoke();
                durationToDeath = 9999f; // Reset timer after death
                
            }
        }
        else
        {
            durationToDeath = 5f; // Reset timer when out of fog
        }
    }
}

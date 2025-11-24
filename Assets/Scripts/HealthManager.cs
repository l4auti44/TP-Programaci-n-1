using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public float health = 100f;
    public float Health { get { return health; } }
    
    private PlayerStateManager _stateManager;

    void Start()
    {
        if (transform.parent.CompareTag("Player"))
        {
            _stateManager = GetComponent<PlayerStateManager>();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(transform.parent.name + " took " + damage + " damage. Remaining health: " + health);
        if (health <= 0)
        {
            health = 0;
            OnDead();
        }
    }

    private void OnDead()
    {
        Debug.Log("Ship " + transform.parent.name + " has been destroyed!");
        if (transform.parent.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            _stateManager.ChangeState(PlayerStateManager.PlayerState.GameOver);
        }
        else
        {
            GetComponent<DeadAIManager>().OnDeadAI();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            CannonBall cannonBall = collision.gameObject.GetComponent<CannonBall>();
            TakeDamage(cannonBall.damage);
            Destroy(collision.gameObject);
        }
    }
}

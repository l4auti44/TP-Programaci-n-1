using System.Collections;
using System.Collections.Generic;
using BarthaSzabolcs.Tutorial_SpriteFlash;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public float health = 100f;
    
    public float Health { get { return health; } }

    private float maxHealth;
    
    private PlayerStateManager _stateManager;
    private UIManager _uiManager;

    private HealthBar healthBar;
    
    private ShakeCamera shakeCamera;

    void Awake()
    {
        maxHealth = health;
    }
    void Start()
    {
        
        if (transform.parent.CompareTag("Player"))
        {
            _stateManager = GetComponent<PlayerStateManager>();
            _uiManager = FindObjectOfType<UIManager>();
            shakeCamera = transform.parent.GetComponentInChildren<ShakeCamera>();
        }
        if (transform.parent.CompareTag("Enemy"))
        {
            healthBar = transform.Find("HealthBar").GetComponent<HealthBar>();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(transform.parent.name + " took " + damage + " damage. Remaining health: " + health);
        if (transform.parent.CompareTag("Player"))
        {
            shakeCamera.duration = 0.3f;
            shakeCamera.Shake();
            _uiManager.UpdateHealthText((int)health, 100);
        }
        if (health <= 0)
        {
            health = 0;
            OnDead();
        }
        if (transform.parent.CompareTag("Enemy"))
        {
            transform.parent.GetComponentInChildren<HealthBar>().UpdateHealthBar();
            if (health > 0)
                GetComponentInChildren<SimpleFlash>().Flash();
        }
    }

    private void OnDead()
    {
        Debug.Log("Ship " + transform.parent.name + " has been destroyed!");
        if (transform.parent.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            _stateManager.ChangeState(PlayerStateManager.PlayerState.GameOver);
            FindObjectOfType<GameController>().OnDead();
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


    void OnEnable()
    {
        if (transform.parent.CompareTag("Player"))
            EventManager.Game.OnPlayerDead += OnDead;

    }
    void OnDisable()
    {
        if (transform.parent.CompareTag("Player"))
            EventManager.Game.OnPlayerDead -= OnDead;

    }

    public float GetHealthPercentage()
    {
        return health / maxHealth;
    }
}

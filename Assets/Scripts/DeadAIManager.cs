using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAIManager : MonoBehaviour
{
    [SerializeField] private Sprite deadSprite;
    [SerializeField] public GameObject treasurePrefab;
    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    public void OnDeadAI()
    {
        FindObjectOfType<GameController>().EnemyDefeated();
        transform.GetComponent<ShipController>().enabled = false;
        transform.GetComponent<CannonsManager>().enabled = false;
        transform.GetComponent<EnemyController>().enabled = false;
        transform.GetComponent<CapsuleCollider2D>().enabled = false;
        transform.parent.Find("Sail").gameObject.SetActive(false);
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = deadSprite;
        healthBar.HideHealthBar();
        Instantiate(treasurePrefab, transform.position, Quaternion.identity);
        SoundManager.PlaySound(SoundManager.Sound.Dead);
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

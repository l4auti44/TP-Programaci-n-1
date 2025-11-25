using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private int goldAmount = 50;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.Game.OnTreasurePicked?.Invoke(goldAmount);
            //EventManager.Game.OnGamePaused?.Invoke();
            //StateManager.Instance.ChangeState(StateManager.GameState.Paused);
            //FindObjectOfType<GameController>().CollectTreasure();
            Destroy(gameObject);
        }
    }
}

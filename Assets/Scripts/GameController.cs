using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private PlayerStateManager PlayerStateManager;

    public int enemiesToDefeat = 2;

    public void EnemyDefeated()
    {
        enemiesToDefeat -= 1;
        FindObjectOfType<UIManager>().UpdateEnemiesLeftText((int)enemiesToDefeat);
        if (enemiesToDefeat <= 0)
        {
            Debug.Log("All enemies defeated! You win!");
            PlayerStateManager.ChangeState(PlayerStateManager.PlayerState.Win);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0f)
                EventManager.Game.OnGameResumed?.Invoke();
            else
            EventManager.Game.OnGamePaused?.Invoke();
        }
    }

    public void OnGamePaused()
    {
        Time.timeScale = 0f;
    }

        public void OnGameResumed()
    {
        Time.timeScale = 1f;
    }

    void OnEnable()
    {
        EventManager.Game.OnGamePaused += OnGamePaused;
        EventManager.Game.OnGameResumed += OnGameResumed;
    }
    void OnDisable()
    {
        EventManager.Game.OnTreasurePicked -= OnGamePaused;
        EventManager.Game.OnGameResumed -= OnGameResumed;
    }

}

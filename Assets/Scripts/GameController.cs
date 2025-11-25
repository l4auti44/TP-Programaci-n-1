using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private PlayerStateManager PlayerStateManager;
    private UIManager uiManager;

    public int enemiesToDefeat = 4;

    public int gold = 0;


    void Start()
    {
        SoundManager.PlayBackgroundMusic(SoundManager.Sound.Music);
        SoundManager.PlayBackgroundMusic(SoundManager.Sound.Wind);
        uiManager = FindObjectOfType<UIManager>();
    }

    public void EnemyDefeated()
    {
        enemiesToDefeat -= 1;
        uiManager.UpdateEnemiesLeftText((int)enemiesToDefeat);
        if (enemiesToDefeat <= 0)
        {
            Debug.Log("All enemies defeated! You win!");
            PlayerStateManager.ChangeState(PlayerStateManager.PlayerState.Win);
            uiManager.ShowQuitButton();
            OnGamePaused();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && PlayerStateManager.currentState != PlayerStateManager.PlayerState.Win 
        && PlayerStateManager.currentState != PlayerStateManager.PlayerState.GameOver)
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

    private void AddGoldAmount(int amount)
    {
        gold += amount;
        uiManager.UpdateGoldText(gold);
        
    }

    public void DecreaseGold(int amount)
    {
        gold -= amount;
        uiManager.UpdateGoldText(gold);
    }

    public void OnDead()
    {
        uiManager.ShowQuitButton();
        OnGamePaused();
    }
    void OnEnable()
    {
        EventManager.Game.OnGamePaused += OnGamePaused;
        EventManager.Game.OnGameResumed += OnGameResumed;
        EventManager.Game.OnTreasurePicked += AddGoldAmount;
    }
    void OnDisable()
    {
        EventManager.Game.OnGameResumed -= OnGamePaused;
        EventManager.Game.OnGameResumed -= OnGameResumed;
        EventManager.Game.OnTreasurePicked -= AddGoldAmount;
    }


    
}

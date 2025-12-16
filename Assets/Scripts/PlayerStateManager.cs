using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{

    [HideInInspector]
    public enum PlayerState
    {
        Menu,
        Cruising,
        Cannons,
        Paused,
        GameOver,
        Win
    }


    [SerializeField] private UIManager uiManager;
    public PlayerState currentState;


    void Start()
    {
        currentState = PlayerState.Cruising;
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
        checkWinOrLose();
        if (currentState == PlayerState.Paused)
        {
            uiManager.ShowPauseMenu();
        }
        else
        {
            uiManager.HidePauseMenu();
        }
    }

    private void checkWinOrLose()
    {
        if (currentState == PlayerState.GameOver)
        {
            uiManager.ChangeGameStateText("Game Over");
        }
        else if (currentState == PlayerState.Win)
        {
            uiManager.ChangeGameStateText("You Win!");
        }
    }
}

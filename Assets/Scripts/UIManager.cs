using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CannonInstructionText;
    [SerializeField] private TextMeshProUGUI SailsInstructionText;
    [SerializeField] private TextMeshProUGUI CruisingInstructionText;
    [SerializeField] private TextMeshProUGUI GameStateText;

    [SerializeField] private PlayerStateManager playerStateManager;

    [SerializeField] private TextMeshProUGUI enemiesLeftText;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private TextMeshProUGUI goldText;



    // Start is called before the first frame update
    void Start()
    {
        GameStateText.gameObject.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cannons)
        {
            CannonInstructionText.gameObject.SetActive(true);
        }
        else
        {
            CannonInstructionText.gameObject.SetActive(false);
        }

        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Sailing)
        {
            SailsInstructionText.gameObject.SetActive(true);
        }
        else
        {
            SailsInstructionText.gameObject.SetActive(false);
        }
        
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cruising)
        {
            CruisingInstructionText.gameObject.SetActive(true);
        }
        else
        {
            CruisingInstructionText.gameObject.SetActive(false);
        }
    }

    public void ChangeGameStateText(string text)
    {
        GameStateText.gameObject.SetActive(true);
        GameStateText.text = text;
    }
    
    public void UpdateEnemiesLeftText(int enemiesLeft)
    {
        enemiesLeftText.text = "Enemies Left: " + enemiesLeft.ToString();
    }

    public void ShowPauseMenu()
    {
        if (pauseMenuUI != null){
            pauseMenuUI.SetActive(true);
        }
        
    }

        public void HidePauseMenu()
    {
        if (pauseMenuUI != null){
            pauseMenuUI.SetActive(false);
        }
        
    }

    public void UpdateGoldText(int goldAmount)
    {
        goldText.text = goldAmount.ToString();
    }


        void OnEnable()
    {
        EventManager.Game.OnGamePaused += ShowPauseMenu;
        EventManager.Game.OnGameResumed += HidePauseMenu;

    }
    void OnDisable()
    {
        EventManager.Game.OnGamePaused -= ShowPauseMenu;
        EventManager.Game.OnGameResumed -= HidePauseMenu;

    }
}

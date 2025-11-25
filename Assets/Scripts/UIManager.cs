using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CannonInstructionText;
    [SerializeField] private TextMeshProUGUI SailsInstructionText;
    [SerializeField] private TextMeshProUGUI CruisingInstructionText;
    [SerializeField] private TextMeshProUGUI GameStateText;

    [SerializeField] private PlayerStateManager playerStateManager;

    [SerializeField] private TextMeshProUGUI enemiesLeftText;
    [SerializeField] private TextMeshProUGUI HealthText;

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private UnityEngine.UI.Image hotBarCruising;
    [SerializeField] private UnityEngine.UI.Image hotBarSails;
    [SerializeField] private UnityEngine.UI.Image hotBarCannon;

    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;


    // Start is called before the first frame update
    void Start()
    {
        GameStateText.gameObject.SetActive(false);
        pauseMenuUI.SetActive(false);
        quitButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cannons)
        {
            CannonInstructionText.gameObject.SetActive(true);
            if (hotBarCannon != null)
            hotBarCannon.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            CannonInstructionText.gameObject.SetActive(false);
            if (hotBarCannon != null)
            hotBarCannon.rectTransform.localScale = new Vector3(1f, 1f, 1);
        }

        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Sailing)
        {
            SailsInstructionText.gameObject.SetActive(true);
            if (hotBarSails != null)
            hotBarSails.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            SailsInstructionText.gameObject.SetActive(false);
            if (hotBarSails != null)
            hotBarSails.rectTransform.localScale = new Vector3(1f, 1f, 1);
        }
        
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cruising)
        {
            CruisingInstructionText.gameObject.SetActive(true);
            if (hotBarCruising != null)
            hotBarCruising.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            CruisingInstructionText.gameObject.SetActive(false);
            if (hotBarCruising != null)
            hotBarCruising.rectTransform.localScale = new Vector3(1f, 1f, 1);
        }
    }

    public void ChangeGameStateText(string text)
    {
        if (GameStateText == null) return;
        GameStateText.gameObject.SetActive(true);
        GameStateText.text = text;
    }
    
    public void UpdateEnemiesLeftText(int enemiesLeft)
    {
        if(enemiesLeftText == null) return;
        enemiesLeftText.text = "Enemies Left: " + enemiesLeft.ToString();
    }

    public void ShowPauseMenu()
    {
        if (pauseMenuUI != null){
            quitButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            pauseMenuUI.SetActive(true);
        }
        
    }

        public void HidePauseMenu()
    {
        if (pauseMenuUI != null){
            quitButton.gameObject.SetActive(false);
            mainMenuButton.gameObject.SetActive(false);
            pauseMenuUI.SetActive(false);
        }
        
    }

    public void UpdateGoldText(int goldAmount)
    {
        if(goldText == null) return;
        goldText.text = goldAmount.ToString();
    }

    public void ShowQuitButton()
    {
        quitButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
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

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        if(HealthText == null) return;
        HealthText.text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
    }
}

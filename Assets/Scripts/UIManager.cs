using System.Collections;
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
    [SerializeField] private UnityEngine.UI.Image hotBarCannon;

    [SerializeField] private Button quitButton;
    [SerializeField] private Button mainMenuButton;

    [SerializeField] private TextMeshProUGUI fogText;
    [SerializeField] private TextMeshProUGUI fogTimerText;


    // Start is called before the first frame update
    void Start()
    {
        GameStateText.gameObject.SetActive(false);
        pauseMenuUI.SetActive(false);
        quitButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        fogText.gameObject.SetActive(false);
        fogTimerText.gameObject.SetActive(false);
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
        
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cruising)
        {
            SailsInstructionText.gameObject.SetActive(true);
            CruisingInstructionText.gameObject.SetActive(true);
            if (hotBarCruising != null)
            hotBarCruising.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            SailsInstructionText.gameObject.SetActive(false);
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
        EventManager.Game.OnFogEnter += ToggleFogText;

    }
    void OnDisable()
    {
        EventManager.Game.OnGamePaused -= ShowPauseMenu;
        EventManager.Game.OnGameResumed -= HidePauseMenu;
        EventManager.Game.OnFogEnter -= ToggleFogText;

    }

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        if(HealthText == null) return;
        HealthText.text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    private void ToggleFogText(bool inFog)
    {
        if (inFog)
        {
            fogText.gameObject.SetActive(true);
            fogTimerText.gameObject.SetActive(true);
            StartCoroutine(FogTimerCoroutine(5f));
        }
        else
        {
            fogText.gameObject.SetActive(false);
            fogTimerText.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    IEnumerator FogTimerCoroutine(float duration)
    {
        float remainingTime = duration;
        while (remainingTime >= 0f)
        {
            fogTimerText.text = remainingTime.ToString();
            yield return new WaitForSeconds(0.9f);
            remainingTime -= 1f;
        }
        fogTimerText.text = "";
    }
}

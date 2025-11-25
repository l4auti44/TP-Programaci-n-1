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

    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private TextMeshProUGUI goldText;

    [SerializeField] private UnityEngine.UI.Image hotBarCruising;
    [SerializeField] private UnityEngine.UI.Image hotBarSails;
    [SerializeField] private UnityEngine.UI.Image hotBarCannon;


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
            hotBarCannon.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            CannonInstructionText.gameObject.SetActive(false);
            hotBarCannon.rectTransform.localScale = new Vector3(1f, 1f, 1);
        }

        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Sailing)
        {
            SailsInstructionText.gameObject.SetActive(true);
            hotBarSails.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            SailsInstructionText.gameObject.SetActive(false);
            hotBarSails.rectTransform.localScale = new Vector3(1f, 1f, 1);
        }
        
        if (playerStateManager.currentState == PlayerStateManager.PlayerState.Cruising)
        {
            CruisingInstructionText.gameObject.SetActive(true);
            hotBarCruising.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        else
        {
            CruisingInstructionText.gameObject.SetActive(false);
            hotBarCruising.rectTransform.localScale = new Vector3(1f, 1f, 1);
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

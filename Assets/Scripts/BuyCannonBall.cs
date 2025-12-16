using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCannonBall : MonoBehaviour
{
    public bool isBought = false;
    private GameController gameController;
    [SerializeField] private GameObject lockIcon;
    private Button buyButton;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        buyButton = GetComponent<Button>();
        if (!isBought)
        {
            GetComponent<Image>().color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCannonBallButton()
    {
        if (!isBought && gameController.gold >= 50)
        {
            SoundManager.PlaySound(SoundManager.Sound.Buy);
            lockIcon.SetActive(false);
            GetComponent<Image>().color = Color.white;
            gameController.DecreaseGold(50);
            isBought = true;
        }
    }
}

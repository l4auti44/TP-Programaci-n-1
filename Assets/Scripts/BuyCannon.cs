using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyCannon : MonoBehaviour
{
    [SerializeField] private CannonController cannon;
    private GameController gameController;
    private Button buyButton;
    // Start is called before the first frame update
    void Start()
    {
        buyButton = GetComponent<Button>();
        if (cannon.isBought)
        {
            buyButton.interactable = false;
        }
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (gameController.gold < 100)
        {
            buyButton.interactable = false;
        }
        else
        {
            if (!cannon.isBought)
            {
                buyButton.interactable = true;
            }
        }
    }

    public void BuyCannonButton()
    {
        if (gameController.gold >= 100)
        {
            gameController.DecreaseGold(100);
            cannon.isBought = true;
            buyButton.interactable = false;
        }
    }
}

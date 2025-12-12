using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenuCannonBall : MonoBehaviour
{
    [SerializeField] private GameObject cannonsBallMenu;
    [HideInInspector] public CannonController cannonSelected;
    [HideInInspector] public Image cannonBallImage;
    private Transform previousPos; 
    // Start is called before the first frame update
    void Start()
    {
        cannonsBallMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCannonBallMenu(Transform position)
    {
        if (cannonsBallMenu.activeSelf && previousPos == position)
        {
            CloseCannonBallMenu();
            return;
        }
        previousPos = position;
        cannonsBallMenu.transform.position = position.position;
        cannonBallImage = position.GetChild(1).GetComponent<Image>();
        cannonSelected = position.parent.GetComponent<BuyCannon>().cannon;
        cannonsBallMenu.SetActive(true);
    }

    public void CloseCannonBallMenu()
    {
        cannonSelected = null;
        cannonBallImage = null;
        cannonsBallMenu.SetActive(false);
    }
}

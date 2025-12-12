using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSelection : MonoBehaviour
{
    [SerializeField] private GameObject cannonBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCannonBallType()
    {
        DropDownMenuCannonBall menu = transform.parent.parent.parent.parent.GetComponent<DropDownMenuCannonBall>();
        menu.cannonSelected.cannonballPrefab = cannonBallPrefab;
        menu.cannonBallImage.sprite = GetComponent<UnityEngine.UI.Image>().sprite;
        menu.CloseCannonBallMenu();
    }
}

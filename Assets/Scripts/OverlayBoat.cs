using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayBoat : MonoBehaviour
{
    [SerializeField] private GameObject boatOverlaySprite;
    [SerializeField] private GameObject boatSprite;
    
    void Start()
    {
        
        
    }

    void ToggleOverlay(bool inFog){

        if (inFog)
        {
            boatOverlaySprite.SetActive(true);
            boatSprite.SetActive(false);
        }
        else
        {
            boatOverlaySprite.SetActive(false);
            boatSprite.SetActive(true);
        }
    }

    void OnEnable()
    {
        EventManager.Game.OnFogEnter += ToggleOverlay;
    }

    void OnDisable()
    {
        EventManager.Game.OnFogEnter -= ToggleOverlay;
    }
}

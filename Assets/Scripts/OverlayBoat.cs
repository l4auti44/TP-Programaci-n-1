using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayBoat : MonoBehaviour
{
    [SerializeField] private GameObject boatOverlaySprite;
    [SerializeField] private GameObject boatSprite;
    [SerializeField] private SpriteRenderer sailImage;
    
    void Start()
    {
        
        
    }

    void ToggleOverlay(bool inFog){

        if (inFog)
        {
            boatOverlaySprite.SetActive(true);
            boatSprite.SetActive(false);
            sailImage.enabled = false;
        }
        else
        {
            boatOverlaySprite.SetActive(false);
            boatSprite.SetActive(true);
            sailImage.enabled = true;
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

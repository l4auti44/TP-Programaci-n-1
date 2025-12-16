using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGroup : MonoBehaviour
{   [SerializeField] private CannonController[] cannons;
    private GameObject aimMarker;
    public bool isCannonsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.CompareTag("Player"))
        {

            aimMarker = transform.Find("Aim").gameObject;
            aimMarker.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCannonsActive()
    {
        aimMarker.SetActive(true);
        foreach (var cannon in cannons)
        {
            if (cannon.isBought == false) continue;
            cannon.gameObject.SetActive(true);
            cannon.SetCannonActive();
        }
    }

    public void SetCannonsInactive()
    {
        aimMarker.SetActive(false);
        foreach (var cannon in cannons)
        {
            cannon.gameObject.SetActive(false);
            cannon.SetCannonInactive();
        }
    }

    public void FireCannons()
    {
        foreach (var cannon in cannons)
        {
            if (cannon.isBought == false) continue;
            if (cannon.isEnabled == true)
            cannon.FireCannon();
            
        }
    }

    public CannonController GetAICannon()
    {
        return cannons[0];
    }

    public void ActivateCannonsAI()
    {
        cannons[0].isEnabled = true;
        cannons[0].FireCannon();
    }
    
}

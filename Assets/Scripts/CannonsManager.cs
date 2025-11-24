using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    [SerializeField] private CannonController[] cannons;
    [HideInInspector] public CannonController cannonEnabled;
    private PlayerStateManager stateManager;
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<PlayerStateManager>();
    }

    // Update is called once per frame
    void Update()
    {


        
    }


    public void SwitchCannon()
    {
        CannonController previousCannon = null;
        if (cannonEnabled != null)
        {
            cannonEnabled.GetComponent<SpriteRenderer>().color = Color.gray;
            previousCannon = cannonEnabled;
        }


        

        foreach (var cannon in cannons)
        {
            if (!cannon.isEnabled && cannon != previousCannon && previousCannon != null)
            {
                cannon.isEnabled = true;
                cannonEnabled.isEnabled = false;
                cannon.GetComponent<SpriteRenderer>().color = Color.green;
                cannonEnabled = cannon;
                break;
            }
        }
    }

    public void UnselectCannons()
    {
        if (cannonEnabled != null)
        {
            cannonEnabled.GetComponent<SpriteRenderer>().color = Color.gray;
            cannonEnabled.isEnabled = false;
            cannonEnabled = null;
        }
    }

    public void SelectCannon()
    {
            cannonEnabled = cannons[0];
            cannonEnabled.GetComponent<SpriteRenderer>().color = Color.green;
            cannonEnabled.isEnabled = true;
            
    }

    public void ShootIACannon(Transform target)
    {
        float Cannon1DistanceToPlayer = Vector2.Distance(cannons[0].transform.position, target.transform.position);
        float Cannon2DistanceToPlayer = Vector2.Distance(cannons[1].transform.position, target.transform.position);
        if (Cannon1DistanceToPlayer < Cannon2DistanceToPlayer)
        {
            cannonEnabled = cannons[0];
        }
        else
        {
            cannonEnabled = cannons[1];
        }
        cannonEnabled.isEnabled = true;
        cannonEnabled.FireCannon();
    }
}

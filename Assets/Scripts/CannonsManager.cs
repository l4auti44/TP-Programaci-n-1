using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    [SerializeField] private CannonGroup[] cannonsGroup;
    [HideInInspector] public CannonGroup cannonGroupEnabled;
    private PlayerStateManager stateManager;
    

    void Start()
    {
        stateManager = GetComponent<PlayerStateManager>();
    }
    public void UnselectCannons()
    {
        foreach (var cannonGroup in cannonsGroup)
        {
            cannonGroup.SetCannonsInactive();
            cannonGroup.isCannonsActive = false;
        }
        cannonGroupEnabled = null;
    }

    public void SwitchCannon()
    {
        if (cannonGroupEnabled == null)
        {
            SelectCannon();
            return;
        }
        foreach (var cannonGroup in cannonsGroup)
            {
                if (cannonGroup.isCannonsActive)
                {
                    cannonGroup.SetCannonsInactive();
                    cannonGroup.isCannonsActive = false;
                }
                else
                {
                    cannonGroup.SetCannonsActive();
                    cannonGroup.isCannonsActive = true;
                    cannonGroupEnabled = cannonGroup;
                }
            }
    }

    public void SelectCannon()
    {
        cannonGroupEnabled = cannonsGroup[0];
        cannonsGroup[0].SetCannonsActive();
        cannonsGroup[0].isCannonsActive = true;
        
    }

    public void ShootIACannon(Transform target)
    {
        
        CannonGroup cannonEnabled;
        float Cannon1DistanceToPlayer = Vector2.Distance(cannonsGroup[0].GetAICannon().transform.position, target.transform.position);
        float Cannon2DistanceToPlayer = Vector2.Distance(cannonsGroup[1].GetAICannon().transform.position, target.transform.position);
        if (Cannon1DistanceToPlayer < Cannon2DistanceToPlayer)
        {
            cannonEnabled = cannonsGroup[0];
        }
        else
        {
            cannonEnabled = cannonsGroup[1];
        }
        cannonEnabled.ActivateCannonsAI();
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerStateManager stateManager;
    private CannonsManager cannonsManager;
    private SailController sailController;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<PlayerStateManager>();
        cannonsManager = GetComponent<CannonsManager>();
        sailController = transform.parent.GetComponentInChildren<SailController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.currentState != PlayerStateManager.PlayerState.Win && stateManager.currentState != PlayerStateManager.PlayerState.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                stateManager.ChangeState(PlayerStateManager.PlayerState.Cruising);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                stateManager.ChangeState(PlayerStateManager.PlayerState.Sailing);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                stateManager.ChangeState(PlayerStateManager.PlayerState.Cannons);

        }
        switch (stateManager.currentState)
        {
            case PlayerStateManager.PlayerState.Menu:

                break;
            case PlayerStateManager.PlayerState.Cruising:
                cannonsManager.UnselectCannons();
                CruisingControlls();
                break;
            case PlayerStateManager.PlayerState.Sailing:
                cannonsManager.UnselectCannons();
                SailControlls();
                break;
            case PlayerStateManager.PlayerState.Cannons:
                CannonsControlls();
                break;
            case PlayerStateManager.PlayerState.Paused:
                break;
            case PlayerStateManager.PlayerState.GameOver:
                break;
            case PlayerStateManager.PlayerState.Win:
                break;
        }

    }

    private void CannonsControlls()
    {
        if (cannonsManager.cannonGroupEnabled == null) cannonsManager.SelectCannon();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cannonsManager.SwitchCannon();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cannonsManager.cannonGroupEnabled.isCannonsActive)
                cannonsManager.cannonGroupEnabled.FireCannons();
        }
    }
    private void CruisingControlls()
    {
        sailController.RotateSailByInput(Input.GetAxis("Horizontal"));
    }
    private void SailControlls()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            sailController.IncreaseSailSpeed();
            sailController.UpdateSailText();
            Camera.main.GetComponent<CameraController>().ChangeSizeOverTime(sailController.currentSpeedLevel * 10);
        }
    }
}

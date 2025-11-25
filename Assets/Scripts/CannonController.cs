using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    [SerializeField] private float fireCooldown = 1f;
    [SerializeField] private GameObject cannonballPrefab;
    public Transform firePoint;
    private PlayerStateManager stateManager;

    [SerializeField] public bool isBought = false;

    [HideInInspector] public bool isEnabled = false;

    private enum CannonState
    {
        Ready,
        CoolingDown
    }

    private CannonState state = CannonState.Ready;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponentInParent<PlayerStateManager>();
    }



    public void FireCannon()
    {
          if (state != CannonState.Ready) return;
        var cannonBall = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation).GetComponent<CannonBall>();
        cannonBall.Init(firePoint.up, transform.parent.parent.GetComponent<Rigidbody2D>().velocity);
        Debug.Log("Cannon Fired!");
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        state = CannonState.CoolingDown;
        yield return new WaitForSeconds(fireCooldown);
        state = CannonState.Ready;
    }

    private void OnDrawGizmos()
    {
        if (firePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.up * 2f);
        }
    }

    public void SetCannonActive()
    {
        if (!isBought) return;
        isEnabled = true;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void SetCannonInactive()
    {
        isEnabled = false;
        GetComponent<SpriteRenderer>().color = Color.gray;
        StopAllCoroutines();
        state = CannonState.Ready;
    }
}

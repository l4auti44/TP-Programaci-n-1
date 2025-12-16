using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    [SerializeField] private float fireCooldown = 1f;
    [SerializeField] public GameObject cannonballPrefab;
    public Transform firePoint;
    private GameObject smokeEffect;

    [SerializeField] public bool isBought = false;

    [HideInInspector] public bool isEnabled = false;

    private ShakeCamera shakeCamera;

    private enum CannonState
    {
        Ready,
        CoolingDown
    }

    private CannonState state = CannonState.Ready;

    // Start is called before the first frame update
    void Start()
    {
        smokeEffect = transform.Find("Smoke").gameObject;
        smokeEffect.SetActive(false);
        shakeCamera = transform.parent.parent.parent.GetComponentInChildren<ShakeCamera>();
    }



    public void FireCannon()
    {
          if (state != CannonState.Ready) return;
        var cannonBall = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation).GetComponent<CannonBall>();
        cannonBall.Init(firePoint.up, transform.parent.parent.GetComponent<Rigidbody2D>().velocity);
        if (shakeCamera != null)
        {
            shakeCamera.duration = 0.1f;
            shakeCamera.Shake();
        }
        SoundManager.PlaySound(SoundManager.Sound.Shoot);
        
        smokeEffect.SetActive(true);
        StartCoroutine(DisableSmokeEffect());
        
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
        smokeEffect.SetActive(false);
        state = CannonState.Ready;
    }

    private IEnumerator DisableSmokeEffect()
    {
        yield return new WaitForSeconds(0.7f);
        smokeEffect.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentedCannonBall : MonoBehaviour
{
    [SerializeField] private GameObject fragmentPrefab;
    [SerializeField] private int fragmentCount = 5;
    [SerializeField] private float fragmentSpeed = 3f;
    [SerializeField] private float cannonBallTimeToLive = 2f;
    [SerializeField] private float degree = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cannonBallTimeToLive -= Time.deltaTime;
        if (cannonBallTimeToLive <= 0f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        var originalCb = this.GetComponent<CannonBall>();
        UnityEngine.Vector2 baseDirection = originalCb != null ? originalCb.direction : new UnityEngine.Vector2(transform.up.x, transform.up.y);
        for (int i = 0; i < fragmentCount; i++)
        {
            // Small random variation in degrees around the base direction. 'degree' controls the maximum spread angle.
            float variation = UnityEngine.Random.Range(-degree / 2f, degree / 2f);
            float baseAngle = Mathf.Atan2(baseDirection.y, baseDirection.x) * Mathf.Rad2Deg;
            float newAngle = baseAngle + variation;
            Vector2 newDirection = new Vector2(Mathf.Cos(newAngle * Mathf.Deg2Rad), Mathf.Sin(newAngle * Mathf.Deg2Rad)).normalized;

            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Quaternion.identity);
            var fragmentCb = fragment.GetComponent<CannonBall>();
            if (fragmentCb != null)
            {
                // Initialize fragment with rotated direction and original momentum if available.
                fragmentCb.Init(newDirection, originalCb != null ? originalCb.Momentum : UnityEngine.Vector2.zero);
                // Optionally set the fragment speed (override prefab default)
                fragmentCb.speed = fragmentSpeed;
            }
        }
        Destroy(gameObject);
    }
}

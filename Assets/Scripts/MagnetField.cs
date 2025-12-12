using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    [SerializeField] private float forceMagnitude = 1000f;
    private CannonBall cannonBall;
    // Start is called before the first frame update
    void Start()
    {
        cannonBall = transform.parent.GetComponent<CannonBall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            float distance = direction.magnitude;
            cannonBall.direction = (cannonBall.direction + (new UnityEngine.Vector2(direction.x, direction.y).normalized * (forceMagnitude / (distance * distance)) * Time.deltaTime)).normalized;
        }
    }
}

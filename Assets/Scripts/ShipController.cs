using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 2f;

    [SerializeField] private Transform sailTransform;
    
    //Y AXIS IS THE FOWARD
    private Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float targetSpeed = 2f * sailTransform.GetComponent<SailController>().currentSpeedLevel;
        float smoothTime = 0.5f; 
        maxSpeed = Mathf.Lerp(maxSpeed, targetSpeed, Time.deltaTime * smoothTime);
    }

    void FixedUpdate()
    {

        float angle = Vector2.SignedAngle(transform.up, sailTransform.up);
        float rotationSpeed = 2f;
        transform.Rotate(0, 0, angle * rotationSpeed * Time.fixedDeltaTime);


        _rb.AddForce(transform.up * 10);
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
    }

void OnDrawGizmos()
{
    if (sailTransform != null)
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(sailTransform.position, sailTransform.position + sailTransform.up * 2f);
    }
}


}

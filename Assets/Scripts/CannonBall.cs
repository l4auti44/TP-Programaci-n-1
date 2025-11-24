using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public UnityEngine.Vector2 direction;
    [SerializeField] private float speed = 5f;
    public float damage = 20f;
    [SerializeField] private float lifeTime = 3f;

    private UnityEngine.Vector2 _momentum;

    public void Init(UnityEngine.Vector2 direction, UnityEngine.Vector2 shipVelocity)
    {
        this.direction = direction.normalized;
        _momentum = shipVelocity;
    }

    void Update()
    {
        UnityEngine.Vector2 totalVelocity = direction * speed + _momentum;
        transform.position += new UnityEngine.Vector3(totalVelocity.x, totalVelocity.y, 0) * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

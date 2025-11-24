using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAIAimingPoint : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float maxYChange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Mathf.Sin(Time.time * speed) * maxYChange * Time.deltaTime, 0);
    }
}

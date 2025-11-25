using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagulls : MonoBehaviour
{
    [SerializeField] private Transform goToPoint;
    private Vector3 startingPoint;
    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goToPoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, goToPoint.position) < 0.1f)
        {
            transform.position = startingPoint;
        }
    }
}

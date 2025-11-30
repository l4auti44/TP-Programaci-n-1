using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampCameraPosition : MonoBehaviour
{   
    [SerializeField]private float minX = -10f;
    [SerializeField]private float maxX = 95f;
    [SerializeField]private float minY = -35f;
    [SerializeField]private float maxY = 130f;
    [SerializeField]private float offset = 10f;
    [SerializeField] private Transform followTarget;
    [SerializeField] private SailController sailController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (sailController.currentSpeedLevel)
        {
            case 1:
                offset = -7f;
                break;
            case 2:
                offset = 0f;
                break;
            case 3:
                offset = 10f;
                break;
        }
       transform.position = new Vector3(
            Mathf.Clamp(followTarget.position.x, minX + offset, maxX - offset),
            Mathf.Clamp(followTarget.position.y, minY + offset, maxY - offset),
            transform.position.z
        );
    }
}

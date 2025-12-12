using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform AimingPoint;
    [SerializeField] private SailController sailController;
    [SerializeField] private SpriteRenderer sailImage;
    [SerializeField] private GameObject overlayBoat;

    
    private CannonsManager cannonsManager;


    void Start()
    {
        AimingPoint = GameObject.Find("AIAimingPoint").transform;
        cannonsManager = GetComponent<CannonsManager>();

    }
    // Update is called once per frame
    void Update()
    {

        Vector2 toPlayer = AimingPoint.position - transform.position;

        
        float angle = Vector2.SignedAngle(-sailController.transform.right, toPlayer);

        
        if (angle < 0) //Right
            angle = -Mathf.Abs(angle);
        else
            angle = Mathf.Abs(angle);

        float maxAngle = 45f;
        float input = Mathf.Clamp(angle / maxAngle, -1f, 1f);

        sailController.RotateSailByInput(input);
        if (toPlayer.magnitude < 20f)
        cannonsManager.ShootIACannon(AimingPoint);
    }

    void OnDrawGizmos()
    {
        if (sailController != null && AimingPoint != null)
        {
            Vector3 origin = sailController.transform.position;

            // Dibuja el vector -right (lado izquierdo de la vela) en rojo
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin, origin - sailController.transform.right * 2f);

            // Dibuja el vector hacia el jugador en verde
            Gizmos.color = Color.green;
            Gizmos.DrawLine(origin, AimingPoint.position);
        }
    }

    public void OnFog()
    {
        sailImage.enabled = false;
        overlayBoat.SetActive(true);
        
    }

    public void OffFog()
    {
        sailImage.enabled = true;
        overlayBoat.SetActive(false);

    }
}

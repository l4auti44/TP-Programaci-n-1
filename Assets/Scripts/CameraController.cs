using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 1f;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

    public void ChangeSizeOverTime(float size)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeSizeCoroutine(size));
    }
    
    private IEnumerator ChangeSizeCoroutine(float targetSize)
    {
        
        float initialSize = mainCamera.orthographicSize;
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.orthographicSize = targetSize;
    }
}

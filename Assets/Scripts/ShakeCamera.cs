using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float duration = 0.5f;
    public AnimationCurve shakeCurve;
    private bool isShaking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake()
    {
        if (isShaking)
            return;
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        Vector3 startposition = transform.position;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            isShaking = true;
            elapsed += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsed / duration);
            transform.position = transform.position + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startposition;
        isShaking = false;
    }
}

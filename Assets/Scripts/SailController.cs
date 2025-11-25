using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SailController : MonoBehaviour
{

    [SerializeField] private float speedRotation = 50f;
    [SerializeField] private Transform sailPosition;
    private TextMeshProUGUI sailText;


    public int currentSpeedLevel = 1;

    void Start()
    {

        if (transform.parent.CompareTag("Player"))
        {
            sailText = GameObject.Find("SailSpeedText").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sailPosition.position;
    }

    public void IncreaseSailSpeed()
    {
        currentSpeedLevel++;
        if (currentSpeedLevel > 3) currentSpeedLevel = 1;
    }

    public void RotateSailByInput(float input)
    {
        transform.Rotate(0, 0, -input * speedRotation * Time.deltaTime);
    }

    public void RotateByDegrees(float degrees)
    {
        transform.Rotate(0, 0, degrees);
    }

    public void UpdateSailText()
    {
        
        switch (currentSpeedLevel)
        {
            case 1:
                sailText.color = Color.green;
                sailText.text = "Sail Speed: ->";
                break;
            case 2:
                sailText.color = Color.yellow;
                sailText.text = "Sail Speed: -> ->";
                break;
            case 3:
                sailText.color = Color.red;
                sailText.text = "Sail Speed: -> -> ->";
                break;
        }
         
    }
}

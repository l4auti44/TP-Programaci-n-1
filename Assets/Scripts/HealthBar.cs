using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform bar;
    [SerializeField] private HealthManager healthManager;
    // Start is called before the first frame update
    void Start()
    {
        bar.localScale = new Vector3(healthManager.GetHealthPercentage(), 1f, 1f);
    }

    public void UpdateHealthBar()
    {
        bar.localScale = new Vector3(healthManager.GetHealthPercentage(), 1f, 1f);
    }

    public void HideHealthBar()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}

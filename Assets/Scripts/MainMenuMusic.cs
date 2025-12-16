using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    [SerializeField] string sceneWhereMusicDies = "Prototipo2";
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(string name)
    {
        if (name == sceneWhereMusicDies)
        {
            
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EventManager.Game.SceneLoaded += OnSceneLoaded;
    }
    void OnDestroy()
    {
        EventManager.Game.SceneLoaded -= OnSceneLoaded;
    }
}

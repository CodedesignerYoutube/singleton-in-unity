using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stepCounter;
    [SerializeField] private Button sceneLoader;

    public static SceneController Instance { get; private set; }



    public int Steps
    {
        get;
        private set;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        sceneLoader.onClick.AddListener(() => LoadScene(sceneLoader.name));
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoader.onClick.RemoveAllListeners();
        sceneLoader.onClick.AddListener(() => LoadScene(sceneLoader.name));
    }


    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


    public void IncreaseStep()
    {
        Steps++;
        stepCounter.text = $"{Steps} steps";
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

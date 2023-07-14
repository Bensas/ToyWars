using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private TMP_Text loadingText;
    private bool _sceneLoaded = false;
    private bool _isReady = false;
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    void Update()
    {
        if (!_sceneLoaded) return;
        if(Input.GetButtonDown("Start"))
        {
            _isReady = true;
        }
    }
    
    IEnumerator LoadYourAsyncScene()
    {
        string scene = GameSceneManager.Instance.GetCurrentLevel();
        Debug.Log(scene);
        
        int progress =0;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        asyncLoad.allowSceneActivation = false;
        
        while (asyncLoad.progress < 0.9f || progress < 99)
        {
            loadingText.text = $"Loading... {progress}%";
            progress += 1;
            yield return null;
        }

        _sceneLoaded = true;
        loadingText.text = $"Press any Space or Enter to continue...";
        
        while (!_isReady)
        {
            yield return null;
        }
        
        while (camera.m_Lens.FieldOfView > 1)
        {
            camera.m_Lens.FieldOfView -= 0.5f;
            yield return null;
        }
        
        asyncLoad.allowSceneActivation = true;
    }
}

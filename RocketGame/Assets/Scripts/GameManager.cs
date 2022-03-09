using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //CACHE
    public static GameManager instance;

    //STATE
    public bool hasExploded = false;
    public bool hasEnteredPortal = false;

    public event Action onExplosion;
    public event Action onPortalEnter;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onExplosion += RocketExploded;
        onPortalEnter += RocketHasEnteredPortal;
    }
    private void OnDisable()
    {
        onExplosion -= RocketExploded;
        onExplosion -= RocketHasEnteredPortal;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RocketExploded()
    {
        hasExploded = true;
        RestartScene();
    }

    public void RocketHasEnteredPortal()
    {
        hasEnteredPortal = true;
    }

    #region Scene Management
    public const string RestartMethod = "RestartScene"; //string to use when invoking the method
    public void RestartScene(int delay)
    {
        Invoke(RestartMethod, delay);
    }
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }

    //public static string NextSceneMethod = "LoadNextScene"; //string to use when invoking the method
    //public void LoadNextScene(int delay)
    //{
    //    Invoke(NextSceneMethod, delay);
    //}
    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene() != null) //not sure if this is needed
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    #endregion

    public void OnExplosion()
    {
        onExplosion?.Invoke();
    }

    public void OnPortalEnter()
    {
        hasEnteredPortal = true;
        onPortalEnter?.Invoke();
    }
}

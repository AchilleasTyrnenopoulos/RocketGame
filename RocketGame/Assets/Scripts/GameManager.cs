using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool exploded = false;

    public event Action onExplosion;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        onExplosion += RocketExploded;
    }
    private void OnDisable()
    {
        onExplosion -= RocketExploded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RocketExploded()
    {
        exploded = true;
        RestartScene(3);
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
        SceneManager.LoadScene(currentSceneIndex);
    }

    public static string NextSceneMethod = "LoadNextScene"; //string to use when invoking the method
    public void LoadNextScene(int delay)
    {
        Invoke(NextSceneMethod, delay);
    }
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

    }
    #endregion

    public void OnExplosion()
    {
        onExplosion?.Invoke();
    }
}

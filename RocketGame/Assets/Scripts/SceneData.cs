using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField]
    private int levelIndex = 0;
    [SerializeField]
    private double highScore = 0.00;

    private void Start()
    {
        //highScore = GameData.instance.GetLevelHighScore(levelIndex);
    }

    public bool IsScoreHighScore(double score)
    {
        bool result = false;
        
        if(score < highScore)
        {
            result = true;
        }

        return result;
    }
}

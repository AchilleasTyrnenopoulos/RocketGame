using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [Header("ROCKET")]
    public int rocketIndex = 0;
    [SerializeField]
    private List<GameObject> rocketPrefabs;

    [Header("LEVELS")]    
    private Dictionary<int, bool> levelsUnlocked; //list of all levels and if they are unlocked
    private Dictionary<int, double> levelsHighScores; //list of all levels and their high scores


    private void Awake()
    {
        instance = this;

        //get rocket index from save

        DontDestroyOnLoad(this);
    }

    public GameObject GetRocketPrefab(int index)
    {
        return rocketPrefabs[index];
    }

    public bool IsLevelUnlocked(int level)
    {
        bool result = false;
        levelsUnlocked.TryGetValue(level, out result);
        print($"Level {level} unlocked: {result}");

        return result;        
    }

    public double GetLevelHighScore(int level)
    {
        double result = 0.00;
        levelsHighScores.TryGetValue(level, out result);
        print($"Level {level} high score: {result}");

        return result;
    }
}

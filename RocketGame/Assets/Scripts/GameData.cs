using BayatGames.SaveGameFree;
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

    [Header("PLANETS")]
    private Dictionary<int, bool> planetsUnlocked;

    //save path
    //string savePath = Application.persistentDataPath + "\\saveData.txt";
    string savePath = nameof(rocketIndex) + ".txt";

    private void Awake()
    {
        instance = this;

        //get game data from save
        if (SaveGame.Exists(savePath))
        {
            print("Save file exists");
            
            LoadGameData();
            //SaveGame.Delete(savePath);
        }
        //SaveGameData();

        DontDestroyOnLoad(this);
    }

    public GameObject GetRocketPrefab(int index)
    {
        return rocketPrefabs[index];
    }

    //public bool IsLevelUnlocked(int level)
    //{
    //    bool result = false;
    //    levelsUnlocked.TryGetValue(level, out result);
    //    print($"Level {level} unlocked: {result}");

    //    return result;        
    //}

    //public bool IsPlanetUnlocked(int planetIndex)
    //{
    //    //because every planet has 10 levels
    //    bool result = false;
    //    planetsUnlocked.TryGetValue(planetIndex, out result);
    //    print($"Planet {planetIndex} is unlocked: {result}");

    //    return result;
    //}

    //public double GetLevelHighScore(int level)
    //{
    //    double result = 0.00;
    //    levelsHighScores.TryGetValue(level, out result);
    //    print($"Level {level} high score: {result}");

    //    return result;
    //}

    public void SaveGameData()
    {
        //create save model
        SaveModel saveModel = new SaveModel
        {
            RocketIndex = rocketIndex
        };
        

        //save data
        SaveGame.Save<SaveModel>(savePath, saveModel);

        print("Saved game");
    }

    public void LoadGameData()
    {
        //get save model
        SaveModel savedData = SaveGame.Load<SaveModel>(savePath);

        //pass values to game data
        rocketIndex = savedData.RocketIndex;

        print("Loaded game data");
    }
}

public class SaveModel
{
    public int RocketIndex { get; set; }
    public Dictionary<int, bool> LevelsUnlocked { get; set; }
    public Dictionary<int, double> LevelsHighScores { get; set; }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : Spawner
{
    private void Awake() 
    {
        //if (GameData.instance == null)
        //    print("this is the error");
        spawnPrefab = GameData.instance.rocketPrefab;
    }

}

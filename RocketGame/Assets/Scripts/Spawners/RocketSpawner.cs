using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : Spawner
{
    private void Awake() 
    {
        spawnPrefab = GameData.instance.GetRocketPrefab(GameData.instance.rocketIndex);
    }

}

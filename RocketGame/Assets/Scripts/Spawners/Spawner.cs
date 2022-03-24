using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject spawnPrefab;

    private void Start()
    {
        Instantiate(spawnPrefab, this.transform.position, Quaternion.identity);        
    }    
    
}

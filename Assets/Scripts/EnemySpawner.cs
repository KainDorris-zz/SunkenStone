using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] int roundsToSpawn = 5;
    [SerializeField] float spawnTimer = 5f;
    //TODO Randomize spawning
    //[SerializeField, Tooltip("Spawn enemies randomly from list")] bool randomSpawning = false;
    
    private void Start() {
        StartCoroutine("SpawnEnemies");
    }

    //Loop through N times where N= rounds to spawn
    private IEnumerator SpawnEnemies(){

        for (int i = 0; i < roundsToSpawn; i++){
            for (int j = 0; j < enemies.Count; j++){
            
            Instantiate(enemies[i], transform.position, transform.rotation);                       
            yield return new WaitForSeconds(spawnTimer);
            }

        }
        
    }
}
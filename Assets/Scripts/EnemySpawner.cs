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
    [SerializeField] bool hasSpawned = false;
    [SerializeField] GameObject spawnPoint;
    
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Player>()){
            if (hasSpawned == false){
                hasSpawned = true;
                StartCoroutine(SpawnEnemies());
            }
        }
        
    }

    //Loop through N times where N= rounds to spawn
    private IEnumerator SpawnEnemies(){

        for (int i = 0; i < roundsToSpawn; i++){
            for (int j = 0; j < enemies.Count; j++){
            
            Instantiate(enemies[i], spawnPoint.transform.position, spawnPoint.transform.rotation);                       
            yield return new WaitForSeconds(spawnTimer);
            }

        }
        
    }


}
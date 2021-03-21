using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    [SerializeField] GameObject bossFinal;
    [SerializeField] GameObject bossSpawn;
    [SerializeField] int rondasMax = 15;
    private float globalDelay = 8;
    private int spawnCounter = 0;
    void Start()
    {
        StartCoroutine(RondaSpawn(2));
    }

    // Update is called once per frame
    void Update()
    {



    }

    private IEnumerator RondaSpawn(float delay)
    {
        print(spawnCounter);
        yield return new WaitForSeconds(delay);
        if (spawnCounter <= rondasMax) { 
        SpawnEnemigos();
        StartCoroutine(RondaSpawn(globalDelay));
        }
        else
        {
            SpawnBoss();
        }
  
    }

    private void SpawnEnemigos()
    {
        spawnCounter++;
        foreach (Transform child in transform)
        {
            int rand = Random.Range(1, 4);
            switch (rand) {
                case 1:
                    Instantiate(enemy1, child.position, child.rotation);
                break;
                case 2:
                    Instantiate(enemy2, child.position, child.rotation);
                    break;
                case 3:
                    Instantiate(enemy3, child.position, child.rotation);
                break;
            }
        }
    }

    private void SpawnBoss()
    {
        Instantiate(bossFinal, bossSpawn.transform.position, bossSpawn.transform.rotation);
    }
}

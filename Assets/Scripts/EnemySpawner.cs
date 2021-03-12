using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
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
        yield return new WaitForSeconds(delay);
        SpawnEnemigos();
        StartCoroutine(RondaSpawn(globalDelay));
    }

    private void SpawnEnemigos()
    {
        spawnCounter++;
        foreach (Transform child in transform)
        {
            int rand = Random.Range(1, 3);
            print(rand);
            switch (rand) {
                case 1:
                    Instantiate(enemy1, child.position, child.rotation);
                break;
                case 2:
                    Instantiate(enemy2, child.position, child.rotation);
                    break;
            }
    }
    }
}

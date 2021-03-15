using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBasura : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] objetos;
    void Start()
    {
        SpawnBasura();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBasura()
    {

            int randomChildIdx = Random. Range(0, gameObject.transform.childCount);
            Transform randomChild = gameObject.transform.GetChild(randomChildIdx);
        Instantiate(objetos[Random.Range(0, objetos.Length)], randomChild.position, Quaternion.Euler(0,0,Random.Range(0,360)));
        StartCoroutine(TimerSpawnBasura());
    }

    private IEnumerator TimerSpawnBasura()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        SpawnBasura();
    }

}

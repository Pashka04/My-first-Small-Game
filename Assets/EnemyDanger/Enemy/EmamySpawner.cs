using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EmamySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private float spawnRate = 10f;

    IEnumerator SpawnEnemy() 
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyObject, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
        
          
    }


    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }

}

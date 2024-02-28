using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ARRandomSpawn : MonoBehaviour
{

   // public ARRaycastManager arRaycast;

    public Transform[] spawnPoints;
    public GameObject placeObject;

    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawing());
    }

    IEnumerator StartSpawing()
    {
        while (enemyCount < 20)     // wizard 랑 zombie 몬스터 각각 스폰 개수가 달라야할 꺼 같음.
        {
            // xPos = Random.Range(-20, 20);
            xPos = Random.Range(-2, 0);
            //zPos = Random.Range(10, 20);
            zPos = Random.Range(10, 11);
            Instantiate(placeObject, new Vector3(xPos, Random.Range(-1, 1), zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCount += 1;
        }
    }
    
}

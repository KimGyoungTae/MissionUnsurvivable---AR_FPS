using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject SpawnObject; //Prefab으로 생성될 오브젝트

    public int xPos;
    public int zPos;
    public int enemyCount;

   
    void Start()
    {
        StartCoroutine(StartSpawing());
    }

    IEnumerator StartSpawing()
    {
        while (enemyCount < 20)
        {
            xPos = Random.Range(-4, 8); //Position X축 -4~ 8 사이의 랜덤 범위 생성
            zPos = Random.Range(6, 11); // Position Z축 6 ~ 11 사이의 랜덤 범위 생성
            //Prefab 오브젝트를 인스턴스화 시켜서 호출한다. 
            Instantiate(SpawnObject, new Vector3(xPos, Random.Range(-1, 1), zPos), Quaternion.identity); //(복제할 대상, 위치, 방향)
            yield return new WaitForSeconds(2);
            enemyCount += 1;
        }
    }
}

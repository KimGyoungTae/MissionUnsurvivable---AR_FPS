using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject SpawnObject; //Prefab���� ������ ������Ʈ

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
            xPos = Random.Range(-4, 8); //Position X�� -4~ 8 ������ ���� ���� ����
            zPos = Random.Range(6, 11); // Position Z�� 6 ~ 11 ������ ���� ���� ����
            //Prefab ������Ʈ�� �ν��Ͻ�ȭ ���Ѽ� ȣ���Ѵ�. 
            Instantiate(SpawnObject, new Vector3(xPos, Random.Range(-1, 1), zPos), Quaternion.identity); //(������ ���, ��ġ, ����)
            yield return new WaitForSeconds(2);
            enemyCount += 1;
        }
    }
}

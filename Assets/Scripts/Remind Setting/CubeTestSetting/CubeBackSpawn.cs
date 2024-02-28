using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBackSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject BackSpawnObject;  //Prefab���� ������ ������Ʈ

    public int BackxPos;
    public int BackzPos;
    public int BackCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackSpawing());
    }

    IEnumerator BackSpawing()
    {
        while (BackCount < 5)
        {
            BackxPos = Random.Range(-2, 6); //Position X�� -2~ 6 ������ ���� ���� ����
            BackzPos = Random.Range(-5, -2); // Position Z�� -5 ~ -2 ������ ���� ���� ����
            //Prefab ������Ʈ�� �ν��Ͻ�ȭ ���Ѽ� ȣ���Ѵ�. 
            Instantiate(BackSpawnObject, new Vector3(BackxPos, Random.Range(-1, 1), BackzPos), Quaternion.identity); //(������ ���, ��ġ, ����)
            yield return new WaitForSeconds(2);
            BackCount += 1;
        }
    }
}

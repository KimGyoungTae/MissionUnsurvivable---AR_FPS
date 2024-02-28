using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBackSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject BackSpawnObject;  //Prefab으로 생성될 오브젝트

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
            BackxPos = Random.Range(-2, 6); //Position X축 -2~ 6 사이의 랜덤 범위 생성
            BackzPos = Random.Range(-5, -2); // Position Z축 -5 ~ -2 사이의 랜덤 범위 생성
            //Prefab 오브젝트를 인스턴스화 시켜서 호출한다. 
            Instantiate(BackSpawnObject, new Vector3(BackxPos, Random.Range(-1, 1), BackzPos), Quaternion.identity); //(복제할 대상, 위치, 방향)
            yield return new WaitForSeconds(2);
            BackCount += 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ARRandomBackSpawn : MonoBehaviour
{

    // public ARRaycastManager arRaycast;

    public Transform[] spawnPoints;
    public GameObject placeObj;

    public int BxPos;
    public int BzPos;
    public int Count;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackSpawing());
    }

    IEnumerator BackSpawing()
    {
        while (Count < 5)
        {
            BxPos = Random.Range(-2, 2);
            BzPos = Random.Range(-5, -2);
            Instantiate(placeObj, new Vector3(BxPos, Random.Range(-1, 1), BzPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            Count += 1;
        }
    }

}

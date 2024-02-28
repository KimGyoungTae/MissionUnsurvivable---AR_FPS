using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int count = 2;
    public int wave = 1;
 
    public GameObject[] enemies;
    private int enemycount;

    
   

    public GameObject[] enemyPrefebs;
    public float SpawnRangeX = 3.64f;
    public float spawnPosZ = 8.6f;
    public float startdelay = 2;
    public float spawnInterval = 1.5f;
    public float SpawnRangeY = 0;

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
       
        //InvokeRepeating("SpawnRandomEnemies", startdelay, spawnInterval);
        // 
    }


    void Update()
    {
        SpawnRandomEnemies();
    }

    /*
    // Update is called once per frame
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemycount = enemies.Length;
        if (enemycount == 0  )
        {
            while (count > 1)
            {
                SpawnRandomEnemies();
                count = count - 1;

            }
            wave = wave + 1;
            count = 1 * wave; 
        }
           
       
    }

    */
   public  void SpawnRandomEnemies()
    {
        int enemyIndex = Random.Range(0, enemyPrefebs.Length);
        Vector3 spawnpos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), SpawnRangeY, spawnPosZ);
        Instantiate(enemyPrefebs[enemyIndex], spawnpos, enemyPrefebs[enemyIndex].transform.rotation,parent.transform);
        
    }
}

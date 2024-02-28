using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Arm : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    Animator anis;


    //public string gunName; // 총의 이름.

    //public int reloadBulletCount;   // 총알 재장전 개수
    //public int currentBulletCount; // 현재 탄알집에 남아있는 총알의 개수.
    //public int maxBulletCount; // 최대 소유 가능 총알 개수.
    //public int carryBulletCount; // 현재 소유하고 있는 총알 개수.


    // Start is called before the first frame update
    void Start()
    {
        anis = GetComponent<Animator>();
    }

    public void work()
    {
        anis.CrossFadeInFixedTime("AR_Fire_Arm", 0.01f);
    }
}

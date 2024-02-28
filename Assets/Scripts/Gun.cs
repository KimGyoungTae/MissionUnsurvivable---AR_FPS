using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName; // 총의 이름.

    public int reloadBulletCount = 20;   // 총알 재장전 개수
    public int currentBulletCount = 20; // 현재 탄알집에 남아있는 총알의 개수.
    public int maxBulletCount = 60; // 최대 소유 가능 총알 개수.
    public int carryBulletCount = 60; //현재 소유하고 있는 총알 개수.


   

    public Animator anim;
}

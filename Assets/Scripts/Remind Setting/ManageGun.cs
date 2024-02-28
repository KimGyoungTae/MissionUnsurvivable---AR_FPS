using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGun : MonoBehaviour
{
    [HideInInspector] public string gunName; // 현재 총의 이름.

    [Header("Bullet")]
    [Tooltip("총알 재장전 개수")]
    public int reloadBulletCount = 20;
    [Tooltip("현재 탄알집에 남아있는 총알의 개수")]
    public int currentBulletCount = 20;
    [Tooltip("최대 소유 가능 총알 개수")]
    public int maxBulletCount = 60;
    [Tooltip("현재 소유하고 있는 총알 개수")]
    public int carryBulletCount = 60;

    [Header("Hand Gun Animator")]
    public Animator HandGunAnimator;
    public Animator HandGunArmAnimator;
}

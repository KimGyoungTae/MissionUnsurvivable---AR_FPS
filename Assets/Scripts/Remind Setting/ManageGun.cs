using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGun : MonoBehaviour
{
    [HideInInspector] public string gunName; // ���� ���� �̸�.

    [Header("Bullet")]
    [Tooltip("�Ѿ� ������ ����")]
    public int reloadBulletCount = 20;
    [Tooltip("���� ź������ �����ִ� �Ѿ��� ����")]
    public int currentBulletCount = 20;
    [Tooltip("�ִ� ���� ���� �Ѿ� ����")]
    public int maxBulletCount = 60;
    [Tooltip("���� �����ϰ� �ִ� �Ѿ� ����")]
    public int carryBulletCount = 60;

    [Header("Hand Gun Animator")]
    public Animator HandGunAnimator;
    public Animator HandGunArmAnimator;
}

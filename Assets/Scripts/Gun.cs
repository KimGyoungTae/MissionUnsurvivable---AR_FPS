using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string gunName; // ���� �̸�.

    public int reloadBulletCount = 20;   // �Ѿ� ������ ����
    public int currentBulletCount = 20; // ���� ź������ �����ִ� �Ѿ��� ����.
    public int maxBulletCount = 60; // �ִ� ���� ���� �Ѿ� ����.
    public int carryBulletCount = 60; //���� �����ϰ� �ִ� �Ѿ� ����.


   

    public Animator anim;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Arm : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    Animator anis;


    //public string gunName; // ���� �̸�.

    //public int reloadBulletCount;   // �Ѿ� ������ ����
    //public int currentBulletCount; // ���� ź������ �����ִ� �Ѿ��� ����.
    //public int maxBulletCount; // �ִ� ���� ���� �Ѿ� ����.
    //public int carryBulletCount; // ���� �����ϰ� �ִ� �Ѿ� ����.


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

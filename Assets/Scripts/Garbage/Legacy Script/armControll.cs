using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControll : MonoBehaviour
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
        anis.CrossFadeInFixedTime("rebound", 0.01f);
    }


    public void Reload()
    {
        // �����ϰ� �ִ� �Ѿ��� ������ ������, ������ ������ �Ұ���
        if (currentGun.carryBulletCount > 0)
        {
            currentGun.anim.SetTrigger("Reload");
            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {   // Ǯ�� reload
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
                //���� ������ �Ѿ� ������ �������� ������ŭ ����
            }
            else
            {
                //���� ������ �Ѿ��� 5��, ������ �ϴ� �Ѿ� ������ 10���� ����,  5�߸� ������
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }
        }

    }


    // ���� �ٲٷ��� �õ��� �ߴ� �� ����..
    public void GunChange(Gun _gun)
    {
        if(WeaponManager.currentWeapon != null)  // ���𰡸� ��� �ִ� ���
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);
        }
        currentGun = _gun; //�ٲٰ����ϴ� ���� ���� ������
        WeaponManager.currentWeapon = currentGun.GetComponent<Transform>();
        WeaponManager.currentWeaponAnim = currentGun.anim;

        currentGun.transform.localPosition = Vector3.zero; // (0.0.0) ��ǥ�� �ʱ�ȭ
        currentGun.gameObject.SetActive(true);

    }
       
    
}



//             if (carryBulletCount > 0)
//{
//    anis.SetTrigger("Reload");
//    if (carryBulletCount >= reloadBulletCount)
//    {
//        currentBulletCount = reloadBulletCount;
//        carryBulletCount -= reloadBulletCount;
//    }

//    else
//    {
//        currentBulletCount = carryBulletCount;
//        carryBulletCount = 0;
//    }
//}

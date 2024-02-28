using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControll : MonoBehaviour
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
        anis.CrossFadeInFixedTime("rebound", 0.01f);
    }


    public void Reload()
    {
        // 소유하고 있는 총알이 있으면 재장전, 없으면 재장전 불가능
        if (currentGun.carryBulletCount > 0)
        {
            currentGun.anim.SetTrigger("Reload");
            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {   // 풀로 reload
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
                //현재 소유한 총알 개수가 재장전한 개수만큼 빠짐
            }
            else
            {
                //현재 소유한 총알은 5발, 재장전 하는 총알 개수는 10발인 예시,  5발만 재장전
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }
        }

    }


    // 총을 바꾸려는 시도를 했던 것 같음..
    public void GunChange(Gun _gun)
    {
        if(WeaponManager.currentWeapon != null)  // 무언가를 들고 있는 경우
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);
        }
        currentGun = _gun; //바꾸고자하는 총을 현재 총으로
        WeaponManager.currentWeapon = currentGun.GetComponent<Transform>();
        WeaponManager.currentWeaponAnim = currentGun.anim;

        currentGun.transform.localPosition = Vector3.zero; // (0.0.0) 좌표로 초기화
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

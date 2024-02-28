using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArm : MonoBehaviour
{
    [Tooltip("현재 소유한 총기의 총알의 개수를 담당하는 컴포넌트")]
    [SerializeField] private ManageGun currentGun;

    [SerializeField] private Animator armAnimator; //애니메이션 변수

    [Header("Sound")]
    public AudioSource ReloadSound; //재장전 사운드
    
    void Start()
    {
        armAnimator = GetComponent<Animator>();
    }

    public void work()
    {
        armAnimator.CrossFadeInFixedTime("rebound", 0.01f);
    }

    public void Reload()
    {
        // 소유하고 있는 총알이 있으면 재장전, 없으면 재장전 불가능
        if (currentGun.carryBulletCount > 0)
        {
            armAnimator.SetTrigger("Reload"); // 재장전 모션 재생
            //currentGun.HandGunArmAnimator.SetTrigger("Reload");
           // currentGun.HandGunAnimator.SetTrigger("weapon");
            ReloadSound.Play();
          
            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount) // 가지고 있는 총알 >= 탄창에 넣어야할 총알 개수
            {   
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
                //현재 소유한 총알 개수가 탄창에 넣은 개수만큼 빠짐
            }
            else
            {
                // 가지고 있는 총알이 탄창에 넣어야할 총알보다 부족한 경우
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }
        }
    }

    public ManageGun GetGun()
    {
        return currentGun;
    }
}

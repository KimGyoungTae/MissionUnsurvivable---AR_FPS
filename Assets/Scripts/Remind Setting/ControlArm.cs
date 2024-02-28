using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArm : MonoBehaviour
{
    [Tooltip("���� ������ �ѱ��� �Ѿ��� ������ ����ϴ� ������Ʈ")]
    [SerializeField] private ManageGun currentGun;

    [SerializeField] private Animator armAnimator; //�ִϸ��̼� ����

    [Header("Sound")]
    public AudioSource ReloadSound; //������ ����
    
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
        // �����ϰ� �ִ� �Ѿ��� ������ ������, ������ ������ �Ұ���
        if (currentGun.carryBulletCount > 0)
        {
            armAnimator.SetTrigger("Reload"); // ������ ��� ���
            //currentGun.HandGunArmAnimator.SetTrigger("Reload");
           // currentGun.HandGunAnimator.SetTrigger("weapon");
            ReloadSound.Play();
          
            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount) // ������ �ִ� �Ѿ� >= źâ�� �־���� �Ѿ� ����
            {   
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
                //���� ������ �Ѿ� ������ źâ�� ���� ������ŭ ����
            }
            else
            {
                // ������ �ִ� �Ѿ��� źâ�� �־���� �Ѿ˺��� ������ ���
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

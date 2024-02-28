using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{

    [Tooltip("� �ѱ⸦ UI�� ��Ÿ�� ������")]
    [SerializeField] private ControlArm theGunController;
    // private gunfire theGunController;
   
    private ManageGun currentGun;   // ���� �ѱ��� ������ �޾ƿ� ����
    // private Gun currentGun;
   
    [SerializeField] private GameObject go_BulletHUD;   // ���� ���� ������

    // �Ѿ� ���� UI�� �ݿ�
    [SerializeField] private TextMeshProUGUI[] textAmmo; //���� źâ �Ѿ� / ���� ���� ź��
    
    void Update()
    {
        CheckBullet();
    }

    private void CheckBullet()
    {
        currentGun = theGunController.GetGun(); //���� ������ �ִ� �ѱ��� ������ �޾ƿ´�.
        textAmmo[0].text = currentGun.currentBulletCount.ToString();
        textAmmo[1].text = currentGun.carryBulletCount.ToString();
    }
}

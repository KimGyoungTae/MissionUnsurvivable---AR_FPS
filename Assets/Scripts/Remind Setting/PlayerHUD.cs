using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{

    [Tooltip("어떤 총기를 UI에 나타낼 것인지")]
    [SerializeField] private ControlArm theGunController;
    // private gunfire theGunController;
   
    private ManageGun currentGun;   // 현재 총기의 정보를 받아올 변수
    // private Gun currentGun;
   
    [SerializeField] private GameObject go_BulletHUD;   // 현재 무기 아이콘

    // 총알 개수 UI에 반영
    [SerializeField] private TextMeshProUGUI[] textAmmo; //현재 탄창 총알 / 현재 소유 탄수
    
    void Update()
    {
        CheckBullet();
    }

    private void CheckBullet()
    {
        currentGun = theGunController.GetGun(); //현재 가지고 있는 총기의 정보를 받아온다.
        textAmmo[0].text = currentGun.currentBulletCount.ToString();
        textAmmo[1].text = currentGun.carryBulletCount.ToString();
    }
}

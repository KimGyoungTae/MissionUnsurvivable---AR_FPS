using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName { AssultRifle = 0}

public class weaponSetting : MonoBehaviour
{
    public WeaponName weaponName;   //무기이름
    public int currentAmmo; //현재 탄약
    public int maxAmmo; //최대 탄약
    public float attackRate;    //공격속도
    public float attackDistance;    //공격 사거리
    
}

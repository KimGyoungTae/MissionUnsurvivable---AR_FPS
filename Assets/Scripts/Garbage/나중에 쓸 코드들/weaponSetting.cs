using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName { AssultRifle = 0}

public class weaponSetting : MonoBehaviour
{
    public WeaponName weaponName;   //�����̸�
    public int currentAmmo; //���� ź��
    public int maxAmmo; //�ִ� ź��
    public float attackRate;    //���ݼӵ�
    public float attackDistance;    //���� ��Ÿ�
    
}

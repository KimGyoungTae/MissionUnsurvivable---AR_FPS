using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Ŭ���� ���� = ���� ����(static)
    // ���� �ߺ� ��ü ���� ����.
    public static bool isChangeWeapon = false;

    // ���� ����� ���� ������ �ִϸ��̼�
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;

    // ���� ������ Ÿ��.
    [SerializeField]
    private string currentWeaponType;

    // ���� ��ü ������, ���� ��ü�� ������ ���� ����.
    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDelayTime;

    // ���� ������ ���� ����.
    [SerializeField]
    private Gun[] guns;
    //[SerializeField]
    //private Hand[] hands;

    // ���� �������� ���� ���� ������ �����ϵ��� ����.
    private Dictionary<string, Gun> gunDictionary = new Dictionary<string, Gun>();

    //[SerializeField]
    //private GunController theGunController;


    private armControll thearmControll;
   
   

    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            gunDictionary.Add(guns[i].gunName, guns[i]);
        }

        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(!isChangeWeapon)
    //    {
    //        //���� 1�� ������ �� ���� ��ü ����
    //        if (Input.GetKeyDown(KeyCode.Alpha1))
    //            StartCoroutine(ChangeWeaponCoroutine("Gun"));

    //    }
    //}

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true; //���ⱳü�� �ߺ����� ������� �ʱ� ����
        currentWeaponAnim.SetTrigger("WeaponOut");

        yield return new WaitForSeconds(changeWeaponDelayTime);

        WeaponChange(_type, _name);

        yield return new WaitForSeconds(changeWeaponEndDelayTime);
       
        currentWeaponType = _type;
        isChangeWeapon=false;
    }

    private void WeaponChange(string _type, string _name)
    {
        if(_type == "GUN")
        {
            thearmControll.GunChange(gunDictionary[_name]);
        }
    }
}

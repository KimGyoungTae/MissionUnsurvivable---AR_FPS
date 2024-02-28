using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // 클래스 변수 = 정적 변수(static)
    // 무기 중복 교체 실행 방지.
    public static bool isChangeWeapon = false;

    // 현재 무기와 현재 무기의 애니메이션
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;

    // 현재 무기의 타입.
    [SerializeField]
    private string currentWeaponType;

    // 무기 교체 딜레이, 무기 교체가 완전히 끝난 시점.
    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDelayTime;

    // 무기 종류들 전부 관리.
    [SerializeField]
    private Gun[] guns;
    //[SerializeField]
    //private Hand[] hands;

    // 관리 차원에서 쉽게 무기 접근이 가능하도록 만듬.
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
    //        //숫자 1을 눌렀을 때 무기 교체 실행
    //        if (Input.GetKeyDown(KeyCode.Alpha1))
    //            StartCoroutine(ChangeWeaponCoroutine("Gun"));

    //    }
    //}

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true; //무기교체가 중복으로 실행되지 않기 위해
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

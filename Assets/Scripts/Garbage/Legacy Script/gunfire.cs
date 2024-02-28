using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gunfire : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    public Camera fpsCamera;
    public float range = 100f;       // 범위
    public float damage = 10f;        //적에게 주는 피해
    
    public float impactForce = 60f;
    public AudioSource gunsound;        // 총기 사운드(권총)

    public ParticleSystem muzzleFlash;  // 총구 이펙트 파티클
   // public GameObject muzzleFlashEffect;

    public Text enemyText;      //UI에 표시되는 "Score : " 
    private float enemyScore;   //적을 죽일때마다 올라가는 점수

    public GameObject impactEffect; // 적 피격 파티클

    Animator ani;
    Transform tr;

    private armControll reloading;
    public AudioSource ReloadSound;

    private Wizard_Move wizard;



    private void Start()
    {
        ani = GetComponent<Animator>();
        tr = GetComponent<Transform>();


    }

    private void Awake()
    {
        enemyText.text = enemyScore.ToString("Score : 0");
    }

  //리팩토링 진행
    public void shoot()
    {
        currentGun.currentBulletCount--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
         
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Instantiate(impactEffect, hit.point, Quaternion.identity);
                enemy.takedamage(damage);
                wizard.userhit(); 


                enemyScore++; // ==> if문을 이용해 enemy가 사망했을 때 점수 증가로 바꾸기
                enemyText.text = enemyScore.ToString("Score : 0");
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

          
        }
       
       ani.CrossFadeInFixedTime("Fire", 0.01f);
        ani.CrossFadeInFixedTime("AR Fire", 0.01f);
        

        gunsound.Play();
        StartCoroutine("OnMuzzleFlashEffect");  //총구 이펙트 재생

      

    }

    public void Reload()
    {
        // 소유하고 있는 총알이 있으면 재장전, 없으면 재장전 불가능
        if (currentGun.carryBulletCount > 0)
        {
            currentGun.anim.SetTrigger("weapon");
            ReloadSound.Play();  
        }
    }


    public IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlash.Play();
     //   muzzleFlashEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);  //play 실행 후 0.2초 대기
        muzzleFlash.Stop();
      //  muzzleFlashEffect.SetActive(false);
    }

    public Gun GetGun()
    {
        return currentGun;
    }
}




// Update is called once per frame
/*
 void Update()
 {
         if (Input.GetButtonDown("Fire1"))
     {
         Shoot();
     }
 }
*/

/*

public void Shoot ()
{
    muzzleFlash.Play();

    RaycastHit hit;
   if  (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
    {

    //    Target target = hit.transform.GetComponent<Target>();
        if(hit.transform.name == "Cube(Clone)")
        {
           Destroy(hit.transform.gameObject);
        }

        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
*/

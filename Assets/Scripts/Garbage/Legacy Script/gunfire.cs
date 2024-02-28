using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gunfire : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    public Camera fpsCamera;
    public float range = 100f;       // ����
    public float damage = 10f;        //������ �ִ� ����
    
    public float impactForce = 60f;
    public AudioSource gunsound;        // �ѱ� ����(����)

    public ParticleSystem muzzleFlash;  // �ѱ� ����Ʈ ��ƼŬ
   // public GameObject muzzleFlashEffect;

    public Text enemyText;      //UI�� ǥ�õǴ� "Score : " 
    private float enemyScore;   //���� ���϶����� �ö󰡴� ����

    public GameObject impactEffect; // �� �ǰ� ��ƼŬ

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

  //�����丵 ����
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


                enemyScore++; // ==> if���� �̿��� enemy�� ������� �� ���� ������ �ٲٱ�
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
        StartCoroutine("OnMuzzleFlashEffect");  //�ѱ� ����Ʈ ���

      

    }

    public void Reload()
    {
        // �����ϰ� �ִ� �Ѿ��� ������ ������, ������ ������ �Ұ���
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
        yield return new WaitForSeconds(0.2f);  //play ���� �� 0.2�� ���
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wizard_Move : MonoBehaviour
{
    NavMeshAgent agent;
    Transform Ar_Player;

    float RotSpeed = 3.0f;
    float MoveSpeed = 0.5f;

    Animator animss;
    bool isDead = false;
    public bool canAttack = true;

    // public Camera arcamera;
    public float damageAmout = 10f;
    float attackTime = 2f;

  //  public float ShakeAmount;
  //  public float ShakeTime;
    ARCameraShake ARcamera;
    //Vector3 initialPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        Ar_Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animss = GetComponent<Animator>();
      //  initialPosition = new Vector3(arcamera.transform.position.x, arcamera.transform.position.y,
      //     arcamera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Ar_Player.transform.position);
     

        if (distance > 2 )
        {
            agent.updatePosition = true;
            agent.SetDestination(Ar_Player.position);
            animss.SetBool("move_forward", true);
            animss.SetBool("idle_normal", false);
          InvokeRepeating("attackanim", 0.1f, 0.3f);   //몬스터 공격 반복
            
        }

        /*
        else if (distance <= 2)
        {
            agent.updatePosition = false;
            //invoke 함수 >> 매 초마다 공격함수 실행
            //  StartCoroutine(attackanim());
            animss.SetBool("move_forward", false);
            animss.SetBool("attack_short_001", true);
            InvokeRepeating("attackanim", 0.1f, 2);
        }
        */

        else if (canAttack && !PlayerHealth.singleton.isDead)
        {
            agent.updatePosition = false;
            animss.SetBool("move_forward", false);
            animss.SetBool("attack_short_001", true);
          //  StartCoroutine(AttackTime());
        }

        else if (PlayerHealth.singleton.isDead)
        {
            DisableEnemy();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
               (Ar_Player.position - transform.position), RotSpeed * Time.deltaTime);

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

    }

    //공격함수 이 안에는 사용자 카메라 흔들림 함수 호출 넣어야함.
    public void attackanim()
    {
        animss.SetBool("move_forward", false);
        animss.SetBool("attack_short_001", true);

        //ARcamera.VibraterForTime(ShakeTime, ShakeAmount); // 카메라 흔들림 함수 호출

    }

    public void userhit()
    {
        animss.SetBool("move_forward", false);
        animss.SetBool("attack_short_001", false);
        animss.SetBool("damage_001", true);
    }



    public void EnemyDeathAnim()
    {
        isDead = true;
        animss.SetTrigger("isdead");
    }

    void DisableEnemy()
    {
        canAttack = false;
        animss.SetBool("move_forward", false);
        animss.SetBool("attack_short_001", false);
    }

    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.PlayerDamage(damageAmout);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }

    /*
    private IEnumerator ShakeByPosition()
    {
        //Vector3 startPosition = transform.position;

        initialPosition = new Vector3(arcamera.transform.position.x, arcamera.transform.position.y,
          arcamera.transform.position.z);

        while (ShakeTime > 0)
        {
            transform.position = initialPosition + Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;

            yield return null;


        }
        
       
        //    ShakeTime = 0.0f;
            transform.position = initialPosition;
     
    }



    */



    /*
    IEnumerator attackanim()
    {
        animss.SetBool("move_forward", false);
        animss.SetBool("attack_short_001", true);
        yield return new WaitForSeconds(0.5f);
    }

    */
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    Transform Ar_Player;

    float RotSpeed = 3.0f;
    float MoveSpeed = 2f;       // 가속도

    Animator anim;
    bool isDead = false;
    public bool canAttack = true;

    public float damageAmout;
    float attackTime = 2f;

   
    void Start()
    {
        
        Ar_Player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

     
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Ar_Player.transform.position);

        //if(distance <=1.5f) canAttack = true;

        if(distance > 1.5f && !isDead)
        {
            agent.updatePosition = true;
            agent.SetDestination(Ar_Player.position);   // -> 현재 오류 부분 (2023.10.10)
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            StartCoroutine("addrun");
        }

        else if(canAttack && !PlayerHealth.singleton.isDead)
        {
            agent.updatePosition = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
            StartCoroutine(AttackTime());
        }

        else if(PlayerHealth.singleton.isDead)
        {
            DisableEnemy();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation
            (Ar_Player.position - transform.position), RotSpeed * Time.deltaTime);

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    IEnumerator addrun()
    {
        yield return new WaitForSeconds(1.0f); // 1초 이후에 아래 코드 실행
        anim.SetTrigger("isRun");
    }
    public void EnemyDeathAnim()
    {
        isDead = true;
        agent.updatePosition = false;
        StopCoroutine("addrun");    // 코루틴 종료
        anim.SetTrigger("isDead");      // 죽는 모션
      //  Ar_Player = null;   // 추적 종료

       Destroy(this.gameObject, 1.0f);  // ==> 이걸 주석 시 적은 죽은 모션으로 둥둥 떠나니는 현상 발생
    }

    void DisableEnemy()
    {
        canAttack = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);

        // 코루틴도 종료시켜줘야 할 것 같음
    }

    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.PlayerDamage(damageAmout);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }
}

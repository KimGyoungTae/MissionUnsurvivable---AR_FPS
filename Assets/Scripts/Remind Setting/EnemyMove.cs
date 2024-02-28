using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    Transform Ar_Player;

    float RotSpeed = 3.0f;
    float MoveSpeed = 2f;       // ���ӵ�

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
            agent.SetDestination(Ar_Player.position);   // -> ���� ���� �κ� (2023.10.10)
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
        yield return new WaitForSeconds(1.0f); // 1�� ���Ŀ� �Ʒ� �ڵ� ����
        anim.SetTrigger("isRun");
    }
    public void EnemyDeathAnim()
    {
        isDead = true;
        agent.updatePosition = false;
        StopCoroutine("addrun");    // �ڷ�ƾ ����
        anim.SetTrigger("isDead");      // �״� ���
      //  Ar_Player = null;   // ���� ����

       Destroy(this.gameObject, 1.0f);  // ==> �̰� �ּ� �� ���� ���� ������� �յ� �����ϴ� ���� �߻�
    }

    void DisableEnemy()
    {
        canAttack = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);

        // �ڷ�ƾ�� ���������� �� �� ����
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

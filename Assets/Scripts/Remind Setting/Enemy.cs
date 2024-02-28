using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20f;

    EnemyMove enemyAI;
    Wizard_Move WizardAI;

   public bool isEneymyDead;

    private void Start()
    {
        enemyAI = GetComponent<EnemyMove>();
        //wizard AI �� Get������Ʈ �ʿ���.
    }

    public void takedamage(float damageAmount)
    {
        if (!isEneymyDead) {

           health = health - damageAmount;

        if (health <= 0)
            {
        
              health = 0;
             isEneymyDead = true;   // ==> false�̳� true �̳� ������ ���� �׾��µ��� ���� �°� ���� �Ͼ�� ������ �߻�

                enemyAI.EnemyDeathAnim();       // EnemyMove Ŭ���� 
                WizardAI.EnemyDeathAnim();
           //   Destroy(this.gameObject, 0.5f);  ==> �̰� ���߿� ������ �ڵ�, �ּ�ó�� ���ص� ���� ������� �ʴ´�.

            }
        }
    }
}
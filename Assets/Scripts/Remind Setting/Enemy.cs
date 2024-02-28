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
        //wizard AI 도 Get컴포넌트 필요함.
    }

    public void takedamage(float damageAmount)
    {
        if (!isEneymyDead) {

           health = health - damageAmount;

        if (health <= 0)
            {
        
              health = 0;
             isEneymyDead = true;   // ==> false이냐 true 이냐 에따라 좀비가 죽었는데도 총을 맞고도 벌떡 일어나는 오류가 발생

                enemyAI.EnemyDeathAnim();       // EnemyMove 클래스 
                WizardAI.EnemyDeathAnim();
           //   Destroy(this.gameObject, 0.5f);  ==> 이건 나중에 삭제할 코드, 주석처리 안해도 적은 사라지지 않는다.

            }
        }
    }
}
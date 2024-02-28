using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public float health = 20f;
    public bool isEneymyDead;   //bool 타입 초기값은 True
  
    public void getdamage(float damageAmount)
    {
        if (!isEneymyDead) // 적이 죽지 않으면
        {
            health -= damageAmount; //데미지 받은 만큼 Enemy의 Health가 깎인다.

            if (health <= 0)
            {
                 Destroy(this.gameObject, 0.5f); //적이 사라진다.
                 PlayerInform.instance.AddScore(1); // EnemyCube의 피가 0이하일 때 점수가 1씩증가
            }
        }
    }
}

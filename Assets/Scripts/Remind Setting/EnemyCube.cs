using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public float health = 20f;
    public bool isEneymyDead;   //bool Ÿ�� �ʱⰪ�� True
  
    public void getdamage(float damageAmount)
    {
        if (!isEneymyDead) // ���� ���� ������
        {
            health -= damageAmount; //������ ���� ��ŭ Enemy�� Health�� ���δ�.

            if (health <= 0)
            {
                 Destroy(this.gameObject, 0.5f); //���� �������.
                 PlayerInform.instance.AddScore(1); // EnemyCube�� �ǰ� 0������ �� ������ 1������
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{
    [Tooltip("���� ������ �ѱ��� �Ѿ��� ������ ����ϴ� ������Ʈ")]
    [SerializeField] private ManageGun currentGun;
    [Tooltip("�÷��̾ �����ϴ� ��ġ�� ����")]
    public Camera fpsCamera;

    [Header ("Sound")]
    public AudioSource HandGunSound;        // �ѱ� ����(����)
    public AudioSource EmptySound;          // �Ѿ��� ���� �� ����
                                            
    [Header ("Particle")]
    public ParticleSystem muzzleFlash;  // �ѱ� ����Ʈ ��ƼŬ
    public GameObject impactEffect;     // �� �ǰ� ��ƼŬ (����, �Ѿ��� ���� �ڱ� ��)

    [HideInInspector] public float range = 100f;       // ������ �󸶳� ����Ǵ��� ����, ������ ������ �� �� �ִ�.
    [HideInInspector] public float damage = 10f;       //������ �ִ� ���ط�
    [HideInInspector] public float impactForce = 60f;     // Raycast�� Rigidbody ��Ұ� ������ ��ü�� �����ϴ� ��� ���ǵǴ� �縸ŭ ���� ���Ѵ�.

    public void shoot()
    {
        currentGun.currentBulletCount--;    // ���� �� ������ ź������ �ִ� �Ѿ� 1�� ����
        
        if (currentGun.currentBulletCount <= 0) // ź������ �ִ� �Ѿ� ���� �� 
        {
            currentGun.currentBulletCount = 0; // ���̳ʽ��� �������� �ʵ��� �Ѿ��� 0���� ����
            EmptySound.Play();  // �Ѿ��� ����ٴ°� �˷��ֱ� ���� ���� ���
        }

        else // �Ѿ��� ���� ����
        {
            checkRaycast(); // Raycast Ȯ���Ѵ�.
            HandGunSound.Play();    // �ѱ���� ���
            StartCoroutine("OnMuzzleFlashEffect");  // �ѱ� ����Ʈ ���
        }
    }

    public void checkRaycast()
    {
        RaycastHit hit; // ���̿��� ��ȯ�� ������ �����ϴ� ����
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {   // �ݶ��̴��� ���� ������Ʈ�� �浹 ���θ� üũ�մϴ�. �浹�� �Ǹ� True�� ��ȯ�ϰ�, RaycastHit�� �浹������ �Ѱ���.

            EnemyCube enemy = hit.transform.GetComponent<EnemyCube>();  // �浹�� ������ �浹ü���� EnemyCube�� ���� ������Ʈ ������ �����ɴϴ�.

            if (enemy != null)  // ���� ���� �����Ѵٸ�
            {
                Instantiate(impactEffect, hit.point, Quaternion.identity);  // ���� �� �� ��ġ�� �ǰ� ��ƼŬ ����
                enemy.getdamage(damage);   // enemy���� ���ط��� ������.
            }

            if (hit.rigidbody != null)  // RayCast�� ������ ���� ������Ʈ�� Rigidbody ������Ұ� �ִٸ�
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); // AddForce(���� * �� ��)
            }
        }
    }

    public IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlash.Play();
        yield return new WaitForSeconds(0.2f);  // play ���� �� 0.2�� ���
        muzzleFlash.Stop();
    }
}

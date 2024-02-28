using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{
    [Tooltip("현재 소유한 총기의 총알의 개수를 담당하는 컴포넌트")]
    [SerializeField] private ManageGun currentGun;
    [Tooltip("플레이어가 조준하는 위치를 결정")]
    public Camera fpsCamera;

    [Header ("Sound")]
    public AudioSource HandGunSound;        // 총기 사운드(권총)
    public AudioSource EmptySound;          // 총알이 없을 때 사운드
                                            
    [Header ("Particle")]
    public ParticleSystem muzzleFlash;  // 총구 이펙트 파티클
    public GameObject impactEffect;     // 적 피격 파티클 (혈흔, 총알이 박힌 자국 등)

    [HideInInspector] public float range = 100f;       // 광선이 얼마나 투사되는지 결정, 무기의 범위로 볼 수 있다.
    [HideInInspector] public float damage = 10f;       //적에게 주는 피해량
    [HideInInspector] public float impactForce = 60f;     // Raycast가 Rigidbody 요소가 부착된 객체와 교차하는 경우 정의되는 양만큼 힘을 가한다.

    public void shoot()
    {
        currentGun.currentBulletCount--;    // 총을 쏠 때마다 탄알집에 있는 총알 1씩 감소
        
        if (currentGun.currentBulletCount <= 0) // 탄알집에 있는 총알 소진 시 
        {
            currentGun.currentBulletCount = 0; // 마이너스로 떨어지지 않도록 총알을 0으로 유지
            EmptySound.Play();  // 총알이 비었다는걸 알려주기 위해 사운드 재생
        }

        else // 총알이 있을 때만
        {
            checkRaycast(); // Raycast 확인한다.
            HandGunSound.Play();    // 총기사운드 재생
            StartCoroutine("OnMuzzleFlashEffect");  // 총구 이펙트 재생
        }
    }

    public void checkRaycast()
    {
        RaycastHit hit; // 레이에서 반환된 정보를 보유하는 변수
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {   // 콜라이더를 가진 오브젝트와 충돌 여부를 체크합니다. 충돌이 되면 True를 반환하고, RaycastHit로 충돌정보를 넘겨줌.

            EnemyCube enemy = hit.transform.GetComponent<EnemyCube>();  // 충돌을 감지한 충돌체에서 EnemyCube에 대한 컴포넌트 정보를 가져옵니다.

            if (enemy != null)  // 적이 만약 존재한다면
            {
                Instantiate(impactEffect, hit.point, Quaternion.identity);  // 총을 쏜 그 위치에 피격 파티클 생성
                enemy.getdamage(damage);   // enemy에게 피해량을 입힌다.
            }

            if (hit.rigidbody != null)  // RayCast로 적중한 게임 오브젝트에 Rigidbody 구성요소가 있다면
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); // AddForce(방향 * 힘 값)
            }
        }
    }

    public IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlash.Play();
        yield return new WaitForSeconds(0.2f);  // play 실행 후 0.2초 대기
        muzzleFlash.Stop();
    }
}

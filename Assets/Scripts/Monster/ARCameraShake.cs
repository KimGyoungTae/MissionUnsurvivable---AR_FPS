using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraShake : MonoBehaviour
{
    [SerializeField] float ShakeAmount = 0f; //��鸲 ���� ����
    [SerializeField] Vector3 offset = Vector3.zero; // ��鸲 ���� �������� ����
    public float ShakeTime;

    private float shakeIntensity = 0.1f;

    Quaternion originRot; // ī�޶� �ʱⰪ ������ ����
     public IEnumerator VibraterForTime(float time, float amount)
    {
        originRot = transform.rotation;
        this.ShakeTime = time;
        this.ShakeAmount = amount;


      //  StopCoroutine("ShakeByPosition");
      //  StartCoroutine("ShakeByPosition");

      //  StopCoroutine("ShakeByRotation");
       
        //StartCoroutine(ShakeCoroutine());                 // ī�޶� ���� �ڷ�ƾ ����
        
        yield return new WaitForSeconds(0.05f);
        StopAllCoroutines();
        StartCoroutine(Reset());

    }
    /*
    IEnumerator ShakeCoroutine()
    {
        Vector3 originAngles = transform.eulerAngles;
        while (true)
        {
            float rotx = Random.Range(-offset.x, offset.x);
            float roty = Random.Range(-offset.y, offset.y);
            float rotz = Random.Range(-offset.z, offset.z);

            Vector3 randomRot = originAngles + new Vector3(rotx, roty, rotz);
            Quaternion rot = Quaternion.Euler(randomRot);

            while(Quaternion.Angle(transform.rotation, rot) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, ShakeAmount * Time.deltaTime);
                yield return null; 
            }
            yield return null;
        }
    }
    */

    //private IEnumerator ShakeByPosition()
    //{
    //    Vector3 startPosition = transform.position;

        
    //    while (ShakeTime > 0)
    //    {
    //        transform.position = startPosition + Random.insideUnitSphere * ShakeAmount;
    //        ShakeTime -= Time.deltaTime;

    //        yield return null;


    //    }
        
    //    transform.position = startPosition;

    //}

    //private IEnumerator ShakeByRotation()
    //{
    //    Vector3 startRotation = transform.eulerAngles;

    //    float power = 10f;

    //    while ( ShakeTime > 0)

    //    {
    //        float x = Random.Range(-1f, 1f);
    //        float y = Random.Range(-1f, 1f);
    //        float z = Random.Range(-1f, 1f);

    //transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, z) * shakeIntensity * power);

    //        ShakeTime -= Time.deltaTime;

    //        yield return null;
    //    }

    //    transform.rotation = Quaternion.Euler(startRotation);
    //}


    IEnumerator Reset()
    {

        while(Quaternion.Angle(transform.rotation, originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originRot, ShakeAmount * Time.deltaTime);
            yield return null;
        }
    }


    }

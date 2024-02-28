using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlanePlane : MonoBehaviour
{
    public ARRaycastManager arRaycast;
    public GameObject placeObject;  //� ������Ʈ�� ���� ��ġ�� ������?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCenterObject(); //�� �����Ӹ��� �Լ� ����
    }

    private void UpdateCenterObject()
    {
        //Screen�� CenterPoint�� �޾ƿ��ڴ�.
        Vector3 ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); 
        // ViewportToScreenPoint�� viewport ��ǥ�� screen ��ǥ�� ��ȯ�Ѵ�. ��, Camera screen�� center ������ �޾ƿ��� �Լ�

        List<ARRaycastHit> hits = new List<ARRaycastHit>(); //hits�� Ray�� �� ������� ��ȯ

        //AR Raycast���� ������ ���� �ű⿡ �浹�Ǵ� ��� ������Ʈ�� �޾ƿ´�.
        arRaycast.Raycast(ScreenCenter, hits, TrackableType.Planes); 
        //  (��� �������� �������, Ray�� ���� �浹�Ǵ� ��ü List�� ��ȯ, � Ÿ���� ������Ʈ�鸸 ����� ������)
      
        
        if(hits.Count > 0)  //Ray�� ���� �ε�ģ ��ü�� ������ �ű⿡ ��ġ�� �ϰڴ�.
        {
            Pose placementPose = hits[0].pose; //�ε�ģ ��ġ���� 0��° ��, ���� ���� �ε�ģ ��ġ�� ����
            placeObject.SetActive(true);   // ������Ʈ�� ���̰� ����ڴ�.
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation); //���� ���� ������Ʈ�� ��ġ ����

        }
    }
}

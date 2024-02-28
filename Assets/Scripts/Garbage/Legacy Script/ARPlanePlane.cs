using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlanePlane : MonoBehaviour
{
    public ARRaycastManager arRaycast;
    public GameObject placeObject;  //어떤 오브젝트를 위에 배치할 것인지?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCenterObject(); //매 프레임마다 함수 실행
    }

    private void UpdateCenterObject()
    {
        //Screen의 CenterPoint를 받아오겠다.
        Vector3 ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); 
        // ViewportToScreenPoint는 viewport 좌표를 screen 좌표로 변환한다. 즉, Camera screen의 center 지점을 받아오는 함수

        List<ARRaycastHit> hits = new List<ARRaycastHit>(); //hits에 Ray를 쏜 결과물이 반환

        //AR Raycast에서 광선을 쏴서 거기에 충돌되는 모든 오브젝트를 받아온다.
        arRaycast.Raycast(ScreenCenter, hits, TrackableType.Planes); 
        //  (어디 방향으로 쏠것인지, Ray를 쏴서 충돌되는 객체 List로 변환, 어떤 타입의 오브젝트들만 허용할 것인지)
      
        
        if(hits.Count > 0)  //Ray를 쏴서 부딪친 객체가 있으면 거기에 배치를 하겠다.
        {
            Pose placementPose = hits[0].pose; //부딪친 위치에서 0번째 즉, 가장 먼저 부딪친 위치를 저장
            placeObject.SetActive(true);   // 오브젝트를 보이게 만들겠다.
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation); //눈에 보인 오브젝트의 위치 설정

        }
    }
}

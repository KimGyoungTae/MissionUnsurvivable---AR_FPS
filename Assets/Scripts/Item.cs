using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject Box;
    public GameObject Items;

    public Camera arCamera;
    Vector3 Pos;
    Touch touch;

   public PlayerHealth cuhealth;


    // Start is called before the first frame update
    void Start()
    {
       // cuhealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)   //터치 일어날 시
        {

            for (int i = 0; i < Input.touchCount; i++)
            {
                Pos = Input.GetTouch(i).position;

                touch = Input.GetTouch(i);  //터치에 대한 정보받기

                Ray ray = arCamera.ScreenPointToRay(Pos);   //카메라로부터 스크린의 점을 통해 레이를 반환
                RaycastHit hit = new RaycastHit();

                if (touch.phase == TouchPhase.Began)
                {

                    if (true == (Physics.Raycast(ray, out hit)))
                    {
                        switch (hit.collider.name)       // 터치한 오브젝트 이름
                        {
                            case "BoxOfPandora":       //랜덤 상자
                                Instantiate(Items, hit.collider.transform.position, hit.collider.transform.rotation);
                                Destroy(hit.collider.gameObject);
                                break;

                            case "Bottle_Health(Clone)":       // HP회복
                                Destroy(hit.collider.gameObject);
                             
                      
                                    cuhealth.plusHp();
                     
                                //cuhealth.plusHp();
                        
                                break;
                        }
                    }
                }
            }
        }


    }
}
           /*
            // 랜덤 상자 터치 까지는 이어짐. 

            //if (Input.GetMouseButtonDown(0))
            if (Input.touchCount > 0)               // 랜덤상자 터치 구현
            {
                Pos = Input.GetTouch(0).position;
                Touch touch = Input.GetTouch(0);

                if (Input.GetTouch(0).phase != TouchPhase.Began)
                    return;

                Ray ray = arCamera.ScreenPointToRay(Pos);

                RaycastHit hit = new RaycastHit();

                if (true == (Physics.Raycast(ray, out hit)))   

                {

                    if (hit.collider.name == "BoxOfPandora")
                  {

                        Instantiate(Items, Box.transform.position, Box.transform.rotation);
                        Destroy(Box);
                  }

                }
            }
            */



            /// https://202psj.tistory.com/1284

            //if (Input.touchCount > 0)
            //{

            //    Pos = Input.GetTouch(0).position;
            //   // Touch touch = Input.GetTouch(0);

            //    if (Input.GetTouch(0).phase != TouchPhase.Began)
            //        return;

            //    Ray ray = arCamera.ScreenPointToRay(Pos);
            //    RaycastHit hit;

            //    if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
            //    {
            //        Debug.Log(hit.transform.name);

            //        if (hit.collider.name == "BoxOfPandora")
            //        {

            //            Instantiate(Items, Box.transform.position, Box.transform.rotation);
            //            Destroy(Box);
            //        }
            //    }

            //}



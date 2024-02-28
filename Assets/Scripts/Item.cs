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

        if (Input.touchCount > 0)   //��ġ �Ͼ ��
        {

            for (int i = 0; i < Input.touchCount; i++)
            {
                Pos = Input.GetTouch(i).position;

                touch = Input.GetTouch(i);  //��ġ�� ���� �����ޱ�

                Ray ray = arCamera.ScreenPointToRay(Pos);   //ī�޶�κ��� ��ũ���� ���� ���� ���̸� ��ȯ
                RaycastHit hit = new RaycastHit();

                if (touch.phase == TouchPhase.Began)
                {

                    if (true == (Physics.Raycast(ray, out hit)))
                    {
                        switch (hit.collider.name)       // ��ġ�� ������Ʈ �̸�
                        {
                            case "BoxOfPandora":       //���� ����
                                Instantiate(Items, hit.collider.transform.position, hit.collider.transform.rotation);
                                Destroy(hit.collider.gameObject);
                                break;

                            case "Bottle_Health(Clone)":       // HPȸ��
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
            // ���� ���� ��ġ ������ �̾���. 

            //if (Input.GetMouseButtonDown(0))
            if (Input.touchCount > 0)               // �������� ��ġ ����
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



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class WallManager : MonoBehaviour
{
    public GameObject indicator;
    ARRaycastManager arManager;

    Animator aniss;

    // Start is called before the first frame update
    void Start()
    {
         arManager = GetComponent<ARRaycastManager>();
       // arManager = FindObjectOfType<ARRaycastManager>();
        indicator.SetActive(false);
        aniss = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Awake()
    {
        DetectGround();
    }

    void DetectGround()
    {
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            indicator.SetActive(true);
          //  indicator.transform.position = hitInfos[0].pose.position;
          //  indicator.transform.rotation = hitInfos[0].pose.rotation;
            aniss.SetBool('¸Ê', true);
        }
        //else
        //{
        //    indicator.SetActive(false);
        //}
    }
}


//private GameObject indicator;
//ARRaycastManager arManager;


//// Start is called before the first frame update
//void Start()
//{
//    indicator = transform.GetChild(0).gameObject;
//    arManager = FindObjectOfType<ARRaycastManager>();

//    indicator.SetActive(false);
//}

//// Update is called once per frame
//void Update()
//{
//    DetectGround();
//}

//void DetectGround()
//{
//    List<ARRaycastHit> hits = new List<ARRaycastHit>();
//    arManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

//    if (hits.Count > 0)
//    {
//        transform.position = hits[0].pose.position;
//        transform.rotation = hits[0].pose.rotation;

//        if (!indicator.activeInHierarchy)
//        {
//            indicator.SetActive(true);
//        }


//    }
//}
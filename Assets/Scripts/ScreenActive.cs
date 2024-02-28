using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenActive : MonoBehaviour
{
    private bool state;

    public GameObject Canvases;         // ���� ȭ�� â
    public GameObject StartCanvase;
    public GameObject Zombie;           // ���� - ����
    public GameObject Wizard;

    public AudioSource startsound;
    public GameObject Startimage;

    // Start is called before the first frame update
    void Start()
    {
      //  state = true;
        Canvases.SetActive(false);
        Zombie.SetActive(false);
   //     Wizard.SetActive(false);

        startsound.Play();
        Startimage.SetActive(true);
    }

    // Update is called once per frame
   public void StartGameFun()
    {
        Canvases.SetActive(true);
       Zombie.SetActive(true);
        StartCanvase.SetActive(false);
    //    Wizard.SetActive(true);

        startsound.Stop();
        Startimage.SetActive(false );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public Slider healthSlider;
    public Text healthCounter;
    public bool isDead = false;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;

    bool isPause;   //일시정지 상태를 알기 위한 변수

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
       
       currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthCounter();
        isPause = false;
    }


    private void Update()
    {
        if(isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear,colorSmoothing * Time.deltaTime);
            
        }
        isTakingDamage = false;
    }

    public void PlayerDamage(float damage)
    {
        if(currentHealth >0)
        {
            if (damage >= currentHealth)
            {
                isTakingDamage = true;
                Dead();
                Time.timeScale = 0; // 0이면 시간을 정지시킨다.
                isPause = true;
                return;
            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                healthSlider.value -= damage;
            }
            UpdateHealthCounter();
        }
    }


    public void plusHp()
    {
        currentHealth = 100f;
        healthSlider.value += 100;
        UpdateHealthCounter();
    }


    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthSlider.value = 0;
        UpdateHealthCounter();
    }

    void UpdateHealthCounter()
    {
        healthCounter.text = currentHealth.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Text HealthText;
    public Slider healthSlider;


    // Update is called once per frame
    void Update()
    {
        HealthText = GetComponent<Text>();
        HealthText.text = PlayerHealthManager.playerHealth.ToString();
        float healthAmount = PlayerHealthManager.playerHealth;
        healthSlider.value = healthAmount;
    }
}

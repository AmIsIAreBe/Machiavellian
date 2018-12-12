using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceHUD : MonoBehaviour
{
    PlayerExperience pE;
    public Text ExperienceText;
    public Slider ExperienceSlider;

    // Update is called once per frame
    void Update()
    {
        pE = FindObjectOfType<PlayerExperience>();
        ExperienceText = GetComponent<Text>();
        ExperienceText.text = pE.totalExperience.ToString() + "/100";
        float experienceAmount = pE.totalExperience;
        ExperienceSlider.value = experienceAmount;
    }
}

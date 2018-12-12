using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int experienceGainedToAdd;
    public float totalExperience;
    BasicSwordController sword;
    public bool e_s_done;

    void Awake()
    {
        sword = FindObjectOfType<BasicSwordController>();
    }

    // Update is called once per frame
    void Update()
    {
        totalExperience = sword.experience;
        //Debug.Log("The total player experience earned is: " + totalExperience);
        if (GameController.controller.gameLoadOccured)
        {
            SaveExperienceUpdate();
        }
        //make sure that the update is complete
        GameController.controller.gameLoadExperienceDone = true;
    }

    public void SaveExperienceUpdate()
    {
        totalExperience = GameController.controller.s_experience;
    }
}

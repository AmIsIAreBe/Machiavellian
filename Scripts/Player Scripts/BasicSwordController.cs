using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSwordController : MonoBehaviour
{
    //an integer that is used to determine the amount of damage the player will do to the monster
    //damage is determined in the Inspector
    public int damageToGive;
    //experience the player recieves for fighting the nuzzler
    public float experience;
    public float experienceAmountOnAttack;

    //method that detects when the players sword collides with an object
    void OnTriggerEnter2D(Collider2D col)
    {
        //it runs this code of the colliding objects tag is named Enemy
        if (col.gameObject.tag == "Enemy")
        {
            experience = experience + experienceAmountOnAttack;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //get the script for the Nuzzler, access the public method with a parameter used to calculate the damage
            col.GetComponent<NuzzlerHealthManager>().giveDamage(damageToGive);
        }
    }
}
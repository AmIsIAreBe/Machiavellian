using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuzzlerHealthManager : MonoBehaviour
{
    //the total health of a nuzzle, set in the inspector
    public int nuzzlerHealth;
    //tell the nuzcontroller it's been hit so the behavior can change
    public bool hit;

    // Update is called once per frame
    void Update()
    {
        //if the nuzzler has nomore health, kill the nuzzler
        if (nuzzlerHealth <= 0)
        {

            transform.Rotate(0, 0, 180);

            Destroy(gameObject);
        }
    }

    //when the nuzzler has been attacked, minus the damage from the nuzzlers health
    public void giveDamage(int damageToGive)
    {
        nuzzlerHealth -= damageToGive;
        //set hit to true so that the controller can change behavior of the nuzzler
        hit = true;
    }
}
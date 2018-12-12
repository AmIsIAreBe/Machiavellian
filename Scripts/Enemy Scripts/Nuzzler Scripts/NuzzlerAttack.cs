using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuzzlerAttack : MonoBehaviour
{
    //an integer that is used to determine the amount of damage the nuzzler will do to the player
    //damage is determined in the Inspector
    public int damagePlayer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerHealthManager>().giveDamageToPlayer(damagePlayer);
        }
    }
}


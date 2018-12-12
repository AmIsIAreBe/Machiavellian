using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPlayersHome : MonoBehaviour {

    public void OnTriggerEnter2D()
    {
        if (Input.GetButtonDown("Submit"))
        {
           SceneManager.LoadScene("CutToTheChase");
            Debug.Log("Should be loading level 2");
        }
    }

    public void OnTriggerStay2D()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("CutToTheChase");
            Debug.Log("Should be loading level 2");
        }
    }
}

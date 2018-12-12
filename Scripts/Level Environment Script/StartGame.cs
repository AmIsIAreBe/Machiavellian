using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGameOnClick()
    {
        SceneManager.LoadScene("LoadingScene");
        Time.timeScale = 1f;
    }
}

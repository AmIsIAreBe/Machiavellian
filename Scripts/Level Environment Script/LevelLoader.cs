using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    bool runOnce = false;

    void Update()
    {
        if (runOnce == false)
        {
            LevelLoad();
            runOnce = true;
        }
    }

    public void LevelLoad()
    {
        Debug.Log("Started...");
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        Debug.Log("Running coroutine");
        AsyncOperation operation = SceneManager.LoadSceneAsync("Intro");
        Debug.Log("Loading Intro in the background");
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            Debug.Log("started while loop");
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
        Debug.Log("done");
    }
}
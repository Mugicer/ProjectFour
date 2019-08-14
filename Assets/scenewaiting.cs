using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenewaiting : MonoBehaviour
{
    public Text title;
    public Text number;
    public Slider slider;
    public void LoadTheSence(GameObject sence) {
        StartCoroutine(LoadingSence(sence.name));
    }
    IEnumerator LoadingSence(string sencename) {
        AsyncOperation async = SceneManager.LoadSceneAsync(sencename);
        while (!async.isDone)
        {
            slider.value = async.progress;
            number.text = (async.progress * 100).ToString() + "%";
            yield return 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    private GM gm;
    public string sceneName;
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2DOutput>().gm;
    }
    public void tp() {
        gm.savescene();
        SceneManager.LoadScene(sceneName);
        //gm.LoadScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    static GM instance;
    public string LastSence;
    public GameObject canvas;
    public Player2DOutput player;
    public bool graphic1=false;
    public bool graphic2 = false;
    private GameObject bag;
    private GameObject missiondiary;
    public int MaxHP;
    public int MaxMP;
    public int nowHP;
    public int nowMP;
    private GameObject[][] npcmisson;
    void Awake()
    {
        //Debug.Log("03");
        if (instance == null)
        {
            //Debug.Log("04");
            instance = this;
            DontDestroyOnLoad(this);
            name = "最大的權限狗";
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("刪除場景" + sceneName + "的" + name);
            Destroy(gameObject);
        }
        //Debug.Log("06");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2DOutput>();
        canvas = GameObject.Find("Canvas");
    }
    public void savescene()
    {
        instance.bag = player.bag;
        instance.missiondiary = player.missiondiary;
        instance.MaxHP = player.GetComponent<PlayerHPMPbar>().MaxHP;
        instance.MaxMP = player.GetComponent<PlayerHPMPbar>().MaxMP;
        instance.nowHP = player.GetComponent<PlayerHPMPbar>().nowHP;
        instance.nowMP = player.GetComponent<PlayerHPMPbar>().nowMP;
        LastSence = SceneManager.GetActiveScene().name;
    }
    public void LoadScene() {
        player.bag = instance.bag;
        player.missiondiary =instance.missiondiary ;
        player.GetComponent<PlayerHPMPbar>().MaxHP = instance.MaxHP;
        player.GetComponent<PlayerHPMPbar>().MaxMP = instance.MaxMP;
        player.GetComponent<PlayerHPMPbar>().nowHP = instance.nowHP;
        player.GetComponent<PlayerHPMPbar>().nowMP = instance.nowMP;
        canvas = GameObject.Find("Canvas");

        foreach (
            teleport tp in 
            canvas.GetComponentsInChildren<teleport>())
        {
            //Debug.Log(tp);
            if (tp.sceneName ==LastSence)
            {
                player.transform.position = tp.transform.position;
                break;
            }
        }
    }
}

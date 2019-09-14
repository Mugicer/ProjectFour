using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pass_mission : MonoBehaviour
{
    public string btn_text;
    public string graghicscene;
    public GM gm;
    public PlayerBag bag;
    public Potions passport;
    private void Awake()
    {
        gm = GameObject.Find("GM").GetComponent<GM>();
    }
    private void Start()
    {
        bag = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerBag>();
    }
    public void trypass()
    {
        foreach (Potions obj in bag.bag)
        {
            if (obj==passport)//有
            {
                if (obj.count>0)//有超過一個
                {
                    gm.savescene();
                    SceneManager.LoadScene(graghicscene);
                }
            }
        }

    }

}

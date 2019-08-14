using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkM01 : MonoBehaviour
{
    public M01 m01;
    public PlayerBag playerBag;
    private void Start()
    {
        m01 = transform.GetComponent<M01>();
        playerBag =transform.parent.parent.GetComponentInChildren<PlayerBag>();
        for (int i = 0; i < m01.needs.Length; i++)
        {
            m01.needs[i].count = m01.needcount[i];
        }
        for (int i = 0; i < m01.reward.Length; i++)
        {
            m01.reward[i].count = m01.rewardcount[i];
        }
        
        InvokeRepeating("checkmission",0,1);
    }
    void Update()
    {
    }

    private bool checkmission()
    {
        if (m01.missionstate != 0)//任務進行中
        {
            bool[] enoughobj = new bool[m01.needs.Length];
            for (int i = 0; i < m01.needs.Length; i++)//任務需求物品
            {
                enoughobj[i] = haveobj(m01.needs[i]);
                if (enoughobj[i])
                {
                    Debug.Log("任務道具 " + m01.needs[i].ObjName + " 擁有");
                }
                else
                {
                    Debug.Log("任務道具 " + m01.needs[i].ObjName + " 不足");
                }

            }
            foreach (bool e in enoughobj)
            {
                if (!e)
                {
                    return false;
                }
            }
            m01.missionstate = 2;
            return true;
        }
        return false;
    }
    public void missioncomplete() {
        if (m01.missionstate == 2)//任務待完成
        {
            if (checkmission())
            {
                for (int i = 0; i < m01.needs.Length; i++)//任務需求物品
                {
                    Potions[] p = playerBag.GetComponentsInChildren<Potions>();
                    for (int j = 0; j < p.Length; j++)
                    {
                        if (p[j].ObjName == m01.needs[i].ObjName)
                        {
                            p[j].count -= m01.needcount[i];
                        }
                    }
                }
            }
            for (int i = 0; i < m01.reward.Length; i++)//任務給予物品
            {
                Potions[] p = playerBag.GetComponentsInChildren<Potions>();
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j].ObjName == m01.reward[i].ObjName )
                    {
                        p[i].count += m01.rewardcount[i];
                    }
                }


            }


        }


    }

    private bool haveobj(Potions potions) {
        for (int j = 0; j < playerBag.bag.Length; j++)
        {
            if (playerBag.bag[j].ObjName == potions.ObjName && playerBag.bag[j].count >= potions.count)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }
}

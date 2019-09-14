using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPbar : MonoBehaviour
{
    public Slider HP;
    public Text HPtext;
    public int MaxHP;
    public int nowHP;
    private void Start()
    {
        HP =GameObject.FindGameObjectWithTag("bosshp").GetComponent<Slider>();
        HP.maxValue = MaxHP;
    }
    public void setMaxHP(int a)
    {
        MaxHP = a;
        nowHP = a;
        HP.maxValue = MaxHP;
    }
    public void plusHP(int a)
    {
        nowHP += a;
        if (nowHP > MaxHP)
        {
            nowHP = MaxHP;
        }
        if (nowHP < 0)
        {
            nowHP = 0;
        }

    }
    private void Update()
    {
        HP.value = nowHP;
        HPtext.text = nowHP.ToString() + " / " + MaxHP.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPMPbar : MonoBehaviour
{
    public Slider HP;
    public Text HPtext;
    public Slider MP;
    public Text MPtext;
    public int MaxHP;
    public int nowHP;
    public int MaxMP;
    public int nowMP;
    private void Start()
    {
        HP.maxValue = MaxHP;
        MP.maxValue = MaxMP;
    }
    public void setMaxHP(int a){
        MaxHP = a;
        nowHP = a;
        HP.maxValue = MaxHP;
    }
    public void setMaxMP(int a) {
        MaxMP = a;
        nowMP = a;
        MP.maxValue = MaxMP;
    }
    public void plusHP(int a)
    {
        nowHP += a;
        if (nowHP > MaxHP)
        {
            nowHP = MaxHP;
        }
        if (nowHP<0)
        {
            nowHP = 0;
        }
        
    }
    public void plusMP(int a)
    {
        nowMP += a;
        if (nowMP > MaxMP)
        {
            nowMP = MaxMP;
        }
        if (nowMP < 0)
        {
            nowMP = 0;
        }
    }
    private void Update()
    {
        HP.value = nowHP ;
        HPtext.text = nowHP.ToString() + " / " + MaxHP.ToString();
        MP.value = nowMP ;
        MPtext.text = nowMP.ToString() + " / " + MaxMP.ToString();
    }
}

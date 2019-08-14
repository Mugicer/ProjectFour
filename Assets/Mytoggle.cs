using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mytoggle : MonoBehaviour
{
    public string words;
    public Text text;
    public bool ischeck;
    public Sprite unchecktog;
    public Sprite checktog;

    public void setbord() {
        text.text = words;
        if (ischeck)
        {
            GetComponent<Image>().sprite = checktog;
        }
        else
        {
            GetComponent<Image>().sprite = unchecktog;
        }
    }
}

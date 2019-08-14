using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkboard : MonoBehaviour
{
    public Text text;
    public void newtext(string str)
    {
        text.text = str;

    }
}

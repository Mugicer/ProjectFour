using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DInput : MonoBehaviour
{
    private Player2DOutput po;
    public Image image;
    private Quaternion quaternion;
    public string talk = "f";
    public string quest = "o";
    //public string Left;
    //public string Right;
    //public string Up;
    //public string Down;
    //public string Jump;
    public bool lastfaceright;
    [Header("ChangePicture")]
    public Sprite[] pics;
    public int num;
    public float rate;
    private void Awake()
    {
        image = GetComponentInChildren<Image>();
        po = GetComponent<Player2DOutput>();
        quaternion = transform.rotation;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground") 
        {
            po.onground = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground") 
        {
            po.onground = false;
        }
    }
    private void Start()
    {
        repeatcall();
        
    }
    public void repeatcall() {
        InvokeRepeating("idlenum", 0,rate);
        //Debug.Log("Call");
    }//呼叫idlenum
    public void stopcall() {
        CancelInvoke("idlenum");
        //Debug.Log("stop");
    }//停止呼叫idlenum
    public void changepicstate(Sprite[] newpic) {
        pics = newpic;
        num = 0;
    }
    public void chagepicrate(float newrate) {
        rate = newrate;
    }
    private void idlenum()
    {
        //Debug.Log("idlenum");
        num++;
        if (num >= pics.Length)
        {
            num = 0;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!lastfaceright)
            {
                lastfaceright = true;
                image.transform.Rotate(0,180,0);
            }
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (lastfaceright)
            {
                lastfaceright = false;
                image.transform.Rotate(0, -180, 0);
            }
        }
        image.sprite = pics[num];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotateshoot : MonoBehaviour
{
    public float stick_rotatespace;
    public float stick_rotatespeed;
    public float stick_movespeed;
    public float bullet_movespeed;
    public int bullet_dmg;
    public float bullet_lifetime;
    public GameObject bullet;
    private void Start()
    {
        //InvokeRepeating("rotateself", 0, stick_rotatespace);
    }
    public void stickrotate() {
        InvokeRepeating("rotateself", 0, stick_rotatespace);
    }
    public void stickstoprotate() {
        CancelInvoke("rotateself");
    }
    private void FixedUpdate()
    {
        transform.Rotate(0,0, stick_rotatespeed);
    }
    void rotateself() {
        transform.Rotate(0,0,45);
        GameObject a = Instantiate(bullet,transform);
        a.AddComponent<BulletAttack>().SetParem(bullet_movespeed, bullet_dmg,bullet_lifetime);
        a.transform.SetParent(transform.parent);
    }
}

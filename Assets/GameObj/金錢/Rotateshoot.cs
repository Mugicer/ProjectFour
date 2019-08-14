using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateshoot : MonoBehaviour
{
    public float rotate_time;
    public GameObject bullet;
    private void Start()
    {
        InvokeRepeating("rotateself",0,rotate_time);
    }
    void rotateself() {
        transform.Rotate(0,0,45);
        GameObject a = Instantiate(bullet,transform);
        a.AddComponent<BulletAttack>().SetParem(10);
        a.transform.parent = transform.parent;
    }
}

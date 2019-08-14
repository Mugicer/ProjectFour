using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public float movespeed;
    public void SetParem(float speed) {
        movespeed = speed;
    }
    private void FixedUpdate()
    {
        transform.Translate(movespeed, 0,0);   
    }
}

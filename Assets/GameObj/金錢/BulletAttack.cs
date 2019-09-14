using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public float movespeed;
    public int dmg;
    public void SetParem(float speed,int dmg,float lifetime) {
        movespeed = speed;
        this.dmg = dmg;
        Destroy(gameObject, lifetime);
    }
    private void FixedUpdate()
    {
        transform.Translate(movespeed, 0,0);   
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.SendMessage("plusHP",dmg,SendMessageOptions.DontRequireReceiver);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    Animator anim;
    GameObject player;
    public float distance;
    public Transform up;
    public Transform down;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position,transform.position);
        setanim();
    }

    private void setanim()
    {
        anim.SetFloat("player_range",distance);

    }
}

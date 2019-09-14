using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyboom : MonoBehaviour
{
    public int dmg;
    public float count;
    public float Maxtime;
    public float Mintime;
     Text text;
    Collider2D col2;
    Rigidbody2D rb2;

    Moneyboom(float Min,float Max)
    {
        Maxtime = Max;
        Mintime = Min;

    }
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        col2 = GetComponent<Collider2D>();
        rb2 = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        count = Random.Range(Mintime,Maxtime);
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (count/1).ToString();

    }
    private void FixedUpdate()
    {
        count = count - Time.deltaTime;
        if (count<=0)
        {
            boom();
        }
    }
    public void boom() {
        //Debug.Log("爆炸");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter" + collision);
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("plusHP", dmg);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("stay" + collision);
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("plusHP", dmg);
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("plusHP", dmg);
            Destroy(gameObject);
        }
        else
        {
            rb2.bodyType=RigidbodyType2D.Kinematic;
            col2.isTrigger = true;
        }

    }
}

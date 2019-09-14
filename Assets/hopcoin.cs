using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hopcoin : MonoBehaviour
{
    public int dmg;
    public float count;
    //public float minpow;
    //public float maxpow;
    Collider2D col2;
    Rigidbody2D rb2;
    // Start is called before the first frame update
    private void Awake()
    {
        col2 = GetComponent<Collider2D>();
        rb2 = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * Random.Range(minpow,maxpow);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        count = count - Time.deltaTime;
        if (count <= 0)
        {
            boom();
        }
    }
    public void boom()
    {
        Debug.Log("爆炸");
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("plusHP", dmg);
            Destroy(gameObject);
        }
    }
    
}

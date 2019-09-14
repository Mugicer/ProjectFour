using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public GameObject left;
    public GameObject right;
    public float distance;
    public bool faceright =true;
    RaycastHit2D rightray;
    RaycastHit2D leftray;
    Rigidbody2D rb;
    LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.GetMask("Player");
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        rightray = Physics2D.Linecast(rb.position, rb.position + new Vector2(distance, 0), playerLayer);
        leftray = Physics2D.Linecast(rb.position, rb.position + new Vector2(distance * (-1) , 0), playerLayer);
        Debug.Log("右碰撞"+ rightray.transform);
        Debug.Log("左碰撞" + leftray.transform);
        if (rightray.collider ==null && leftray.collider == null)
        {
            if (faceright)
            {
                moveR();
                Debug.Log("無目標向右");
            }
            else
            {
                moveL();
                Debug.Log("無目標向左");
            }
            
        }
        else
        {
            if (rightray.collider!=null)
            {
                faceright = true;
                moveR();
                Debug.Log("有目標向右");
            }
            if (leftray.collider != null)
            {
                faceright = false;
                moveL();
                Debug.Log("有目標向左");
            }
        }
        if (transform.position.x>right.transform.position.x)
        {
            faceright = false;
        }
        if (transform.position.x < left.transform.position.x)
        {
            faceright = true;
        }
    }
    public void dmg(int dmg) {
        HP = HP - dmg;
        if (HP<=0)
        {
            HP = 0;
            dead();
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hitplayer");
        }
    }
    void moveR() {
        rb.position = rb.position + new Vector2(distance / 100, 0);
    }
    void moveL() {
        rb.position = rb.position + new Vector2(-distance / 100, 0);
    }
    void dead() {
        gameObject.SetActive(false);
    }
}

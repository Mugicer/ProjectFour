using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneybullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("子彈碰到玩家");
            Destroy(gameObject);
        }
        
    }
}

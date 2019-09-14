using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack_sword : MonoBehaviour
{
    public Stack<GameObject> obj = new Stack<GameObject>();
    public void appear() {
        gameObject.SetActive(true);
        Debug.Log("出現");
        obj.Clear();
    }
    public void disappear() {
        gameObject.SetActive(false);
        obj.Clear();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !obj.Contains(collision.gameObject) )
        {
            collision.gameObject.SendMessage("dmg",100,SendMessageOptions.DontRequireReceiver);
            Debug.Log("傷害"+ collision);
            obj.Push(collision.gameObject);
        }        
    }
}

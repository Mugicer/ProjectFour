using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Vector3 mouse;
    public Stack<Vector3> road = new Stack<Vector3>();
    public GameObject now;
    public GameObject back;

    Ray screenpoint;
    RaycastHit hit;
    void Start()
    {

    }

    void Update()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit);//取滑鼠位置的射線
        if (Input.GetKey(KeyCode.Mouse0)) {//按下滑鼠
             if (hit.collider.tag=="Points")//如果按到點上
            {
                if (hit.collider==back)//如果點是上一個
                {
                    road.Pop();//退一步

                }
                if (hit.collider!=now)//如果點不是現在這個
                {
                    road.Push(hit.collider.transform.position);
                }
                
            }


        }
    }
    
}

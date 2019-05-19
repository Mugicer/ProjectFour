using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class node : MonoBehaviour
{
    Color startcolor = new Color();
    Color passcolor = new Color();
    Color unpasscolor = new Color();
    Image image;
    public Graph graph;
    public int number;
    public GameObject Lineobj;
    public bool ispass=false;
    private void Start()
    {
        image = transform.GetComponent<Image>();
        graph = transform.GetComponentInParent<Graph>();
        passcolor = image.color;
        unpasscolor = image.color;
        startcolor = image.color;
        passcolor = Color.blue;
        unpasscolor = Color.white;
        startcolor = Color.red;

    }
    public void trypoint() {
        transform.SendMessageUpwards("pointnext", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
    public void addLine(node b) {
        LineRenderer gameObject=Instantiate(Lineobj,transform).GetComponent<LineRenderer>();
        gameObject.SetPosition(0, transform.position + new Vector3(0,0,1));
        gameObject.SetPosition(1, b.transform.position + new Vector3(0, 0, 1));
    }
    public void setnumber(int a) {
        number = a;
    }
    public void setbtnpass()
    {
        image.color = passcolor;
    }
    public void setbtnunpass()
    {
        image.color = unpasscolor;
    }
    public void setbtnstart() {
        image.color = startcolor;
    }

}

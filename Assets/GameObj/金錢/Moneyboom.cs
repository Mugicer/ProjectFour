using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneyboom : MonoBehaviour
{
    public float count;
    public float Maxtime;
    public float Mintime;
     Text text;
    Moneyboom(float Min,float Max)
    {
        Maxtime = Max;
        Mintime = Min;

    }
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
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
        Debug.Log("爆炸");
        Destroy(gameObject);
    }
}

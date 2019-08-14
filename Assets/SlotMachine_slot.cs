using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine_slot : MonoBehaviour
{
    private RectTransform image;
    public float[] slotposition;
    public bool start;
    public int num;
    public int rollmode=0;

    public float rollspeed;
    public float speeddown;
    public float rollspeed_low;
    private float rollingspeed;
    
    public float stop_lerp;
    public float stoprange;

    public float keepsec;
    public float slowstopsec;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetComponent<RectTransform>();
        rollingspeed = rollspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            switch (rollmode)
            {
                case 0:
                    break;
                case 1:
                    image.pivot =new Vector2(image.pivot.x, image.pivot.y + rollingspeed);
                    
                    break;
                case 2:
                    if (rollingspeed>rollspeed_low)
                    {
                        rollingspeed = rollingspeed - speeddown;
                        image.pivot = new Vector2(image.pivot.x, image.pivot.y + rollingspeed);
                    }
                    else
                    {
                        rollingspeed = rollspeed_low;
                        if (slotposition[num-1]<image.pivot.y && image.pivot.y<slotposition[num])
                        {
                            float a = Mathf.Lerp(image.pivot.y, slotposition[num],stop_lerp);
                            image.pivot = new Vector2(image.pivot.x,a);
                            if (a<stoprange)
                            {
                                image.pivot = new Vector2(image.pivot.x, slotposition[num]);
                                switchplus();
                            }
                        }
                    }
                    break;
                case 3://重設
                    rollingspeed = rollspeed;
                    rollmode = 0;
                    start = false;
                    break;
            }
        }
        if (image.pivot.y > slotposition[slotposition.Length])
        {
            image.pivot = new Vector2(image.pivot.x, slotposition[0]);
        }
    }
    public void startroll(int a) {
        start = true;
        num = a;
        Invoke("switchplus", 0);//會變成1  此時持續轉動
        Invoke("switchplus", keepsec);//會變成2 此時持續減速

        //Invoke("switchplus", keepsec+slowstopsec);//會變成3 
    }
    public void switchplus() {
        rollmode++;
    }
}

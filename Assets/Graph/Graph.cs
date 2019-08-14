using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour//此為圖形表格 不主動執行任何事物
{
    public GameObject newnode;
    public Text prompt;//這個需要手動放置Text
    public int nodelength = 2;
    public RectTransform[] nodes;
    public GameObject startpoint;
    public RectTransform endpoint;
    

    public int[][] thelink;
    public Vector3[] V3;
    public Stack<GameObject> walkover = new Stack<GameObject>();
    private LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetButtonDown("walkback"))
        {
            walkback();
        }
    }

    public void setnodes()//賦予長度 創造點
    {
        nodes = new RectTransform[nodelength];
        V3 = new Vector3[nodelength];
        lineRenderer.positionCount = nodelength+1;
        for (int i = 0; i < nodelength; i++)//創造點
        {
            GameObject a = Instantiate(newnode, transform);
            nodes[i] = a.GetComponent<RectTransform>();//紀錄點
        }
    }

    public void setposition()//設置點單次
    {
        for (int i = 0; i < nodelength; i++)
        {
            nodes[i].transform.position=V3[i];
            nodes[i].SendMessage("setnumber", i);
        }
    }
    public void SetTheLinkMax(int a) {//設置長度 單次
        thelink = new int[a][];
    }
    public void SetTheLink(int a,int[] ary)//設置長度 單次
    {
        thelink[a] = ary;
    }
    public void setgraphlist()//圖型
    {
        //thelink = GraphData.Linkdata;
        //Debug.Log(thelink);
        //Debug.Log(GraphData.a);
        //Debug.Log(GraphData.Linkdata);
        Debug.Log(thelink.GetUpperBound(0) + 1);
        for (int i = 0; i <= thelink.GetUpperBound(0); i++)
        {
            Debug.Log("j" + thelink[i].Length);
            for (int j = 0; j < thelink[i].Length; j++)
            {
                nodes[i].SendMessage("addLine", nodes[thelink[i][j]].transform.GetComponent<node>());
            }
        }

    }
    public void walkback()//返回 
    {
        if (walkover.Count != 0)
        {
            GameObject a = walkover.Pop();
            a.SendMessage("setbtnunpass", SendMessageOptions.DontRequireReceiver);
            prompt.text = "你返回上一步";
            clearprompt();
            WrightLine0();
        }

    }
    public void pointnext(GameObject Thenode)//點向圖形呼叫
    {
        //print(Thenode);

        if (walkover.Count != 0)
        {
            if (walkover.Peek() == Thenode)//是
            {
                walkover.Pop();
                Thenode.SendMessage("setbtnunpass", SendMessageOptions.DontRequireReceiver);
                prompt.text = "你返回上一步";
                clearprompt();
                WrightLine0();
                return;
            }

        }
        else {
            walkover.Push(Thenode);
            Thenode.SendMessage("setbtnstart", SendMessageOptions.DontRequireReceiver);
            startpoint = Thenode;
            prompt.text = "紅色是你的起點";
            clearprompt();
            WrightLine0();
            return;
        }
        if (walkover.Count==nodelength)
        {
            if (startpoint==Thenode)
            {
                walkover.Push(Thenode);
                prompt.text = "你走到終點了";
                clearprompt();
                transform.SendMessage("opentrature", SendMessageOptions.DontRequireReceiver);
                WrightLine0();
                return;
            }
        }
        if (walkover.Contains(Thenode))
        {
            if (startpoint == Thenode&& walkover.Count != nodelength)
            {
                prompt.text = "你需要走完白點才能回到終點";
                clearprompt();
                return;
            }
            prompt.text = "這個點已經走過不能再走了";
            clearprompt();
            WrightLine0();
            return;
        }//是否走過
        else
        {
            int peeknum = walkover.Peek().GetComponent<node>().number;
            int nodenum = Thenode.GetComponent<node>().number;
            Debug.Log(peeknum);
            Debug.Log(thelink);
            for (int i = 0; i < thelink[peeknum].Length; i++)
            {
                if (thelink[peeknum][i]==nodenum)
                {
                    walkover.Push(Thenode);
                    Thenode.SendMessage("setbtnpass", SendMessageOptions.DontRequireReceiver);
                    print("沒走過");
                    WrightLine0();
                    return;
                }
            }
            prompt.text = "這不是鄰近的點，不能走";
            clearprompt();
            return;
        }
    }

    private void WrightLine0()//畫線
    {
        GameObject[] tempstack = new GameObject[walkover.Count];
        walkover.CopyTo(tempstack, 0);
        if (walkover.Count != 0)
        {
            for (int i = 0; i <= nodes.Length; i++)
            {
                if (i >= tempstack.Length)
                {
                    WriteLine(i, tempstack[tempstack.Length - 1].transform.position);
                }
                else
                {
                    WriteLine(i, tempstack[i].transform.position);
                }
            }
        }
        else
        {
            for (int i = 0; i <= nodes.Length; i++)
            {
                WriteLine(i, new Vector3(0,0,0));
            }
        }
    }

    private void WriteLine(int a,Vector3 point)//畫線
    {
        lineRenderer.SetPosition(a, point);                           
    }

    private void clearprompt() {
        if (IsInvoking("_clearprompt"))
        {
            CancelInvoke("_clearprompt");
        }
        Invoke("_clearprompt", 3);
    }
    private void _clearprompt() {
        prompt.text = "";
    }
    

}

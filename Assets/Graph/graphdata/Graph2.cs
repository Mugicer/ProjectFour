using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph2 : MonoBehaviour
{
    public GameObject trature;
    public int[][] Linkdata;
    public Graph graph;
    private void Awake()
    {
        graph = GetComponent<Graph>();
        int[][] Linkdata =
                {
                    new [] {1,2,3 },
                    new [] {0,4,5 },//1
                    new [] {0,4,8 },
                    new [] {0,5,13 },//3
                    new [] {1,2,6 },
                    new [] {1,3,7 },//5
                    new [] {4,7,10 },
                    new [] {5,6,11 },//7
                    new [] {2,9,20 },
                    new [] {8,10,16 },//9
                    new [] {6,9,14 },  
                    new [] {7,12,15 },//11
                    new [] {11,13,19 },  
                    new [] {3,12,23 },//13
                    new [] {10,15,17 },  
                    new [] {11,14,18 },//15
                    new [] {9,17,20 },  
                    new [] {14,16,21 },//17
                    new [] {15,19,22 },  
                    new [] {12,18,23 },//19
                    new [] {8,16,21 },  
                    new [] {17,20,22 },//21
                    new [] {18,21,23 },  
                    new [] {13,19,22 },//23
                };
        graph.SetTheLinkMax(Linkdata.GetUpperBound(0) + 1);
        graph.thelink = Linkdata;
        //Debug.Log(Linkdata);
        //Debug.Log("graph1 有幾個陣列 "+Linkdata.GetUpperBound(0));
        //Debug.Log("graph1 第一個陣列有幾個 " + Linkdata[0].Length);
        //Debug.Log("graph1 第一個陣列的第2個 " + Linkdata[0][1]);

    }
    private void Start()
    {
        //Debug.Log("Linkdata放入thelink");
        //SetTheLink();
        //Debug.Log("graph1 有幾個陣列" + graph.thelink.GetUpperBound(0));
        //Debug.Log("graph1 第一個陣列有幾個" + graph.thelink[0].Length);
        //Debug.Log("graph1 第一個陣列的第2個" + graph.thelink[0][1]);

    }

    private void SetTheLink()
    {
        //Debug.Log(graph);
        //Debug.Log(Linkdata);
        //Debug.Log(Linkdata.GetUpperBound(0) + 1);
        graph.SetTheLinkMax(Linkdata.GetUpperBound(0));
        for (int i = 0; i < Linkdata.GetUpperBound(0); i++)
        {

            int[] a = new int[Linkdata[i].Length];
            a = Linkdata[i];
            graph.SetTheLink(i, a);
            //Debug.Log(graph.thelink[i]);
        }
    }
    public void opentrature()
    {
        trature.active = true;
    }


    

}

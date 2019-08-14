using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Graph1 : MonoBehaviour
{
    public GameObject trature;
    public int[][] Linkdata;
    public Graph graph;
    private void Awake()
    {
        graph = GetComponent<Graph>();
        int[][] Linkdata =
                {
                    new [] {1,4,7 },
                    new [] {2,5,0 },//2
                    new [] {3,6,1 },
                    new [] {4,7,2 },//4
                    new [] {5,0,3 },
                    new [] {6,1,4 },//6
                    new [] {7,2,5 },
                    new [] {0,3,6 },//8
                };
        graph.SetTheLinkMax(Linkdata.GetUpperBound(0) + 1);
        graph.thelink= Linkdata;
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
            
            int[] a=new int[Linkdata[i].Length];
            a = Linkdata[i];
            graph.SetTheLink(i, a);
            //Debug.Log(graph.thelink[i]);
        }
    }
    public void opentrature() {
        trature.active=true;
        GM gm;
        gm = FindObjectOfType<GM>();
        gm.graphic1=true;
        backtoworld(gm.LastSence);
    }
    private void backtoworld(string str ) {
        SceneManager.LoadScene(str);
    }
}

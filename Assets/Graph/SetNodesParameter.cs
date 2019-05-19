using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNodesParameter : MonoBehaviour
{
    public Graph graph;
    public Vector3[] V3;
    // Start is called before the first frame update
    private void Awake()
    {
        graph = GetComponent<Graph>();
    }
    void Start()
    {
        
    }
    
    public void setV3() {
        graph.nodelength =V3.Length;//導入長度
        graph.setnodes();//創造點
        graph.V3 = V3;//
        graph.setposition();
        graph.setgraphlist();
        //graph.startpoint = graph.nodes[0];
        //graph.endpoint = graph.nodes[graph.nodelength - 1];
    }

    
}

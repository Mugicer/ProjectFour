using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph3 : MonoBehaviour
{
    public GameObject trature;
    public int[][] Linkdata;
    public Graph graph;
    private void Awake()
    {
        graph = GetComponent<Graph>();
        int[][] Linkdata =
                {
                    new [] {100,102,103 },
                    new [] {2,5,6    },//1
                    new [] {1,3,8    },
                    new [] {2,4,10   },//3
                    new [] {3,12,14  },
                    new [] {1,6,15   },//5
                    new [] {1,5,7    },
                    new [] {6,8,16   },//7
                    new [] {2 ,7 ,9  },
                    new [] {8 ,10,18 },//9
                    new [] {3 ,9 ,11 },  
                    new [] {10,12,20 },//11
                    new [] {4 ,11,13 },  
                    new [] {12,14,22 },//13
                    new [] {4 ,13 ,24  },  
                    new [] {5 ,16 ,25  },//15
                    new [] {15 ,17 ,7  },  
                    new [] {16 ,18 ,26  },//17
                    new [] {17 ,19 ,9  },  
                    new [] {18 ,20 ,28  },//19
                    new [] {19 ,21 ,22  },  
                    new [] {20 ,22 ,30  },//21
                    new [] {21 ,23 ,13  },
                    new [] {22 ,24 ,32  },//23
                    new [] {14 ,23 ,34  },
                    new [] {15 ,26 ,35  },//25
                    new [] {25 ,27 ,17  },
                    new [] {26 ,28 ,36  },//27
                    new [] {27 ,29 ,19  },
                    new [] {28 ,30 ,38  },//29
                    new [] {29 ,31 ,21  },
                    new [] {30,32,40},//31
                    new [] {31,33,23},
                    new [] {32,34,42},//33
                    new [] {33,24,44},
                    new [] {25,36,45},//35
                    new [] {35,37,27},
                    new [] {36,38,46},//37
                    new [] {37,39,29},
                    new [] {38,40,48},//39
                    new [] {39,41,31},
                    new [] {40,42,50},//41
                    new [] {41,43,33},
                    new [] {42,44,52},//43
                    new [] {43,34,53},
                    new [] {35,46,57},//45
                    new [] {45,47,37},
                    new [] {46,48,59},//47
                    new [] {47,49,39},
                    new [] {48,50,54},//49
                    new [] {49,51,50},
                    new [] {50,52,55},//51
                    new [] {51,53,43},
                    new [] {52,44,55},//53
                    new [] {49,55,56},
                    new [] {51,53,54},//55
                    new [] {54,61,63},
                    new [] {45,58,64},//57
                    new [] {57,59,65},
                    new [] {58,60,47},//59
                    new [] {59,61,67},
                    new [] {60,62,56},//61
                    new [] {61,63,69},
                    new [] {62,56,71},//63
                    new [] {65,57,72},
                    new [] {64,66,58},//65
                    new [] {65,67,74},
                    new [] {66,68,60},//67
                    new [] {67,69,76},
                    new [] {68,70,62},//69
                    new [] {69,71,78},
                    new [] {70,63,79},//71
                    new [] {73,57,80},
                    new [] {72,74,81},//73
                    new [] {73,75,66},
                    new [] {74,76,83},//75
                    new [] {75,77,68},
                    new [] {76,78,85},//77
                    new [] {77,79,70},
                    new [] {78,71,87},//79
                    new [] {81,72,88},
                    new [] {80,82,73},//81
                    new [] {81,83,90},
                    new [] {82,84,75},//83
                    new [] {83,85,92},
                    new [] {84,86,77},//85
                    new [] {85,87,94},
                    new [] {86,79,95},//87
                    new [] {89,80,96},
                    new [] {88,90,97},//89
                    new [] {89,91,82},
                    new [] {90,92,99},//91
                    new [] {91,93,84},
                    new [] {92,94,101},//93
                    new [] {93,95,86},
                    new [] {94,87,102},//95
                    new [] {97,88,103},
                    new [] {96,98,89},//97
                    new [] {97,99,103},
                    new [] {98,100,91},//99
                    new [] {99,101,0},
                    new [] {100,102,93},//101
                    new [] {101,95,0},
                    new [] {96,98,0},//103
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinner : MonoBehaviour
{
    public bool[][] adj = new bool[4][]; // 無向圖，adjacency matrix。
    public int[] visit = new int[4];    // 記錄每一點的DFS遍歷時刻，以判斷祖先與子孫。
    public int[] low = new int[4];         // 記錄自身與子孫們
                                   // 用back edge連到的最高祖先（的遍歷時刻）。
                                   // 由於遍歷時刻要盡量小，故大家習慣取名為low。
    public int t = 0;
    private void Start()
    {
        setadj();
        articulation_vertex();
        
    }
    void setadj() {
        adj[0] = new bool[] { false, true , false, true };
        adj[1] = new bool[] { true , false, true , true  };
        adj[2] = new bool[] { false, true , false, false };
        adj[3] = new bool[] { true , true , false, false };
    }
    void articulation_vertex()
    {
        // DFS forest
        for (int i = 0; i < visit.Length; ++i)
            visit[i] = 0;

        t = 0;

        for (int i = 0; i < visit.Length; ++i)
            if (visit[i] == 0)
                DFS(0, 0);
    }
    void DFS(int p, int i)//從P到I點
    {
        visit[i] = low[i] = ++t;//第 i 號點在 t+1 時搜尋過  low代表在所有次搜尋中，最快搜到的搜尋

        int child = 0;//紀錄有幾個子點

        for (int j = 0; j < 4; ++j)
            if (adj[i][j] && j != p)//嘗試要搜尋的點是否有連到其他位置，且不是連到自己
                if (visit[j]!=0)   // 第 j 號點已經走過
                {
                    
                    low[i] = min(low[i], visit[j]);//確認起點最高祖先為最小

                }
                else            // 第 j 號點尚未走過 
                {
                    child++;
                    DFS(i, j);//從 i 號點到 j 號點

                    low[i] = min(low[i], low[j]);//確認起點最高祖先為最小
                }
    }
    private int min(int a, int b) {
        if (a >= b)
        {
            return b;
        }
        else {
            return a;
        }


    }
    
}

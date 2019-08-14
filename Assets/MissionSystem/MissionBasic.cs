using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBasic : MonoBehaviour
{
    public int Missionnumber;
    public string title;
    public string Npc;
    [TextArea]
    public string descript;
    public string[] ask;
    public Potions[] reward;
    public int[] rewardcount;
    public Potions[] needs;
    public int[] needcount;
    public int missionstate =0;
    void sendup() {
        
    }

}

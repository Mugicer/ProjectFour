using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M01 : MissionBasic
{
    protected M01() {
        base.Missionnumber = Missionnumber;
        base.title = title;
        base.Npc = Npc;
        base.descript = descript;
        base.ask = ask;
        base.reward = reward;
        base.rewardcount = rewardcount;
        base.needs = needs;

        base.needcount = needcount;
        base.missionstate = missionstate;
    }
}

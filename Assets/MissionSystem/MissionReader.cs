using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionReader : MonoBehaviour
{
    [Space(10)]
    public MissionBasic mission;
    [Space(10)]
    public Text title;
    public Text Npc;
    public Text descript;
    public Transform askplace;
    public Transform rewardplace;
    private Potions[] reward;
    private string[] asks;
    private Stack<GameObject> things = new Stack<GameObject>();//存放該任務的獎勵&要求文字
    public List<MissionBasic> Allmissions = new List<MissionBasic>();//所有接取的任務;
    public Button completebutton;
    [Space(10)]
    public GameObject askslot;
    public GameObject rewardslot;
    void Start()
    {
        Loadit();

    }
    public void Loadmission(MissionBasic themission) {
        mission = themission;
        Debug.Log(mission.missionstate);
        switch (mission.missionstate)
        {
            case 0:
                completebutton.transform.GetComponentInChildren<Text>().text = "接取";
                completebutton.interactable = true;
                break;
            case 1:
                completebutton.transform.GetComponentInChildren<Text>().text = "進行中";
                completebutton.interactable = false;
                break;
            case 2:
                completebutton.transform.GetComponentInChildren<Text>().text = "交付";
                completebutton.interactable = true;
                break;
        }
        Loadit();
        gameObject.SetActive(true);
    }
    void Loadit() {
        if (things.Count!=0)
        {
            foreach (GameObject t in things) {
                Destroy(t);
            }
            Debug.Log(things.Count);
            things.Clear();
        }
        
        title.text = mission.title;
        Npc.text = "委託人 : "+mission.Npc;
        descript.text = mission.descript;
        asks = mission.ask;
        for (int i = 0; i < asks.Length; i++)
        {
            GameObject obj = Instantiate(askslot, askplace);
            obj.GetComponentInChildren<Text>().text = asks[i];
            things.Push(obj);
        }
        reward = mission.reward;
        for (int i = 0; i < reward.Length; i++)
        {
            GameObject obj = Instantiate(rewardslot, rewardplace);
            obj.GetComponent<Image>().sprite = reward[i].image;
            obj.GetComponentInChildren<Text>().text ="x" + mission.reward[i].count;
            things.Push(obj);
        }
    }
    public void InvisiableReader() {
        gameObject.SetActive(false);
    }
    public void completebtn() {
        InvisiableReader();
        switch (mission.missionstate)
        {
            case 0:

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Debug.Log(player);
                //int length =player.GetComponent<NPC>().missions.Length;
                //for (int i = 0; i < length; i++)
                //{
                //    if (player.GetComponent<NPC>().missions[i] != null)
                //    {
                //        continue;
                //    }
                //    else
                //    {
                //        player.GetComponent<NPC>().missions[i] = mission;
                //        break;
                //    }
                //}
                mission.transform.parent = player.transform.Find("missiondiary");
                mission.missionstate++;
                //s.GetComponent<M01>().needs
                Debug.Log("接取了任務，這裡要增加一行任務轉至玩家身上的動作");
                break;
            case 2:
                Debug.Log("完成任務");
                GameObject ga = GameObject.FindGameObjectWithTag("Player").transform.Find("missiondiary").Find(mission.name).gameObject;
                Debug.Log(mission.name);
                Debug.Log(ga);
                ga.SendMessage("missioncomplete",SendMessageOptions.DontRequireReceiver);
                Destroy(ga);
                break;
            default:
                break;
        }
    }

}

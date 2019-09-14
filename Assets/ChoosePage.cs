using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePage : MonoBehaviour
{
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    MissionReader missionReader;
    public NPC NPC;

    public List<GameObject> btns = new List<GameObject>();
    public void ChangeNpcName(NPC npc) {
        Deletbtn();
        NPC = npc;
        text.text = npc.name;
        Addbtn();
        
        
        //Debug.Log("NPC : "+NPC);
        //Debug.Log("text : " + text.text);
    }
    public void CloseChoosePage()
    {
        gameObject.SetActive(false);
    }
    public void OpenChoosePage() {
        gameObject.SetActive(true);
    }
    public void Addbtn() {
        foreach (MissionBasic miss in NPC.transform.GetComponentsInChildren<M01>())
        {
            GameObject b = Instantiate(btn, content.transform);
            btns.Add(b);
            b.GetComponentInChildren<Text>().text = miss.title;
            b.GetComponent<Button>().onClick.AddListener(delegate
                {
                    missionReader.Loadmission(miss);
                    CloseChoosePage();
                }
            );
            Debug.Log(miss.name + " " +miss.missionstate);

        }
        foreach (graphic_mission item in NPC.transform.GetComponentsInChildren<graphic_mission>())
        {
            GameObject b = Instantiate(btn, content.transform);
            btns.Add(b);
            b.GetComponentInChildren<Text>().text = item.btn_text;
            b.GetComponent<Button>().onClick.AddListener(delegate
            {
                item.OpenGraphic();
                CloseChoosePage();
            }
            );
        }
        foreach (pass_mission item in NPC.transform.GetComponentsInChildren<pass_mission>())
        {
            GameObject b = Instantiate(btn, content.transform);
            btns.Add(b);
            b.GetComponentInChildren<Text>().text = item.btn_text;
            b.GetComponent<Button>().onClick.AddListener(delegate
            {
                item.trypass();
                CloseChoosePage();
            }
            );
        }
    }
    public void Deletbtn() {
        foreach  (GameObject ga in btns)
        {
            Destroy(ga);
        }
        btns.Clear();
    }


}

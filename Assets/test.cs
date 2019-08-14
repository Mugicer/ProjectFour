using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject a;
    private void Start()
    {
       // a.GetComponent<Button>().onClick.AddListener(TaskOnClick);
       // a.GetComponent<Button>().onClick.AddListener(delegate { TaskOnClick(); });
        a.GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
    }
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
}

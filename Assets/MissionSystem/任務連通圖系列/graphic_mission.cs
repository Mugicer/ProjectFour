using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class graphic_mission : MonoBehaviour
{
    public string btn_text;
    public string graghicscene;
    public GM gm;
    private void Awake()
    {
        gm = GameObject.Find("GM").GetComponent<GM>();
    }
    public void OpenGraphic() {
        gm.savescene();
        SceneManager.LoadScene(graghicscene);
    }
}

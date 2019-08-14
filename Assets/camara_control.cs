using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_control : MonoBehaviour
{
    private RectTransform player;
    public Vector3 vec;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+vec;
    }
}

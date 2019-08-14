using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgraphic : MonoBehaviour
{
    private void Start()
    {
        GetComponentInParent<SetNodesParameter>().setV3();
        gameObject.SetActive(false);
    }
}

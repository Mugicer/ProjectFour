using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerattack : MonoBehaviour
{
    public GameObject bullet;
    private GameObject[] bullets;
    public int bulletcount = 10;
    [SerializeField]
    float radius;
    [SerializeField]
    float startangle = 0;
    
    float angle;
    // Start is called before the first frame update
    private void Awake()
    {
        bullets = new GameObject[bulletcount];
        for (int i = 0; i < bulletcount; i++)
        {
            bullets[i] = Instantiate(bullet, transform);
        }
    }
    void Start()
    {
        angle = 360f / bulletcount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        radius += Time.deltaTime;
        for (int i = 0; i < bulletcount; i++)
        {
            Vector2 v2 = transform.position;

            float x = v2.x + radius * Mathf.Cos((startangle + i * angle) * Mathf.PI / 180f);
            float y = v2.y + radius * Mathf.Sin((startangle + i * angle) * Mathf.PI / 180f);
            Debug.Log("角度 : " + startangle + i * angle + "\nx : " + x + "\ny : " + y);
            bullets[i].transform.position = new Vector3(x, y, bullets[i].transform.position.z);
        }

    }
}

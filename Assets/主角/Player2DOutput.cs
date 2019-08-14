using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2DOutput : MonoBehaviour
{
    private Player2DInput playerinput;
    private Animator anim;
    private BoxCollider2D head;
    Rigidbody2D rb;
    RaycastHit2D raycastHit2;
    Ray2D ray2;
    public GM gm;
    public GameObject canvas;
    public GameObject NormolTalk;
    public GameObject ImportentTalk;
    public GameObject ChooseReader;
    public GameObject MissionReader;

    public GameObject bag;
    public GameObject missiondiary;

    public bool UIusing =false;

    public float grounddistance;
    private LayerMask NpcLayer ;
    public LayerMask groundmask;
    public bool moveable =true;

    [Header("PlayerParemeter")]
    public float slidespeed;
    public float slidedistance;
    public float Movespeed;
    public float Jumppower;
    //[Header("Playerstate")]
    public bool onground;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("00");
        gm = GameObject.FindGameObjectWithTag("GameMagnager").GetComponent<GM>();
        canvas = GameObject.Find("canvas");
        playerinput = GetComponent<Player2DInput>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gm.canvas = canvas;
        gm.player = this;
    }
    private void Start()
    {
        gm.LoadScene();
        NpcLayer = LayerMask.GetMask("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        animparemater();
        lookaround();
        if (Input.GetKeyDown(playerinput.quest))
        {
            ChooseReader.GetComponent<ChoosePage>().ChangeNpcName(playerinput.transform.Find("missiondiary").GetComponentInChildren<NPC>());
            ChooseReader.SetActive(true);
            ImportentTalk.SetActive(false);
            NormolTalk.SetActive(false);
        }
        detectiveUI();
    }

    private void detectiveUI()
    {
        if (ChooseReader.activeSelf  ||  MissionReader.activeSelf  )
        {
            UIusing = true;
        }
        else
        {
            UIusing = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(playerinput.talk))
        {
            collision.GetComponent<teleport>().tp();
        }
    }
    public void lookaround() {
        int face = (playerinput.lastfaceright == true) ?   1 : -1;
        Debug.DrawRay(rb.position, new Vector2(100*face, 0), Color.red, 0);
        raycastHit2 = Physics2D.Linecast(rb.position,rb.position + new Vector2(100 * face, 0), NpcLayer);
        if (raycastHit2.collider!=null )
        {
            //Debug.Log("Look AT " + raycastHit2.collider);
            LookAt(raycastHit2.collider);
            if ( Input.GetKeyDown(playerinput.talk) )
            {
                Debug.Log("Talk To " + raycastHit2.collider);
                Debug.Log(raycastHit2.transform.GetComponent<NPC>().Name);
                Debug.Log(ChooseReader.GetComponent<ChoosePage>().NPC);
                if (raycastHit2.transform.GetComponent<NPC>()!= ChooseReader.GetComponent<ChoosePage>().NPC)
                {
                    ChooseReader.GetComponent<ChoosePage>().ChangeNpcName(raycastHit2.transform.GetComponent<NPC>());//呼叫方法 值為NPC的名字
                }
                ChooseReader.SetActive(true);
                ImportentTalk.SetActive(false);
            }
        }
        else
        {
            if (ChooseReader.activeSelf&&ChooseReader.GetComponent<ChoosePage>().NPC!= playerinput.transform.Find("missiondiary").GetComponentInChildren<NPC>())//不是玩家才關閉
            {
                ChooseReader.SetActive(false);
            }
            //if (MissionReader.activeSelf)
            //{
            //    MissionReader.SetActive(false);
            //}
            if (NormolTalk.activeSelf)
            {
                NormolTalk.SetActive(false);
            }
            if (ImportentTalk.activeSelf)
            {
                ImportentTalk.SetActive(false);
            }
        }
    }

    private void LookAt(Collider2D NPC)
    {
        
        if (NPC.GetComponentInChildren<MissionBasic>())
        {
            if (!ImportentTalk.activeSelf && !UIusing)
            {
                ImportentTalk.transform.position = NPC.transform.position;
                ImportentTalk.GetComponent<talkboard>().newtext(NPC.GetComponent<NPC>().impor);
                ImportentTalk.SetActive(true);
            }

        }
        else
        {
            if (!NormolTalk.activeSelf && !UIusing)
            {
                int a = UnityEngine.Random.Range(0, NPC.GetComponent<NPC>().nor.Length);
                Debug.Log(a);
                NormolTalk.transform.position = NPC.transform.position;
                NormolTalk.GetComponent<talkboard>().newtext(NPC.GetComponent<NPC>().nor[a]);
                NormolTalk.SetActive(true);
            }
            
        }
    }
    
    private void animparemater()
    {

        anim.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));//左右移動
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("vertical", Input.GetAxisRaw("Vertical"));//上下移動
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        anim.SetBool("slidepress", Input.GetButtonDown("slide"));
        anim.SetBool("slide", Input.GetButton("slide"));
        anim.SetFloat("slidespeed", slidespeed);
        anim.SetFloat("slidedistance", slidedistance);
        //Debug.DrawLine(rb.position, rb.position + new Vector2(0, grounddistance), Color.blue);
        //onground = Physics2D.Linecast(rb.position, rb.position + new Vector2(0, grounddistance),groundmask);
        anim.SetBool("Ground", onground);
        anim.SetFloat("rbforce", rb.velocity.y);
        anim.SetBool("jump", Input.GetButtonDown("Jump"));
        anim.SetFloat("jumppower", Jumppower);
        anim.SetBool("Movable", moveable);
        anim.SetFloat("speed", Movespeed);

    }//輸入按鍵時
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firstboss_creatbullet : StateMachineBehaviour
{
    public GameObject stickobj;
    GameObject stick;
    GameObject player;
    int stickmode =0;
    Vector2 targetposition;
    Vector2 targetway;

    float stay_time;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stickmode = 0;

        player = GameObject.FindGameObjectWithTag("Player");

        stick = Instantiate(stickobj,animator.transform);
        stick.transform.SetParent( animator.transform.parent);
        stick.transform.position = animator.transform.position;
            //創造拐杖

        if (player.transform.position.y > animator.GetComponent<Boss1>().down.position.y+20)//決定投擲位置
        {
            targetposition = animator.GetComponent<Boss1>().up.position;
        }
        else
        {
            targetposition = animator.GetComponent<Boss1>().down.position;
        }

        targetway = targetposition - (Vector2)stick.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (stickmode)
        {
            case 0:
                if (Vector3.Distance(stick.transform.position,targetposition)>50)
                {
                    stick.transform.position += (Vector3)targetway * Time.deltaTime;
                }
                else
                {
                    stickmode++;
                    stick.SendMessage("stickrotate",SendMessageOptions.DontRequireReceiver);
                    stay_time = 0;
                }
                
                
                break;
            case 1:
                stay_time = stay_time + Time.deltaTime;
                if (stay_time>3)//等時間
                {
                    stickmode++;
                    stick.SendMessage("stickstoprotate", SendMessageOptions.DontRequireReceiver);
                }
                break;
            case 2:
                if (Vector3.Distance(stick.transform.position, animator.transform.position) > 50)
                {
                    stick.transform.position -= (Vector3)targetway * Time.deltaTime;
                }
                else
                {
                    //reset
                    stickmode = 0;
                    stay_time = 0;
                    Destroy(stick);
                    animator.SetBool("throwstick_done", true);//quit
                }
                break;
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("throwstick_done", false);//quit
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

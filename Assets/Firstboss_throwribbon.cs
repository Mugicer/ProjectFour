using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firstboss_throwribbon : StateMachineBehaviour
{
    public GameObject invisiableball;
    public float max;
    LineRenderer ribbon;
    Transform ball;
    int ballmode;
    Vector2 target;
    Transform player;
    Vector2 way;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ribbon = animator.GetComponentInChildren<LineRenderer>();
        ball = Instantiate(invisiableball, animator.transform).GetComponent<Transform>();
        ball.SetParent(animator.transform.parent);
        ball.position = animator.transform.position;
        ballmode = 0;
        //target = (Vector2)player.position + new Vector2( Random.Range(-max,max) , Random.Range(-max, max/2) );
        //if (target.y<animator.transform.position.y)
        //{
        //    target.y = animator.transform.position.y;
        //}
        target = animator.transform.gameObject.GetComponent<Boss1>().down.position;
        way = target - (Vector2)ball.position;
        ribbon.SetPosition(0, animator.transform.position);
        ribbon.SetPosition(1, animator.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (ballmode)
        {
            case 0:
                if (Vector2.Distance(target,ball.position)>50)
                {
                    ball.position += (Vector3)way*Time.deltaTime;
                    if (Vector2.Distance(player.position, ball.position) < 100)
                    {
                        player.gameObject.SendMessage("Stunning", 1f, SendMessageOptions.DontRequireReceiver);//麻痺
                        animator.SetBool("ifcatch", true);
                    }
                }
                else
                {
                    ballmode++;
                }


                break;
            case 1:
                if (Vector2.Distance(animator.transform.position, ball.position) > 100)
                {
                    ball.position -= (Vector3)way * Time.deltaTime;
                    if (Vector2.Distance(player.position, ball.position) < 50&& animator.GetBool("ifcatch"))
                    {
                        player.position = ball.position;
                        player.gameObject.SendMessage("Stunning", 0.5f, SendMessageOptions.DontRequireReceiver);//麻痺
                    }
                }
                else
                {
                    animator.SetBool("ribbon_done", true);
                }
                break;
        }
        ribbon.SetPosition(0, (Vector3)ball.position);//畫繃帶
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ball.SendMessage("destoryself",SendMessageOptions.DontRequireReceiver);
        ballmode = 0;
        animator.SetBool("ifcatch", false);
        animator.SetBool("ribbon_done", false);
        ribbon.SetPosition(0, animator.transform.position);
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

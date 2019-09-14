using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_slide : StateMachineBehaviour
{
    private Vector2 po;
    Rigidbody2D rb;
    float slidespeed;
    float slidedistance;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float ho = animator.GetFloat("horizontal");
        slidespeed = animator.GetFloat("slidespeed");
        slidedistance = animator.GetFloat("slidedistance");
        //animator.transform.GetComponent<Image>().rectTransform.anchoredPosition +=new Vector2(ho*sp,0);
        //animator.transform.position += new Vector3(ho * sp, 0, 0);
        rb = animator.transform.GetComponent<Rigidbody2D>();
        po = rb.position+new Vector2(ho*slidedistance,0);
        //Debug.Log(animator.transform.position);
        //Debug.Log("po"+po);
        animator.transform.GetComponent<BoxCollider2D>().enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.position = Vector2.Lerp(rb.position,po,slidespeed);
        //Debug.Log(animator.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.GetComponent<BoxCollider2D>().enabled = true;
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

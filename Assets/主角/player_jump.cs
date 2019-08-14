using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_jump : StateMachineBehaviour
{
    Rigidbody2D rb;
    public int jumpcount;
    public float Jumphigh;
    public float high;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.transform.GetComponent<Rigidbody2D>();
        Debug.Log("in");
        rb.velocity = new Vector2(0, 0);
        //rb.AddForce(Vector2.up*animator.GetFloat("jumppower") );
        high = rb.position.y + Jumphigh;
        animator.SetInteger("jumpcount",animator.GetInteger("jumpcount")+1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        float ho = animator.GetFloat("horizontal");
        float sp = animator.GetFloat("speed");
        Debug.Log("123");
        rb.MovePosition(rb.position + Vector2.right * ho * sp * Time.timeScale+Vector2.up* animator.GetFloat("jumppower") * Time.timeScale);

        if (rb.position.y>=high)
        {
            animator.SetBool("fail", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("fail", false);
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

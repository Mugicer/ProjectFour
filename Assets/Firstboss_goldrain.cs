using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstboss_goldrain : StateMachineBehaviour
{
    public GameObject hopcoin;
    public float maxpower;
    public float minpower;
    GameObject coin;
    public GameObject moneybump;
    public float rain_time;
    public float timespace;
    public float high;
    public float right;
    public float left;
    public float time;
    float count;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        count = 0;
        time = rain_time;
        coin = Instantiate(hopcoin, animator.transform.parent);
        coin.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 ,1) * Random.Range(minpower , maxpower);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (coin==null)
        {
            coin = Instantiate(hopcoin, animator.transform.parent);
            coin.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * Random.Range(minpower, maxpower);
        }
        time = time - Time.deltaTime;
        count = count + Time.deltaTime;
        if (count>timespace)
        {
            count = count - timespace;
            GameObject a = Instantiate(moneybump, animator.transform.parent);
            a.transform.position = new Vector2(Random.Range(left,right),high);
        }
        if (time <0)
        {
            animator.SetBool("goldrain_done", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("goldrain_done", false);
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

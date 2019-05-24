using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Transform target;
    public EnemyMovement enemyMovement;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemyMovement = animator.gameObject.GetComponentInChildren<EnemyMovement>();
        target = enemyMovement.player.transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyMovement.playerAtEdgeOfRadius)
        {
            System.Random randomGen = new System.Random();
            var animationIndex = randomGen.Next(0, 1);

            if (animationIndex == 0)
            {
                if (target.position.x < animator.transform.parent.position.x)
                {
                    animator.SetBool("LargeJumpLeft", true);
                }
                else
                {
                    animator.SetBool("LargeJumpRight", true);
                }
            }
            else
            {
                animator.SetBool("Charge", true);
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Idle", false);
        if (!animator.GetBool("Charge"))
        {
            animator.SetBool("Jump", true);
        }
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

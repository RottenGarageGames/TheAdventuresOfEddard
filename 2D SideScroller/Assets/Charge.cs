using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Charge : StateMachineBehaviour
{
    public int stateDamage;
    public Transform target;
    public Transform parent;
    public float speed;
    public Rigidbody2D enemyMove;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.SetBool("Charge", false);
        animator.SetBool("LargeJumpLeft", false);
        animator.SetBool("LargeJumpRight", false);
        var newTarget = animator.gameObject.GetComponentInParent<EnemyMovement>();
        target = newTarget.player.transform;
        var enemy = animator.gameObject.GetComponentInChildren<HitBoxDetection>();
        enemy.SetEnemyMeleeDamage(stateDamage);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacksd
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.parent.position = Vector2.MoveTowards(animator.transform.parent.position, new Vector2(target.position.x, animator.transform.parent.position.y), speed);
        
        if(animator.transform.parent.position.x > target.position.x)
        {
            animator.SetBool("LargeJumpLeft", true);
        }
        else
        {
            animator.SetBool("LargeJumpRight", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
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

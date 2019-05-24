using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateMachineBehaviour
{
    public int stateDamage;
    public Transform target;
    public Transform parent;
    public float speed;
    public EnemyMovement enemyMovement;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var enemy = animator.gameObject.GetComponentInChildren<HitBoxDetection>();
        enemy.SetEnemyMeleeDamage(stateDamage);
        enemyMovement = animator.gameObject.GetComponentInChildren<EnemyMovement>();
        var newTarget = animator.gameObject.GetComponentInChildren<EnemyMovement>();
        target = newTarget.player.transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.parent.position = Vector2.MoveTowards(animator.transform.parent.position, new Vector2(target.position.x, animator.transform.parent.position.y), speed);
        if (enemyMovement.playerAtEdgeOfRadius)
        {
            animator.SetBool("Charge", true);

        }

        animator.SetBool("Jump", false);
        if (!animator.GetBool("Charge"))
        {
            animator.SetBool("Idle", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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

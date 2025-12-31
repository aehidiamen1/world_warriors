using UnityEngine;

public class Boss_AirAttack : StateMachineBehaviour
{
    public float moveSpeed = 5f;

    Boss boss;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        rb = animator.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        boss.startAirAttackPosition = rb.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = boss.skyPoint.position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPos = Vector2.MoveTowards(rb.position, boss.startAirAttackPosition, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPos);
        Debug.Log("Returning to ground!");
    }
}

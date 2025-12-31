using UnityEngine;

public class Boss_AirAttack : StateMachineBehaviour
{
    public float moveSpeed = 5f;

    Boss boss;
    Rigidbody2D rb;
    
    bool hasReachedSkyPoint = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        rb = animator.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        
        boss.startAirAttackPosition = rb.position;
        
        hasReachedSkyPoint = false;
        boss.shouldDescend = false;

        animator.SetBool("AirAttackComplete", false); 
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Boss goes to sky point
        if (!hasReachedSkyPoint)
        {
            Vector2 target = boss.skyPoint.position;
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.deltaTime);
            rb.MovePosition(newPos);
            
            // Check if the boss has the air attack point
            if (Vector2.Distance(rb.position, target) < 0.1f)
            {
                hasReachedSkyPoint = true;
                Debug.Log("Reached sky point!");
            }
        }
        //Boss returns to ground
        else if (boss.shouldDescend)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, boss.startAirAttackPosition, moveSpeed * Time.deltaTime);
            rb.MovePosition(newPos);
            
            // Check if the boss has returned to the ground
            if (Vector2.Distance(rb.position, boss.startAirAttackPosition) < 0.1f)
            {
                Debug.Log("Returned to ground position!");
                animator.SetBool("AirAttackComplete", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    [SerializeField] private Cooldown cooldown; 

  // Update is called once per frame
    void Update()
    {
        if (cooldown.IsCoolingDown) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();

            cooldown.StartCooldown();
        }
    }

    void Attack()
    {


        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); 

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

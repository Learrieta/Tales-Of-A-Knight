using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy: MonoBehaviour
{
   [SerializeField]private float attackCooldown;
   [SerializeField]private float range;
   [SerializeField]private int damage;
   [SerializeField]private BoxCollider2D boxCollider;
   [SerializeField]private LayerMask playerLayer ;
   [SerializeField]private float colliderDistance;
   private Animator anim;
   private Health playerHealth;

   private float cooldoownTimer = Mathf.Infinity;

   private void Awake() {
    anim = GetComponent<Animator>();
   }

   private void Update() {
    cooldoownTimer += Time.deltaTime;

    if (PlayerInSight())
    {
        if (cooldoownTimer >= attackCooldown)
        {
            cooldoownTimer = 0;
            anim.SetTrigger("meleeAttack");
            
        }
    }
   }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range , boxCollider.bounds.size.y, boxCollider.bounds.size.z),0,
        Vector2.left, 0,
        playerLayer );

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range , boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }

}

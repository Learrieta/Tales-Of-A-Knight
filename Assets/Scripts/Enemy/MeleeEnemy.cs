using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy: MonoBehaviour
{
   [SerializeField]private float attackCooldown;
   [SerializeField]private int damage;

   private float cooldoownTimer = Mathf.Infinity;

   private void Update() {
    cooldoownTimer += Time.deltaTime;

    if (PlayerInSight())
    {
        if (cooldoownTimer >= attackCooldown)
        {
            
        }
    }
   }

    private bool PlayerInSight()
    {
        return false;
    }


}

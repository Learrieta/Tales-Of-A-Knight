
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float startHealth;
    public float currentHealth{get; private set;}
    private Animator anim;

    private void Awake() {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
        }
        
    }
    
   
    
}

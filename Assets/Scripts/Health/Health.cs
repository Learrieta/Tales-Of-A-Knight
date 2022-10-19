
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]private float startHealth;
    private float currentHealth;

    private void Awake() {
        currentHealth = startHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if(currentHealth > 0)
        {

        }
        else
        {
            
        }
        
    }
    
}

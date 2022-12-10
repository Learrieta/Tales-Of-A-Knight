
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]private float startHealth;
    
    public float currentHealth{get; private set;}
    private Animator anim;
    private bool death;
    private bool invulnerable;

    [Header("iFrames")]
    [SerializeField]private float iFramesDuration;
    [SerializeField]private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Death sound")]
    [SerializeField]private AudioClip deathSound;

    [Header("Health sound")]
    [SerializeField]private AudioClip HealthSound;
    

    private void Awake() {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return ;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
            SoundManager.instance.Playsound(HealthSound);
        }
        else
        {
            if(!death)
            {
                

                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                
                //Enemy
                if( GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;


                if(GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                
                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                death = true;
                SoundManager.instance.Playsound(deathSound);

            }
            
        }
        
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 ,startHealth);
    }

    public void Respawn()
    {
        death = false;
        AddHealth(startHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invulnerability());
        if(GetComponent<PlayerMovement>() != null)
            GetComponent<PlayerMovement>().enabled = true;

                
        //Enemy
        if( GetComponentInParent<EnemyPatrol>() != null)
            GetComponentInParent<EnemyPatrol>().enabled = true;


        if(GetComponent<MeleeEnemy>() != null)
            GetComponent<MeleeEnemy>().enabled = true;

    }

    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color =  Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
   
    
}

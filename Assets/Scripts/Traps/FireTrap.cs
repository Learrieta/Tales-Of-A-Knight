using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header ("Firetrap Timer")]
    [SerializeField] private float activationDelay;

    [SerializeField] private float activeTime;
    [SerializeField] private float damages;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered;
    private bool active;
    private Health playerHealth;
    [SerializeField]private AudioClip fireSound;

    private void Update() 
    {
        if (playerHealth != null && active)
        {
            playerHealth.TakeDamage(damages);
        }
        
    }
    private void Awake() 
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if(!triggered)
                StartCoroutine(ActivateTrap());
            if(active)
                collision.GetComponent<Health>().TakeDamage(damages);
            
        }
        
    }

    private void  OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = null;
        }
        
    }
    private IEnumerator ActivateTrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.Playsound(fireSound);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
    
}

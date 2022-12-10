
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;
    [SerializeField]private float speed;
    [SerializeField]private float jumpPower;

    private float horizontalInput;

    private Animator anim;
    private Rigidbody2D body;

   
    

    private BoxCollider2D boxCollider;

    [Header("Jump sound")]
    [SerializeField]private AudioClip jumpSound;

    private void Awake(){

        //Get Reference for components
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        


        //Flip player
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);




        anim.SetBool("run", horizontalInput !=0);
        anim.SetBool("grounded", isGrounded() );


        if(Input.GetKeyDown(KeyCode.Space))
            Jump();
        
        if(Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y /2);
        
        if(onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

       

        
        
    }

    private void Jump()
    {
        if(isGrounded())
        {
            
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            SoundManager.instance.Playsound(jumpSound);
        }
        else if( onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);


            

        }
        
        

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f,groundLayer);

        return raycastHit.collider != null ;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f,wallLayer);

        return raycastHit.collider != null ;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

  
}

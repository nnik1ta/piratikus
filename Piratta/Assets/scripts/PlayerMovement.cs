using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public bool FacingRight = true;
    public float jumpForce = 8f;
    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float runSpeed = 1f;
    [Space]
    [Header("Ground Check Settings")]
    public bool isGround = false;
    [Range(-5f, 5f)] public float checkGroundOffSetY = -0.3f;
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;
    [Space]
    [Header("Sound Settings")]
    public AudioSource Jumping;
    public AudioSource Death;
    public int gem;
    public Text TextCoins;
    public AudioSource Eat;
    public Canvas vih;
    public bool IsCeiling;
    public bool IsCrouch;
    private int seconds = 2;
    private bool beba;
    
    





    public float horizontalMove = 0f;
    float SX, SY;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SY = transform.position.y;
        SX = transform.position.x;
       
       
    }
    
    public void flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f,180f,0f);   
    }
    
    void Update()

    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            Jumping.Play();
            
        }
        if (horizontalMove < 0 && FacingRight)
        {
            flip();
            /*bulka.velocity = new Vector2(4,0);*/

        }
        else if (horizontalMove > 0 && !FacingRight)
        {
            flip();
            /*bulka.velocity = new Vector2(-4, 0);*/
        }
        
        if (Input.GetKey(KeyCode.Escape))
        {
            /*vih.enabled = true;*/
        }
        else
        {
            /*vih.enabled = false;*/
        }
        if(isGround && Input.GetKey(KeyCode.LeftControl) || IsCeiling == true)
        {
            runSpeed = 0.4f;
            animator.SetBool("IsCrouch", true);
            GetComponent<BoxCollider2D>().enabled = false;
            IsCrouch = true;
        }
        else if (IsCeiling == false)
        {
            runSpeed = 0.87f;
            animator.SetBool("IsCrouch", false);
            GetComponent<BoxCollider2D>().enabled = true;
            IsCrouch = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJump", true);
        }
        if (!isGround)
        {
            animator.SetBool("IsJump", true);
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
        if (beba == true)
        {
            jumpForce = 0f;
        }
        else if (beba == false)
        {
            jumpForce = 25f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            Death.Play();
            transform.position = new Vector3(SY, SX, transform.position.z);
        }
        
        if (collision.gameObject.name == "NextLevel")
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.tag == "cherry")
        {
            Eat.Play();

        }
        if (collision.gameObject.tag == "enemy")
        {
            animator.SetBool("IsHit", true);
           /* StartCoroutine(Invunerability());*/
           
        }  
        else
        {
            animator.SetBool("IsHit", false);
        }
    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        CheckGround();
        
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffSetY), checkGroundRadius);
        if (collider.Length > 1)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "money")
        {
            gem++;
            Destroy(collision.gameObject);
            TextCoins.text = gem.ToString();
        }
        if (collision.gameObject.tag == "ground")
        {
            IsCeiling = true;
        }
        if (collision.gameObject.tag == "checkpoint")
        {
            SY = transform.position.y;
            SX = transform.position.x;
            Destroy(collision.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lestnica")
        {
            animator.SetBool("IsClimb", false);
        }
        if (collision.gameObject.tag == "ground")
        {
            IsCeiling = false;
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lestnica")
        {
            animator.SetBool("IsClimb", true);
        }
    }
    private IEnumerator Invunerability()
    {
        beba = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody2D>().gravityScale = 4;
        beba = false;
    }

}
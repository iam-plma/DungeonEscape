using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;

    private float jumpForce = 6.5f;
    private bool resetJump = false;
    private float speedForce = 3.0f;
    private bool grounded = true;

    private PlayerAnimation anim;
    private SpriteRenderer spriteRenderer;

    public int gems;

    public int Health { get; set; }

    void Start()
    {
        Health = 4;
        gems = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Health < 1)
            return;

        Movement();
        Attack();
    }

    private void Attack()
    {
        //bool attack = Input.GetMouseButtonDown(0);
        grounded = IsGrounded();

        if(CrossPlatformInputManager.GetButtonDown("A_Button") && grounded)
        {
            anim.Attack();
        }
    }

    private void Movement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        grounded = IsGrounded();

        if (horizontalInput < 0)
            Flip(false);
        else if (horizontalInput > 0)
            Flip(true);

        if ((Input.GetKeyDown(KeyCode.Space) && grounded) || (CrossPlatformInputManager.GetButtonDown("B_Button") && grounded))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            anim.Jump(true);
        }

        
        rb.velocity = new Vector2(horizontalInput * speedForce, rb.velocity.y);

        anim.Move(horizontalInput);
    }

    private void Flip(bool facingRight)
    {
        if(facingRight)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if(!facingRight)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);



        if (hit.collider != null)
        {
            if (!resetJump)
            {
                anim.Jump(false);
                return true;
            }
        }

        return false; 
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("Damage");
        if (Health < 1)
            return;

        Health--;
        UIManager.Instance.UpdateLives(Health);
        if (Health < 1)
            anim.Death();
    }

    public void AddGems(int count)
    {
        gems += count;
        UIManager.Instance.UpdateGemCount(gems);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private Animator playerAnim;
    private Animator swordAnim;


    private void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {
        playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        playerAnim.SetBool("Jumping", jump);
    }

    public void Attack()
    {
        playerAnim.SetTrigger("Attack");
        swordAnim.SetTrigger("SwordAnimation");
    }

    public void Death()
    {
        playerAnim.SetTrigger("Death");
    }
}

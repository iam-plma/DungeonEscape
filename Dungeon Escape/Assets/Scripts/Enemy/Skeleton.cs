using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public override void Movement()
    {
        base.Movement();

        
    }

    public void Damage()
    {
        if (!isDead)
        {
            Health--;
            anim.SetTrigger("Hit");
            anim.SetBool("InCombat", true);
            isHit = true;

            if (Health < 1)
            {
                anim.SetTrigger("Death");
                isDead = true;
                GameObject diamond = Instantiate(base.diamond, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = base.gems;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    [SerializeField]
    private GameObject acid;

    public override void Init()
    {
        base.Init();

        Health = health;
    }

    public override void Update()
    {
        
    }

    public override void Movement()
    {
        
    }

    public void Damage()
    {
        if (!isDead)
        {
            Health--;
    
            if (Health < 1)
            {
                anim.SetTrigger("Death");
                GameObject diamond = Instantiate(base.diamond, transform.position, Quaternion.identity) as GameObject;
                diamond.GetComponent<Diamond>().gems = base.gems;
            }
        }

    }

    public override void Attack()
    {
        Instantiate(acid, transform.position, Quaternion.identity);
    }
}

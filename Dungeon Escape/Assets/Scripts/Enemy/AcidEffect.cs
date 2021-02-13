using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private float speed = 3.0f;
    
    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TurretProjectile : MonoBehaviour

{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        if(collision.GetComponent<findme>())
        collision.gameObject.SetActive(false);

        Destroy(gameObject);

    }
}

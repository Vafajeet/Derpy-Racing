using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
   // public GameObject pickupEffect;

    public float multiplier = 1.4f;
    public float duration = 4f;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine (PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        Debug.Log("I pick it up");
       // Instantiate(pickupEffect, transform.position, transform.rotation);

        CharacterController2D stats = player.GetComponent<CharacterController2D>();
        stats.speed *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.speed /= multiplier;

        Destroy(gameObject);
    }
}

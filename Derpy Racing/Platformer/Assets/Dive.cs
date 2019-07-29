using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{
    public CharController charC;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bubble")
        {
            charC.velocity.y = charC.jumpVelocity;
            print("in here");
            Destroy(collision.gameObject);
        }
        if(collision.collider.tag == "RBubble")
        {
            charC.velocity.y = charC.jumpVelocity;
            collision.gameObject.SetActive(false);
            StartCoroutine(charC.SpawnB(collision.gameObject));
        }
        
    }
   
}

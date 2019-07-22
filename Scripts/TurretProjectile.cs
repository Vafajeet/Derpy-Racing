using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TurretProjectile : MonoBehaviour

{
    [SerializeField] float speed = 5;
    [SerializeField] float rotatingSpeed = 200;
    public GameObject target;
    //public GameObject explosionEffect;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per framed
    void FixedUpdate()
    {
        /*if (target.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateamount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateamount * rotatespeed;
            rb.velocity = transform.up * speed;
        }*/

        Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
        point2Target.Normalize();
        float value = Vector3.Cross(point2Target, transform.right).z;

        rb.angularVelocity = rotatingSpeed * value;
        rb.velocity = transform.right * speed;
        
    }

    private void OnTriggerEnter2D()
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(target.gameObject);
        Destroy(gameObject);

    }
}

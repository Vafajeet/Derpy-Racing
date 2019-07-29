using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawn : MonoBehaviour
{
    public Rigidbody2D prefabMissle;
    public Transform parent;
    float speed = 500f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            var firedBullet = Instantiate(prefabMissle, parent.position, parent.rotation);
            firedBullet.AddForce(parent.right * speed);
        }

    }
}

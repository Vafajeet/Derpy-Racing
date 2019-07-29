using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public GameObject parent;
    public GameObject item;
    public GameObject rtcl;
    public GameObject reticleI;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
           
            parent = collision.GetComponentInChildren<findme>().gameObject;
            item = Instantiate(item, parent.transform.position, parent.transform.rotation);
            rtcl = item.GetComponentInChildren<reticle>().gameObject;
            item.transform.parent = parent.transform;
            reticleI = Instantiate(reticleI, rtcl.transform.position, rtcl.transform.rotation);
            reticleI.transform.parent = rtcl.transform;
            



            Destroy(gameObject);
        }
        Destroy(gameObject);
        if (collision.tag == "Player2")
        {
            parent = collision.GetComponentInChildren<findme>().gameObject;
            item = Instantiate(item, parent.transform.position, parent.transform.rotation);
            item.transform.parent = parent.transform;
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}

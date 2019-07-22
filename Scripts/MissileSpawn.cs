using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawn : MonoBehaviour
{
    public GameObject prefabMissle;
    public float timer = 2f;
    GameObject prefabMissleClone;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            prefabMissleClone = Instantiate(prefabMissle, new Vector2(transform.position.x,transform.position.y), Quaternion.identity) as GameObject;
            timer = 2f;

        }
    }
}

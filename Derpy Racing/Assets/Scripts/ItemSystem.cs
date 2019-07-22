using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    [SerializeField] int curIndex;
    [SerializeField] Transform[] spawnLocal;
    [SerializeField] bool pressed;
    [SerializeField] float delay;
    [SerializeField] float curCooldown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) == true)
        {
            pressed = true;
        }

        curIndex = Random.Range(0, 3);

        if (curCooldown < delay)
        {
            curCooldown += Time.deltaTime;
        }
        if(curCooldown >= delay)
        {
            curCooldown = delay;
            if (pressed == true)
            {
                SpawnItem();               
            }
        }
    }

    void SpawnItem()
    {
        curCooldown = 0;
        Instantiate(Items[curIndex], spawnLocal[curIndex]);
        pressed = false;
    }
}

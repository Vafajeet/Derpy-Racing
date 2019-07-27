using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    CharacterController2D player;
    [SerializeField] GameObject[] Items;
    [SerializeField] int curIndex;
    [SerializeField] Transform[] spawnLocal;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController2D>();

        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        curIndex = Random.Range(0, 3);
    }

    void SpawnItem()
    {
        Instantiate(Items[curIndex], spawnLocal[0]);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (spawnLocal[0].gameObject == player.gameObject)
        {
            Debug.Log("Touched");
            Instantiate(Items[curIndex], player.transform);
        }
    }
}
